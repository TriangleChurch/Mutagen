using Mutagen.Bethesda.Internals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Binary
{
    /// <summary>
    /// A disposable class that helps streamline writing headers.
    /// Track number of bytes written inside its using statement, and then 
    /// updates the header's length bytes appropriately when it is disposed.
    /// </summary>
    public struct HeaderExport : IDisposable
    {
        /// <summary>
        /// Writer being tracked
        /// </summary>
        public readonly MutagenWriter Writer;
        
        /// <summary>
        /// Location of the header's length bytes
        /// </summary>
        public readonly long SizePosition;
        
        /// <summary>
        /// Record constants to use
        /// </summary>
        public readonly RecordHeaderConstants RecordConstants;

        private HeaderExport(
            MutagenWriter writer,
            long sizePosition,
            RecordHeaderConstants recordConstants)
        {
            this.Writer = writer;
            this.RecordConstants = recordConstants;
            this.SizePosition = sizePosition;
        }

        /// <summary>
        /// Exports a header, and creates disposable to track content length.
        /// When disposed, header will automatically update its length bytes.
        /// </summary>
        /// <param name="writer">Writer to export header to</param>
        /// <param name="record">RecordType of the header</param>
        /// <param name="type">ObjectType the header is for</param>
        /// <returns>Object to dispose when header's content has been written</returns>
        public static HeaderExport Header(
            MutagenWriter writer,
            RecordType record,
            ObjectType type)
        {
            writer.Write(record.TypeInt);
            var sizePosition = writer.Position;
            writer.Write(UtilityTranslation.Zeros.Slice(0, writer.MetaData.Constants.Constants(type).LengthLength));
            return new HeaderExport(writer, sizePosition, writer.MetaData.Constants.Constants(type));
        }

        /// <summary>
        /// Exports a subrecord header, and creates disposable to track content length.
        /// When disposed, header will automatically update its length bytes.
        /// </summary>
        /// <param name="writer">Writer to export header to</param>
        /// <param name="record">RecordType of the header</param>
        /// <returns>Object to dispose when header's content has been written</returns>
        public static HeaderExport Subrecord(
            MutagenWriter writer,
            RecordType record)
        {
            return Header(writer, record, ObjectType.Subrecord);
        }

        /// <summary>
        /// Exports a subrecord header, and creates disposable to track content length.
        /// When disposed, header will automatically update its length bytes.
        /// </summary>
        /// <param name="writer">Writer to export header to</param>
        /// <param name="record">RecordType of the header</param>
        /// <param name="overflowRecord">RecordType to use for an extra preceding subrecord, if the length is too large</param>
        /// <returns>Object to dispose when header's content has been written</returns>
        public static ExtraLengthHeaderExport Subrecord(
            MutagenWriter writer,
            RecordType record,
            RecordType overflowRecord)
        {
            return new ExtraLengthHeaderExport(
                writer,
                record,
                overflowRecord);
        }

        /// <summary>
        /// Measures length of content and writes results to header
        /// </summary>
        public void Dispose()
        {
            var endPos = this.Writer.Position;
            this.Writer.Position = this.SizePosition;
            var diff = endPos - this.Writer.Position;
            if (this.RecordConstants.HeaderIncludedInLength)
            {
                diff += Constants.HeaderLength;
            }
            else
            {
                diff -= this.RecordConstants.LengthAfterType;
            }

            // If negative, we're likely mid-exception.
            // We want exit out and trickle up the original
            if (diff < 0)
            {
                return;
            }

            switch (this.RecordConstants.ObjectType)
            {
                case ObjectType.Subrecord:
                    {
                        this.Writer.Write(checked((ushort)diff));
                    }
                    break;
                case ObjectType.Record:
                case ObjectType.Group:
                    {
                        this.Writer.Write(checked((uint)diff));
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
            this.Writer.Position = endPos;
        }
    }
}

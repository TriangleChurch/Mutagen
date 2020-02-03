﻿using Loqui.Internal;
using Noggog;
using System;

namespace Mutagen.Bethesda.Binary
{
    public class EnumBinaryTranslation<E>
        where E : struct, Enum, IConvertible
    {
        public readonly static EnumBinaryTranslation<E> Instance = new EnumBinaryTranslation<E>();

        public bool Parse(
            MutagenFrame frame,
            out E item)
        {
            item = ParseValue(frame);
            return true;
        }

        public E Parse(MutagenFrame frame)
        {
            return ParseValue(frame);
        }

        public bool Parse(
            MutagenFrame frame,
            out E? item)
        {
            item = ParseValue(frame);
            return true;
        }

        public void Write(MutagenWriter writer, E item, long length)
        {
            WriteValue(writer, item, length);
        }

        public void Write(
            MutagenWriter writer,
            E? item,
            long length)
        {
            if (!item.HasValue)
            {
                throw new NotImplementedException();
            }
            WriteValue(writer, item.Value, length);
        }

        public void Write(
            MutagenWriter writer,
            E item,
            RecordType header,
            long length)
        {
            using (HeaderExport.ExportHeader(writer, header, ObjectType.Subrecord))
            {
                WriteValue(writer, item, length);
            }
        }

        public void WriteNullable(
            MutagenWriter writer,
            E? item,
            RecordType header,
            long length)
        {
            if (!item.HasValue) return;
            using (HeaderExport.ExportHeader(writer, header, ObjectType.Subrecord))
            {
                WriteValue(writer, item.Value, length);
            }
        }

        public E ParseValue(MutagenFrame reader, ErrorMaskBuilder? errorMask)
        {
            int i;
            switch (reader.Remaining)
            {
                case 1:
                    i = reader.Reader.ReadUInt8();
                    break;
                case 2:
                    i = reader.Reader.ReadInt16();
                    break;
                case 4:
                    i = reader.Reader.ReadInt32();
                    break;
                default:
                    throw new NotImplementedException();
            }
            return EnumExt<E>.Convert(i);
        }

        public E ParseValue(MutagenFrame reader)
        {
            return ParseValue(reader, errorMask: null);
        }

        protected void WriteValue(MutagenWriter writer, E item, long length)
        {
            var i = item.ToInt32(null);
            switch (length)
            {
                case 1:
                    writer.Write((byte)i);
                    break;
                case 2:
                    writer.Write((ushort)i);
                    break;
                case 4:
                    writer.Write(i);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

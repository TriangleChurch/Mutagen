﻿using Noggog;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Mutagen.Bethesda
{
    /// <summary>
    /// Class that does minimal processing on string file data, exposing lookup queries in a lazy on-demand fashion.
    /// </summary>
    public class StringsLookupOverlay : IStringsLookup
    {
        private readonly ReadOnlyMemorySlice<byte> _indexData;
        private ReadOnlyMemorySlice<byte> _stringData;

        public int Count => _indexData.Length / 8;

        /// <summary>
        /// Overlays onto a set of bytes assumed to be in Strings file format
        /// </summary>
        /// <param name="data">Data to wrap</param>
        public StringsLookupOverlay(ReadOnlyMemorySlice<byte> data)
        {
            try
            {
                var count = BinaryPrimitives.ReadUInt32LittleEndian(data);
                var dataSize = checked((int)BinaryPrimitives.ReadUInt32LittleEndian(data.Slice(4)));
                _indexData = data.Slice(8, checked((int)(count * 2 * 4)));
                _stringData = data.Slice(8 + _indexData.Length, dataSize);
            }
            catch (OverflowException)
            {
                throw new ArgumentException("Strings file was too big for current systems");
            }
        }

        /// <summary>
        /// Reads all bytes from a file, and overlays them
        /// </summary>
        /// <param name="path">Path to read in</param>
        public StringsLookupOverlay(string path)
            : this(File.ReadAllBytes(path))
        {
        }

        /// <inheritdoc />
        public bool TryLookup(uint key, [MaybeNullWhen(false)] out string str)
        {
            key -= 1;
            if (key >= Count)
            {
                str = default;
                return false;
            }
            var loc = BinaryPrimitives.ReadInt32LittleEndian(_indexData.Slice((int)(key * 8 + 4)));
            str = BinaryStringUtility.ParseUnknownLengthString(this._stringData.Slice(loc));
            return true;
        }
    }
}

using FluentAssertions;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Oblivion;
using Mutagen.Bethesda.Oblivion.Internals;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Mutagen.Bethesda.UnitTests
{
    public class HeaderExt_Test
    {
        /// NPC, /w EDID followed by DATA
        public readonly static byte[] _majorBytes = new byte[]
        {
            0x4E, 0x50, 0x43, 0x5F, 0x18, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x62, 0x0D, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x45, 0x44, 0x49, 0x44,
            0x08, 0x00, 0x52, 0x65, 0x63, 0x6F, 0x72, 0x64,
            0x31, 0x00, 0x44, 0x41, 0x54, 0x41, 0x04, 0x00,
            0x01, 0x02, 0x03, 0x04
        };

        public const int DataValue = 0x04030201;
        public const int DataPos = 0x22;

        [Fact]
        public void MajorFrameTryLocateSubrecord()
        {
            var majorFrame = new MajorRecordFrame(GameConstants.Oblivion, _majorBytes);
            Assert.True(majorFrame.TryLocateSubrecord(RecordTypes.DATA, out var _, out var loc));
            Assert.Equal(DataPos, loc);
        }

        [Fact]
        public void MajorFrameTryLocateSubrecordFrame()
        {
            var majorFrame = new MajorRecordFrame(GameConstants.Oblivion, _majorBytes);
            Assert.True(majorFrame.TryLocateSubrecordFrame(RecordTypes.DATA, out var subFrame, out var loc));
            Assert.Equal(DataPos, loc);
            Assert.Equal(DataValue, subFrame.AsInt32());
        }

        [Fact]
        public void MajorFrameLocateSubrecord()
        {
            var majorFrame = new MajorRecordFrame(GameConstants.Oblivion, _majorBytes);
            majorFrame.LocateSubrecord(RecordTypes.DATA, out var loc);
            Assert.Equal(DataPos, loc);
        }

        [Fact]
        public void MajorFrameLocateSubrecordFrame()
        {
            var majorFrame = new MajorRecordFrame(GameConstants.Oblivion, _majorBytes);
            var subFrame = majorFrame.LocateSubrecordFrame(RecordTypes.DATA, out var loc);
            Assert.Equal(DataPos, loc);
            Assert.Equal(DataValue, subFrame.AsInt32());
        }

        [Fact]
        public void MajorMemoryFrameTryLocateSubrecord()
        {
            var majorFrame = new MajorRecordFrame(GameConstants.Oblivion, _majorBytes);
            Assert.True(majorFrame.TryLocateSubrecord(RecordTypes.DATA, out var _, out var loc));
            Assert.Equal(DataPos, loc);
        }

        [Fact]
        public void MajorMemoryFrameTryLocateSubrecordFrame()
        {
            var majorFrame = new MajorRecordFrame(GameConstants.Oblivion, _majorBytes);
            Assert.True(majorFrame.TryLocateSubrecordFrame(RecordTypes.DATA, out var subFrame, out var loc));
            Assert.Equal(DataPos, loc);
            Assert.Equal(DataValue, subFrame.AsInt32());
        }

        [Fact]
        public void MajorMemoryFrameLocateSubrecord()
        {
            var majorFrame = new MajorRecordFrame(GameConstants.Oblivion, _majorBytes);
            majorFrame.LocateSubrecord(RecordTypes.DATA, out var loc);
            Assert.Equal(DataPos, loc);
        }

        [Fact]
        public void MajorMemoryFrameLocateSubrecordFrame()
        {
            var majorFrame = new MajorRecordFrame(GameConstants.Oblivion, _majorBytes);
            var subFrame = majorFrame.LocateSubrecordFrame(RecordTypes.DATA, out var loc);
            Assert.Equal(DataPos, loc);
            Assert.Equal(DataValue, subFrame.AsInt32());
        }

        [Fact]
        public void EnumerateSubrecordsDirect()
        {
            byte[] b = new byte[]
            {
                0x01, 0x02,
                0x4D, 0x41, 0x53, 0x54, 0x4, 0x00, 0x01, 0x02, 0x03, 0x04,
                0x44, 0x41, 0x54, 0x41, 0x4, 0x00, 0x09, 0x08, 0x07, 0x06
            };
            var recs = HeaderExt.EnumerateSubrecords(b, GameConstants.Oblivion, 2)
                .ToList();
            recs.Should().HaveCount(2);
            recs[0].RecordType.Should().Be(RecordTypes.MAST);
            recs[1].RecordType.Should().Be(RecordTypes.DATA);
            recs[0].ContentLength.Should().Be(4);
            recs[1].ContentLength.Should().Be(4);
            recs[0].AsInt32().Should().Be(0x04030201);
            recs[1].AsInt32().Should().Be(0x06070809);
        }
    }
}

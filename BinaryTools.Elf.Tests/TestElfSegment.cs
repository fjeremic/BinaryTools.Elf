using BinaryTools.Elf.Io;
using System.IO;
using Xunit;

namespace BinaryTools.Elf.Tests
{
    public class TestElfSegment
    {
        [Fact]
        public void TestCount()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(9, elfFile.Segments.Count);
        }

        [Fact]
        public void TestType()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfSegmentType.PHdr, elfFile.Segments[0].Type);
            Assert.Equal(ElfSegmentType.Interp, elfFile.Segments[1].Type);
            Assert.Equal(ElfSegmentType.Load, elfFile.Segments[2].Type);
            Assert.Equal(ElfSegmentType.Load, elfFile.Segments[3].Type);
            Assert.Equal(ElfSegmentType.Dynamic, elfFile.Segments[4].Type);
            Assert.Equal(ElfSegmentType.Note, elfFile.Segments[5].Type);
        }
    }
}

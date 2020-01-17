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


        [Fact]
        public void TestOffset()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0x0000000000000040UL, elfFile.Segments[0].Offset);
            Assert.Equal(0x0000000000000238UL, elfFile.Segments[1].Offset);
            Assert.Equal(0x0000000000000000UL, elfFile.Segments[2].Offset);
            Assert.Equal(0x0000000000008E10UL, elfFile.Segments[3].Offset);
            Assert.Equal(0x0000000000008E28UL, elfFile.Segments[4].Offset);
            Assert.Equal(0x0000000000000254UL, elfFile.Segments[5].Offset);
        }

        [Fact]
        public void TestVirtualAddress()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0x0000000000400040UL, elfFile.Segments[0].VirtualAddress);
            Assert.Equal(0x0000000000400238UL, elfFile.Segments[1].VirtualAddress);
            Assert.Equal(0x0000000000400000UL, elfFile.Segments[2].VirtualAddress);
            Assert.Equal(0x0000000000608e10UL, elfFile.Segments[3].VirtualAddress);
            Assert.Equal(0x0000000000608e28UL, elfFile.Segments[4].VirtualAddress);
            Assert.Equal(0x0000000000400254UL, elfFile.Segments[5].VirtualAddress);
        }

        [Fact]
        public void TestPhysicalAddress()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0x0000000000400040UL, elfFile.Segments[0].VirtualAddress);
            Assert.Equal(0x0000000000400238UL, elfFile.Segments[1].VirtualAddress);
            Assert.Equal(0x0000000000400000UL, elfFile.Segments[2].VirtualAddress);
            Assert.Equal(0x0000000000608e10UL, elfFile.Segments[3].VirtualAddress);
            Assert.Equal(0x0000000000608e28UL, elfFile.Segments[4].VirtualAddress);
            Assert.Equal(0x0000000000400254UL, elfFile.Segments[5].VirtualAddress);
        }

        [Fact]
        public void TestFileSize()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0x00000000000001F8UL, elfFile.Segments[0].FileSize);
            Assert.Equal(0x000000000000001CUL, elfFile.Segments[1].FileSize);
            Assert.Equal(0x0000000000008164UL, elfFile.Segments[2].FileSize);
            Assert.Equal(0x0000000000000464UL, elfFile.Segments[3].FileSize);
            Assert.Equal(0x00000000000001D0UL, elfFile.Segments[4].FileSize);
            Assert.Equal(0x0000000000000044UL, elfFile.Segments[5].FileSize);
        }

        [Fact]
        public void TestMemorySize()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0x00000000000001F8UL, elfFile.Segments[0].MemorySize);
            Assert.Equal(0x000000000000001CUL, elfFile.Segments[1].MemorySize);
            Assert.Equal(0x0000000000008164UL, elfFile.Segments[2].MemorySize);
            Assert.Equal(0x0000000000000630UL, elfFile.Segments[3].MemorySize);
            Assert.Equal(0x00000000000001D0UL, elfFile.Segments[4].MemorySize);
            Assert.Equal(0x0000000000000044UL, elfFile.Segments[5].MemorySize);
        }

        [Fact]
        public void TestFlags()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfSegmentFlags.Read | ElfSegmentFlags.Exec, elfFile.Segments[0].Flags);
            Assert.Equal(ElfSegmentFlags.Read, elfFile.Segments[1].Flags);
            Assert.Equal(ElfSegmentFlags.Read | ElfSegmentFlags.Exec, elfFile.Segments[2].Flags);
            Assert.Equal(ElfSegmentFlags.Read | ElfSegmentFlags.Write, elfFile.Segments[3].Flags);
            Assert.Equal(ElfSegmentFlags.Read | ElfSegmentFlags.Write, elfFile.Segments[4].Flags);
            Assert.Equal(ElfSegmentFlags.Read, elfFile.Segments[5].Flags);
        }

        [Fact]
        public void TestAlignment()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0x8UL, elfFile.Segments[0].Alignment);
            Assert.Equal(0x1UL, elfFile.Segments[1].Alignment);
            Assert.Equal(0x200000UL, elfFile.Segments[2].Alignment);
            Assert.Equal(0x200000UL, elfFile.Segments[3].Alignment);
            Assert.Equal(0x8UL, elfFile.Segments[4].Alignment);
            Assert.Equal(0x4UL, elfFile.Segments[5].Alignment);
        }

        [Fact]
        public void TestSectionToSegmentMapping()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0, elfFile.Segments[0].Sections.Count);
            Assert.Equal(1, elfFile.Segments[1].Sections.Count);
            Assert.Equal(elfFile.Sections[1], elfFile.Segments[1].Sections[0]);

            Assert.Equal(18, elfFile.Segments[2].Sections.Count);
            Assert.Equal(elfFile.Sections[1], elfFile.Segments[2].Sections[0]);
            Assert.Equal(elfFile.Sections[2], elfFile.Segments[2].Sections[1]);
            Assert.Equal(elfFile.Sections[3], elfFile.Segments[2].Sections[2]);
            Assert.Equal(elfFile.Sections[4], elfFile.Segments[2].Sections[3]);
            Assert.Equal(elfFile.Sections[5], elfFile.Segments[2].Sections[4]);
            Assert.Equal(elfFile.Sections[6], elfFile.Segments[2].Sections[5]);
            Assert.Equal(elfFile.Sections[7], elfFile.Segments[2].Sections[6]);
            Assert.Equal(elfFile.Sections[8], elfFile.Segments[2].Sections[7]);
            Assert.Equal(elfFile.Sections[9], elfFile.Segments[2].Sections[8]);
            Assert.Equal(elfFile.Sections[10], elfFile.Segments[2].Sections[9]);
            Assert.Equal(elfFile.Sections[11], elfFile.Segments[2].Sections[10]);
            Assert.Equal(elfFile.Sections[12], elfFile.Segments[2].Sections[11]);
            Assert.Equal(elfFile.Sections[13], elfFile.Segments[2].Sections[12]);
            Assert.Equal(elfFile.Sections[14], elfFile.Segments[2].Sections[13]);
            Assert.Equal(elfFile.Sections[15], elfFile.Segments[2].Sections[14]);
            Assert.Equal(elfFile.Sections[16], elfFile.Segments[2].Sections[15]);
            Assert.Equal(elfFile.Sections[17], elfFile.Segments[2].Sections[16]);
            Assert.Equal(elfFile.Sections[18], elfFile.Segments[2].Sections[17]);

            Assert.Equal(8, elfFile.Segments[3].Sections.Count);
            Assert.Equal(elfFile.Sections[19], elfFile.Segments[3].Sections[0]);
            Assert.Equal(elfFile.Sections[20], elfFile.Segments[3].Sections[1]);
            Assert.Equal(elfFile.Sections[21], elfFile.Segments[3].Sections[2]);
            Assert.Equal(elfFile.Sections[22], elfFile.Segments[3].Sections[3]);
            Assert.Equal(elfFile.Sections[23], elfFile.Segments[3].Sections[4]);
            Assert.Equal(elfFile.Sections[24], elfFile.Segments[3].Sections[5]);
            Assert.Equal(elfFile.Sections[25], elfFile.Segments[3].Sections[6]);
            Assert.Equal(elfFile.Sections[26], elfFile.Segments[3].Sections[7]);

            Assert.Equal(1, elfFile.Segments[4].Sections.Count);
            Assert.Equal(elfFile.Sections[22], elfFile.Segments[4].Sections[0]);

            Assert.Equal(2, elfFile.Segments[5].Sections.Count);
            Assert.Equal(elfFile.Sections[2], elfFile.Segments[5].Sections[0]);
            Assert.Equal(elfFile.Sections[3], elfFile.Segments[5].Sections[1]);

            Assert.Equal(1, elfFile.Segments[6].Sections.Count);
            Assert.Equal(elfFile.Sections[17], elfFile.Segments[6].Sections[0]);

            Assert.Equal(0, elfFile.Segments[7].Sections.Count);
            Assert.Equal(5, elfFile.Segments[8].Sections.Count);
            Assert.Equal(elfFile.Sections[19], elfFile.Segments[8].Sections[0]);
            Assert.Equal(elfFile.Sections[20], elfFile.Segments[8].Sections[1]);
            Assert.Equal(elfFile.Sections[21], elfFile.Segments[8].Sections[2]);
            Assert.Equal(elfFile.Sections[22], elfFile.Segments[8].Sections[3]);
            Assert.Equal(elfFile.Sections[23], elfFile.Segments[8].Sections[4]);
        }
    }
}

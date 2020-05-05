namespace BinaryTools.Elf.Tests
{
    using System.IO;
    using BinaryTools.Elf.Io;
    using Xunit;

    public class TestElfSection
    {
        [Fact]
        public void TestCount()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(29, elfFile.Sections.Count);
        }

        [Fact]
        public void TestName()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(string.Empty, elfFile.Sections[0].Name);
            Assert.Equal(".dynsym", elfFile.Sections[5].Name);
            Assert.Equal(".plt.got", elfFile.Sections[13].Name);
            Assert.Equal(".dynamic", elfFile.Sections[22].Name);
            Assert.Equal(".got.plt", elfFile.Sections[24].Name);
        }

        [Fact]
        public void TestType()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfSectionType.Null, elfFile.Sections[0].Type);
            Assert.Equal(ElfSectionType.ProgBits, elfFile.Sections[1].Type);
            Assert.Equal(ElfSectionType.Note, elfFile.Sections[2].Type);
            Assert.Equal(ElfSectionType.DynSym, elfFile.Sections[5].Type);
            Assert.Equal(ElfSectionType.StrTab, elfFile.Sections[6].Type);
            Assert.Equal(ElfSectionType.RelA, elfFile.Sections[9].Type);
            Assert.Equal(ElfSectionType.InitArray, elfFile.Sections[19].Type);
            Assert.Equal(ElfSectionType.FiniArray, elfFile.Sections[20].Type);
            Assert.Equal(ElfSectionType.Dynamic, elfFile.Sections[22].Type);
            Assert.Equal(ElfSectionType.StrTab, elfFile.Sections[28].Type);
        }

        [Fact]
        public void TestAddress()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0x0000000000000000UL, elfFile.Sections[0].Address);
            Assert.Equal(0x0000000000400238UL, elfFile.Sections[1].Address);
            Assert.Equal(0x0000000000400254UL, elfFile.Sections[2].Address);
            Assert.Equal(0x00000000004002e0UL, elfFile.Sections[5].Address);
            Assert.Equal(0x0000000000400958UL, elfFile.Sections[6].Address);
            Assert.Equal(0x0000000000400d28UL, elfFile.Sections[9].Address);
            Assert.Equal(0x0000000000608e10UL, elfFile.Sections[19].Address);
            Assert.Equal(0x0000000000608e18UL, elfFile.Sections[20].Address);
            Assert.Equal(0x0000000000608e28UL, elfFile.Sections[22].Address);
            Assert.Equal(0x0000000000000000UL, elfFile.Sections[28].Address);
        }

        [Fact]
        public void TestOffset()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0x0000000000000000UL, elfFile.Sections[0].Offset);
            Assert.Equal(0x0000000000000238UL, elfFile.Sections[1].Offset);
            Assert.Equal(0x0000000000000254UL, elfFile.Sections[2].Offset);
            Assert.Equal(0x00000000000002e0UL, elfFile.Sections[5].Offset);
            Assert.Equal(0x0000000000000958UL, elfFile.Sections[6].Offset);
            Assert.Equal(0x0000000000000d28UL, elfFile.Sections[9].Offset);
            Assert.Equal(0x0000000000008e10UL, elfFile.Sections[19].Offset);
            Assert.Equal(0x0000000000008e18UL, elfFile.Sections[20].Offset);
            Assert.Equal(0x0000000000008e28UL, elfFile.Sections[22].Offset);
            Assert.Equal(0x00000000000092a8UL, elfFile.Sections[28].Offset);
        }

        [Fact]
        public void TestSize()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0x0000000000000000UL, elfFile.Sections[0].Size);
            Assert.Equal(0x000000000000001cUL, elfFile.Sections[1].Size);
            Assert.Equal(0x0000000000000020UL, elfFile.Sections[2].Size);
            Assert.Equal(0x0000000000000678UL, elfFile.Sections[5].Size);
            Assert.Equal(0x00000000000002e0UL, elfFile.Sections[6].Size);
            Assert.Equal(0x00000000000000c0UL, elfFile.Sections[9].Size);
            Assert.Equal(0x0000000000000008UL, elfFile.Sections[19].Size);
            Assert.Equal(0x0000000000000008UL, elfFile.Sections[20].Size);
            Assert.Equal(0x00000000000001d0UL, elfFile.Sections[22].Size);
            Assert.Equal(0x0000000000000102UL, elfFile.Sections[28].Size);
        }

        [Fact]
        public void TestEntrySize()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0x0000000000000000UL, elfFile.Sections[0].EntrySize);
            Assert.Equal(0x0000000000000000UL, elfFile.Sections[1].EntrySize);
            Assert.Equal(0x0000000000000000UL, elfFile.Sections[2].EntrySize);
            Assert.Equal(0x0000000000000018UL, elfFile.Sections[5].EntrySize);
            Assert.Equal(0x0000000000000000UL, elfFile.Sections[6].EntrySize);
            Assert.Equal(0x0000000000000018UL, elfFile.Sections[9].EntrySize);
            Assert.Equal(0x0000000000000000UL, elfFile.Sections[19].EntrySize);
            Assert.Equal(0x0000000000000000UL, elfFile.Sections[20].EntrySize);
            Assert.Equal(0x0000000000000010UL, elfFile.Sections[22].EntrySize);
            Assert.Equal(0x0000000000000000UL, elfFile.Sections[28].EntrySize);
        }

        [Fact]
        public void TestFlags()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfSectionFlags.None, elfFile.Sections[0].Flags);
            Assert.Equal(ElfSectionFlags.Alloc, elfFile.Sections[1].Flags);
            Assert.Equal(ElfSectionFlags.Alloc, elfFile.Sections[2].Flags);
            Assert.Equal(ElfSectionFlags.Alloc, elfFile.Sections[5].Flags);
            Assert.Equal(ElfSectionFlags.Alloc, elfFile.Sections[6].Flags);
            Assert.Equal(ElfSectionFlags.Alloc, elfFile.Sections[9].Flags);
            Assert.Equal(ElfSectionFlags.Alloc | ElfSectionFlags.InfoLink, elfFile.Sections[10].Flags);
            Assert.Equal(ElfSectionFlags.Alloc | ElfSectionFlags.Exec, elfFile.Sections[12].Flags);
            Assert.Equal(ElfSectionFlags.Alloc | ElfSectionFlags.Write, elfFile.Sections[19].Flags);
            Assert.Equal(ElfSectionFlags.Alloc | ElfSectionFlags.Write, elfFile.Sections[20].Flags);
            Assert.Equal(ElfSectionFlags.Alloc | ElfSectionFlags.Write, elfFile.Sections[22].Flags);
            Assert.Equal(ElfSectionFlags.None, elfFile.Sections[28].Flags);
        }

        [Fact]
        public void TestLink()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0U, elfFile.Sections[0].Link);
            Assert.Equal(0U, elfFile.Sections[1].Link);
            Assert.Equal(0U, elfFile.Sections[2].Link);
            Assert.Equal(6U, elfFile.Sections[5].Link);
            Assert.Equal(0U, elfFile.Sections[6].Link);
            Assert.Equal(5U, elfFile.Sections[9].Link);
            Assert.Equal(0U, elfFile.Sections[19].Link);
            Assert.Equal(0U, elfFile.Sections[20].Link);
            Assert.Equal(6U, elfFile.Sections[22].Link);
            Assert.Equal(0U, elfFile.Sections[28].Link);
        }

        [Fact]
        public void TestInfo()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0U, elfFile.Sections[0].Info);
            Assert.Equal(0U, elfFile.Sections[1].Info);
            Assert.Equal(0U, elfFile.Sections[2].Info);
            Assert.Equal(1U, elfFile.Sections[5].Info);
            Assert.Equal(0U, elfFile.Sections[6].Info);
            Assert.Equal(0U, elfFile.Sections[9].Info);
            Assert.Equal(24U, elfFile.Sections[10].Info);
            Assert.Equal(0U, elfFile.Sections[19].Info);
            Assert.Equal(0U, elfFile.Sections[20].Info);
            Assert.Equal(0U, elfFile.Sections[22].Info);
            Assert.Equal(0U, elfFile.Sections[28].Info);
        }

        [Fact]
        public void TestAlignment()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0UL, elfFile.Sections[0].Alignment);
            Assert.Equal(1UL, elfFile.Sections[1].Alignment);
            Assert.Equal(4UL, elfFile.Sections[2].Alignment);
            Assert.Equal(8UL, elfFile.Sections[5].Alignment);
            Assert.Equal(1UL, elfFile.Sections[6].Alignment);
            Assert.Equal(8UL, elfFile.Sections[9].Alignment);
            Assert.Equal(8UL, elfFile.Sections[10].Alignment);
            Assert.Equal(8UL, elfFile.Sections[19].Alignment);
            Assert.Equal(8UL, elfFile.Sections[20].Alignment);
            Assert.Equal(8UL, elfFile.Sections[22].Alignment);
            Assert.Equal(32UL, elfFile.Sections[25].Alignment);
            Assert.Equal(1UL, elfFile.Sections[28].Alignment);
        }
    }
}

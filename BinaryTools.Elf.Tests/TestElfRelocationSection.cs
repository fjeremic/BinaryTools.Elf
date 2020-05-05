namespace BinaryTools.Elf.Tests
{
    using System.IO;
    using BinaryTools.Elf.Io;
    using Xunit;

    public class TestElfRelocationSection
    {
        [Fact]
        public void TestCount()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfRelocationSection>(elfFile.Sections[9]);

            ElfRelocationSection relocationSection9 = elfFile.Sections[9] as ElfRelocationSection;
            Assert.Equal(8, relocationSection9.Count);

            Assert.IsAssignableFrom<ElfRelocationSection>(elfFile.Sections[10]);

            ElfRelocationSection relocationSection10 = elfFile.Sections[10] as ElfRelocationSection;
            Assert.Equal(58, relocationSection10.Count);
        }

        [Fact]
        public void TestOffset()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfRelocationSection>(elfFile.Sections[10]);

            ElfRelocationSection relocationSection = elfFile.Sections[10] as ElfRelocationSection;
            Assert.Equal(0x000000609018UL, relocationSection[0].Offset);
            Assert.Equal(0x000000609020UL, relocationSection[1].Offset);
            Assert.Equal(0x000000609028UL, relocationSection[2].Offset);
            Assert.Equal(0x000000609030UL, relocationSection[3].Offset);
            Assert.Equal(0x000000609038UL, relocationSection[4].Offset);
            Assert.Equal(0x000000609040UL, relocationSection[5].Offset);
            Assert.Equal(0x000000609048UL, relocationSection[6].Offset);
            Assert.Equal(0x000000609088UL, relocationSection[14].Offset);
            Assert.Equal(0x000000609098UL, relocationSection[16].Offset);
            Assert.Equal(0x0000006090b0UL, relocationSection[19].Offset);
            Assert.Equal(0x0000006090d0UL, relocationSection[23].Offset);
        }

        [Fact]
        public void TestInfo()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfRelocationSection>(elfFile.Sections[10]);

            ElfRelocationSection relocationSection = elfFile.Sections[10] as ElfRelocationSection;
            Assert.Equal(0x000100000007UL, relocationSection[0].Info);
            Assert.Equal(0x000200000007UL, relocationSection[1].Info);
            Assert.Equal(0x000300000007UL, relocationSection[2].Info);
            Assert.Equal(0x000400000007UL, relocationSection[3].Info);
            Assert.Equal(0x000500000007UL, relocationSection[4].Info);
            Assert.Equal(0x000600000007UL, relocationSection[5].Info);
            Assert.Equal(0x000f00000007UL, relocationSection[14].Info);
            Assert.Equal(0x001100000007UL, relocationSection[16].Info);
            Assert.Equal(0x001400000007UL, relocationSection[19].Info);
            Assert.Equal(0x001800000007UL, relocationSection[23].Info);
        }

        [Fact]
        public void TestType()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfRelocationSection>(elfFile.Sections[10]);

            ElfRelocationSection relocationSection = elfFile.Sections[10] as ElfRelocationSection;
            Assert.Equal(ElfRelocationSection.R_X86_64_JUMP_SLOT, relocationSection[0].Type);
            Assert.Equal(ElfRelocationSection.R_X86_64_JUMP_SLOT, relocationSection[1].Type);
            Assert.Equal(ElfRelocationSection.R_X86_64_JUMP_SLOT, relocationSection[2].Type);
            Assert.Equal(ElfRelocationSection.R_X86_64_JUMP_SLOT, relocationSection[3].Type);
            Assert.Equal(ElfRelocationSection.R_X86_64_JUMP_SLOT, relocationSection[4].Type);
            Assert.Equal(ElfRelocationSection.R_X86_64_JUMP_SLOT, relocationSection[5].Type);
            Assert.Equal(ElfRelocationSection.R_X86_64_JUMP_SLOT, relocationSection[14].Type);
            Assert.Equal(ElfRelocationSection.R_X86_64_JUMP_SLOT, relocationSection[16].Type);
            Assert.Equal(ElfRelocationSection.R_X86_64_JUMP_SLOT, relocationSection[19].Type);
            Assert.Equal(ElfRelocationSection.R_X86_64_JUMP_SLOT, relocationSection[23].Type);
        }

        [Fact]
        public void TestAddend()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfRelocationSection>(elfFile.Sections[10]);

            ElfRelocationSection relocationSection = elfFile.Sections[10] as ElfRelocationSection;
            Assert.Equal(0UL, relocationSection[0].Addend);
            Assert.Equal(0UL, relocationSection[1].Addend);
            Assert.Equal(0UL, relocationSection[2].Addend);
            Assert.Equal(0UL, relocationSection[3].Addend);
            Assert.Equal(0UL, relocationSection[4].Addend);
            Assert.Equal(0UL, relocationSection[5].Addend);
            Assert.Equal(0UL, relocationSection[14].Addend);
            Assert.Equal(0UL, relocationSection[16].Addend);
            Assert.Equal(0UL, relocationSection[19].Addend);
            Assert.Equal(0UL, relocationSection[23].Addend);
        }

        [Fact]
        public void TestSymbol()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfRelocationSection>(elfFile.Sections[10]);

            ElfRelocationSection relocationSection = elfFile.Sections[10] as ElfRelocationSection;
            Assert.Equal("__uflow", relocationSection[0].Symbol);
            Assert.Equal("getenv", relocationSection[1].Symbol);
            Assert.Equal("free", relocationSection[2].Symbol);
            Assert.Equal("abort", relocationSection[3].Symbol);
            Assert.Equal("__errno_location", relocationSection[4].Symbol);
            Assert.Equal("strncmp", relocationSection[5].Symbol);
            Assert.Equal("strlen", relocationSection[14].Symbol);
            Assert.Equal("getopt_long", relocationSection[16].Symbol);
            Assert.Equal("__overflow", relocationSection[19].Symbol);
            Assert.Equal("__strtoul_internal", relocationSection[23].Symbol);
        }

        [Fact]
        public void TestSymbolIndex()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfRelocationSection>(elfFile.Sections[10]);

            ElfRelocationSection relocationSection = elfFile.Sections[10] as ElfRelocationSection;
            Assert.Equal(0x0001, relocationSection[0].SymbolIndex);
            Assert.Equal(0x0002, relocationSection[1].SymbolIndex);
            Assert.Equal(0x0003, relocationSection[2].SymbolIndex);
            Assert.Equal(0x0004, relocationSection[3].SymbolIndex);
            Assert.Equal(0x0005, relocationSection[4].SymbolIndex);
            Assert.Equal(0x0006, relocationSection[5].SymbolIndex);
            Assert.Equal(0x000f, relocationSection[14].SymbolIndex);
            Assert.Equal(0x0011, relocationSection[16].SymbolIndex);
            Assert.Equal(0x0014, relocationSection[19].SymbolIndex);
            Assert.Equal(0x0018, relocationSection[23].SymbolIndex);
        }

        [Fact]
        public void TestSymbolValue()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfRelocationSection>(elfFile.Sections[9]);

            ElfRelocationSection relocationSection9 = elfFile.Sections[9] as ElfRelocationSection;
            Assert.Equal(0x0000000000000000UL, relocationSection9[0].SymbolValue);
            Assert.Equal(0x0000000000609280UL, relocationSection9[1].SymbolValue);
            Assert.Equal(0x0000000000609288UL, relocationSection9[2].SymbolValue);
            Assert.Equal(0x0000000000609290UL, relocationSection9[3].SymbolValue);
            Assert.Equal(0x0000000000609298UL, relocationSection9[4].SymbolValue);
            Assert.Equal(0x00000000006092a0UL, relocationSection9[5].SymbolValue);
            Assert.Equal(0x00000000006092a8UL, relocationSection9[6].SymbolValue);
            Assert.Equal(0x00000000006092c0UL, relocationSection9[7].SymbolValue);

            Assert.IsAssignableFrom<ElfRelocationSection>(elfFile.Sections[10]);

            ElfRelocationSection relocationSection10 = elfFile.Sections[10] as ElfRelocationSection;
            Assert.Equal(0x0UL, relocationSection10[0].SymbolValue);
            Assert.Equal(0x0UL, relocationSection10[1].SymbolValue);
            Assert.Equal(0x0UL, relocationSection10[2].SymbolValue);
            Assert.Equal(0x0UL, relocationSection10[3].SymbolValue);
            Assert.Equal(0x0UL, relocationSection10[4].SymbolValue);
            Assert.Equal(0x0UL, relocationSection10[5].SymbolValue);
            Assert.Equal(0x0UL, relocationSection10[14].SymbolValue);
            Assert.Equal(0x0UL, relocationSection10[16].SymbolValue);
            Assert.Equal(0x0UL, relocationSection10[19].SymbolValue);
            Assert.Equal(0x0UL, relocationSection10[23].SymbolValue);
        }
    }
}
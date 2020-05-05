namespace BinaryTools.Elf.Tests
{
    using System.IO;
    using BinaryTools.Elf.Io;
    using Xunit;

    public class TestElfSymbolTable
    {
        [Fact]
        public void TestCount()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfSymbolTable>(elfFile.Sections[5]);

            ElfSymbolTable symbolTable = elfFile.Sections[5] as ElfSymbolTable;
            Assert.Equal(69, symbolTable.Count);
        }

        [Fact]
        public void TestName()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfSymbolTable>(elfFile.Sections[5]);

            ElfSymbolTable symbolTable = elfFile.Sections[5] as ElfSymbolTable;
            Assert.Equal(string.Empty, symbolTable[0].Name);
            Assert.Equal("__uflow", symbolTable[1].Name);
            Assert.Equal("getenv", symbolTable[2].Name);
            Assert.Equal("free", symbolTable[3].Name);
            Assert.Equal("abort", symbolTable[4].Name);
            Assert.Equal("__errno_location", symbolTable[5].Name);
            Assert.Equal("__ctype_get_mb_cur_max", symbolTable[14].Name);
            Assert.Equal("__stack_chk_fail", symbolTable[16].Name);
            Assert.Equal("strchr", symbolTable[19].Name);
            Assert.Equal("__assert_fail", symbolTable[23].Name);
            Assert.Equal("__gmon_start__", symbolTable[35].Name);
            Assert.Equal("stdout", symbolTable[60].Name);
            Assert.Equal("program_invocation_short_name", symbolTable[65].Name);
            Assert.Equal("optind", symbolTable[67].Name);
        }

        [Fact]
        public void TestNameIndex()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfSymbolTable>(elfFile.Sections[5]);

            ElfSymbolTable symbolTable = elfFile.Sections[5] as ElfSymbolTable;
            Assert.Equal(0x000U, symbolTable[0].NameIndex);
            Assert.Equal(0x15fU, symbolTable[1].NameIndex);
            Assert.Equal(0x181U, symbolTable[2].NameIndex);
            Assert.Equal(0x26dU, symbolTable[3].NameIndex);
            Assert.Equal(0x080U, symbolTable[4].NameIndex);
            Assert.Equal(0x10fU, symbolTable[5].NameIndex);
            Assert.Equal(0x0bfU, symbolTable[14].NameIndex);
            Assert.Equal(0x05eU, symbolTable[16].NameIndex);
            Assert.Equal(0x1cdU, symbolTable[19].NameIndex);
            Assert.Equal(0x0b1U, symbolTable[23].NameIndex);
            Assert.Equal(0x29aU, symbolTable[35].NameIndex);
            Assert.Equal(0x135U, symbolTable[60].NameIndex);
            Assert.Equal(0x1d4U, symbolTable[65].NameIndex);
            Assert.Equal(0x03fU, symbolTable[67].NameIndex);
        }

        [Fact]
        public void TestBinding()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfSymbolTable>(elfFile.Sections[5]);

            ElfSymbolTable symbolTable = elfFile.Sections[5] as ElfSymbolTable;
            Assert.Equal(ElfSymbolBinding.Local, symbolTable[0].Binding);
            Assert.Equal(ElfSymbolBinding.Global, symbolTable[1].Binding);
            Assert.Equal(ElfSymbolBinding.Global, symbolTable[2].Binding);
            Assert.Equal(ElfSymbolBinding.Global, symbolTable[3].Binding);
            Assert.Equal(ElfSymbolBinding.Global, symbolTable[4].Binding);
            Assert.Equal(ElfSymbolBinding.Global, symbolTable[5].Binding);
            Assert.Equal(ElfSymbolBinding.Global, symbolTable[14].Binding);
            Assert.Equal(ElfSymbolBinding.Global, symbolTable[16].Binding);
            Assert.Equal(ElfSymbolBinding.Global, symbolTable[19].Binding);
            Assert.Equal(ElfSymbolBinding.Global, symbolTable[23].Binding);
            Assert.Equal(ElfSymbolBinding.Weak, symbolTable[35].Binding);
            Assert.Equal(ElfSymbolBinding.Global, symbolTable[60].Binding);
            Assert.Equal(ElfSymbolBinding.Weak, symbolTable[65].Binding);
            Assert.Equal(ElfSymbolBinding.Global, symbolTable[67].Binding);
        }

        [Fact]
        public void TestType()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfSymbolTable>(elfFile.Sections[5]);

            ElfSymbolTable symbolTable = elfFile.Sections[5] as ElfSymbolTable;
            Assert.Equal(ElfSymbolType.NoType, symbolTable[0].Type);
            Assert.Equal(ElfSymbolType.Func, symbolTable[1].Type);
            Assert.Equal(ElfSymbolType.Func, symbolTable[2].Type);
            Assert.Equal(ElfSymbolType.Func, symbolTable[3].Type);
            Assert.Equal(ElfSymbolType.Func, symbolTable[4].Type);
            Assert.Equal(ElfSymbolType.Func, symbolTable[5].Type);
            Assert.Equal(ElfSymbolType.Func, symbolTable[14].Type);
            Assert.Equal(ElfSymbolType.Func, symbolTable[16].Type);
            Assert.Equal(ElfSymbolType.Func, symbolTable[19].Type);
            Assert.Equal(ElfSymbolType.Func, symbolTable[23].Type);
            Assert.Equal(ElfSymbolType.NoType, symbolTable[35].Type);
            Assert.Equal(ElfSymbolType.Object, symbolTable[60].Type);
            Assert.Equal(ElfSymbolType.Object, symbolTable[65].Type);
            Assert.Equal(ElfSymbolType.Object, symbolTable[67].Type);
        }

        [Fact]
        public void TestVisibility()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfSymbolTable>(elfFile.Sections[5]);

            ElfSymbolTable symbolTable = elfFile.Sections[5] as ElfSymbolTable;
            Assert.Equal(ElfSymbolVisibility.Default, symbolTable[0].Visibility);
            Assert.Equal(ElfSymbolVisibility.Default, symbolTable[1].Visibility);
            Assert.Equal(ElfSymbolVisibility.Default, symbolTable[2].Visibility);
            Assert.Equal(ElfSymbolVisibility.Default, symbolTable[3].Visibility);
            Assert.Equal(ElfSymbolVisibility.Default, symbolTable[4].Visibility);
            Assert.Equal(ElfSymbolVisibility.Default, symbolTable[5].Visibility);
            Assert.Equal(ElfSymbolVisibility.Default, symbolTable[14].Visibility);
            Assert.Equal(ElfSymbolVisibility.Default, symbolTable[16].Visibility);
            Assert.Equal(ElfSymbolVisibility.Default, symbolTable[19].Visibility);
            Assert.Equal(ElfSymbolVisibility.Default, symbolTable[23].Visibility);
            Assert.Equal(ElfSymbolVisibility.Default, symbolTable[35].Visibility);
            Assert.Equal(ElfSymbolVisibility.Default, symbolTable[60].Visibility);
            Assert.Equal(ElfSymbolVisibility.Default, symbolTable[65].Visibility);
            Assert.Equal(ElfSymbolVisibility.Default, symbolTable[67].Visibility);
        }

        [Fact]
        public void TestShIndex()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfSymbolTable>(elfFile.Sections[5]);

            ElfSymbolTable symbolTable = elfFile.Sections[5] as ElfSymbolTable;
            Assert.Equal(0, symbolTable[0].ShIndex);
            Assert.Equal(0, symbolTable[1].ShIndex);
            Assert.Equal(0, symbolTable[2].ShIndex);
            Assert.Equal(0, symbolTable[3].ShIndex);
            Assert.Equal(0, symbolTable[4].ShIndex);
            Assert.Equal(0, symbolTable[5].ShIndex);
            Assert.Equal(0, symbolTable[14].ShIndex);
            Assert.Equal(0, symbolTable[16].ShIndex);
            Assert.Equal(0, symbolTable[19].ShIndex);
            Assert.Equal(0, symbolTable[23].ShIndex);
            Assert.Equal(0, symbolTable[35].ShIndex);
            Assert.Equal(26, symbolTable[60].ShIndex);
            Assert.Equal(26, symbolTable[65].ShIndex);
            Assert.Equal(26, symbolTable[67].ShIndex);
        }

        [Fact]
        public void TestSymbolValue()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfSymbolTable>(elfFile.Sections[5]);

            ElfSymbolTable symbolTable = elfFile.Sections[5] as ElfSymbolTable;
            Assert.Equal(0x0000000000000000UL, symbolTable[0].Value);
            Assert.Equal(0x0000000000000000UL, symbolTable[1].Value);
            Assert.Equal(0x0000000000000000UL, symbolTable[2].Value);
            Assert.Equal(0x0000000000000000UL, symbolTable[3].Value);
            Assert.Equal(0x0000000000000000UL, symbolTable[4].Value);
            Assert.Equal(0x0000000000000000UL, symbolTable[5].Value);
            Assert.Equal(0x0000000000000000UL, symbolTable[14].Value);
            Assert.Equal(0x0000000000000000UL, symbolTable[16].Value);
            Assert.Equal(0x0000000000000000UL, symbolTable[19].Value);
            Assert.Equal(0x0000000000000000UL, symbolTable[23].Value);
            Assert.Equal(0x0000000000000000UL, symbolTable[35].Value);
            Assert.Equal(0x0000000000609288UL, symbolTable[60].Value);
            Assert.Equal(0x0000000000609280UL, symbolTable[65].Value);
            Assert.Equal(0x0000000000609298UL, symbolTable[67].Value);
        }

        [Fact]
        public void TestSize()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfSymbolTable>(elfFile.Sections[5]);

            ElfSymbolTable symbolTable = elfFile.Sections[5] as ElfSymbolTable;
            Assert.Equal(0UL, symbolTable[0].Size);
            Assert.Equal(0UL, symbolTable[1].Size);
            Assert.Equal(0UL, symbolTable[2].Size);
            Assert.Equal(0UL, symbolTable[3].Size);
            Assert.Equal(0UL, symbolTable[4].Size);
            Assert.Equal(0UL, symbolTable[5].Size);
            Assert.Equal(0UL, symbolTable[14].Size);
            Assert.Equal(0UL, symbolTable[16].Size);
            Assert.Equal(0UL, symbolTable[19].Size);
            Assert.Equal(0UL, symbolTable[23].Size);
            Assert.Equal(0UL, symbolTable[35].Size);
            Assert.Equal(8UL, symbolTable[60].Size);
            Assert.Equal(8UL, symbolTable[65].Size);
            Assert.Equal(4UL, symbolTable[67].Size);
        }
    }
}
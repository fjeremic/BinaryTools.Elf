namespace BinaryTools.Elf.Tests
{
    using System.IO;
    using BinaryTools.Elf.Io;
    using Xunit;

    public class TestElfHeader
    {
        [Fact]
        public void TestClass32()
        {
            var stream = new FileStream("Binaries/helloworld32le", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfClass.Elf32, elfFile.Header.Class);
        }

        [Fact]
        public void TestClass64()
        {
            var stream = new FileStream("Binaries/helloworld64le", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfClass.Elf64, elfFile.Header.Class);
        }

        [Fact]
        public void TestEndiannessLE()
        {
            var stream = new FileStream("Binaries/helloworld64le", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfData.Lsb, elfFile.Header.Data);
        }

        [Fact]
        public void TestEndiannessBE()
        {
            var stream = new FileStream("Binaries/helloworld64be", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfData.Msb, elfFile.Header.Data);
        }

        [Fact]
        public void TestOSABI()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfOSABI.None, elfFile.Header.OSABI);
        }

        [Fact]
        public void TestOSABIVersion()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0, elfFile.Header.OSABIVersion);
        }

        [Fact]
        public void TestFlags()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0U, elfFile.Header.Flags);
        }

        [Fact]
        public void TestType()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfType.Executable, elfFile.Header.Type);
        }

        [Fact]
        public void TestMachineX8664()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfMachine.X8664, elfFile.Header.Machine);
        }

        [Fact]
        public void TestMachineI386()
        {
            var stream = new FileStream("Binaries/helloworld32le", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfMachine.I386, elfFile.Header.Machine);
        }

        [Fact]
        public void TestMachineS390()
        {
            var stream = new FileStream("Binaries/helloworld64be", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfMachine.S390, elfFile.Header.Machine);
        }

        [Fact]
        public void TestVersion()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(1U, elfFile.Header.Version);
        }

        [Fact]
        public void TestEntryOffset()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0x4019e0UL, elfFile.Header.EntryOffset);
        }

        [Fact]
        public void TestSectionHeaderOffset()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(37808UL, elfFile.Header.SectionHeaderOffset);
        }

        [Fact]
        public void TestSectionHeaderSize()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(64, elfFile.Header.SectionHeaderSize);
        }

        [Fact]
        public void TestSectionHeaderEntryCount()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(29, elfFile.Header.SectionHeaderEntryCount);
        }

        [Fact]
        public void TestProgramHeaderOffset()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(64UL, elfFile.Header.ProgramHeaderOffset);
        }

        [Fact]
        public void TestProgramHeaderSize()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(56, elfFile.Header.ProgramHeaderSize);
        }

        [Fact]
        public void TestProgramHeaderEntryCount()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(9, elfFile.Header.ProgramHeaderEntryCount);
        }

        [Fact]
        public void TestStringSectionIndex()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(28, elfFile.Header.StringSectionIndex);
        }
    }
}

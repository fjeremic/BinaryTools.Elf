using BinaryTools.Elf.Io;
using System.IO;
using Xunit;

namespace BinaryTools.Elf.Tests
{
    public class TestElfHeader
    {
        [Fact]
        public void CorrectEntryOffset()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0x00000000004019e0UL, elfFile.Header.EntryOffset);
        }

        [Fact]
        public void CorrectClass32()
        {
            var stream = new FileStream("Binaries/helloworld32le", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfHeader.ELFCLASS32, elfFile.Header.Class);
        }

        [Fact]
        public void CorrectClass64()
        {
            var stream = new FileStream("Binaries/helloworld64le", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfHeader.ELFCLASS64, elfFile.Header.Class);
        }

        [Fact]
        public void CorrectEndiannessLE()
        {
            var stream = new FileStream("Binaries/helloworld64le", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfHeader.ELFDATA2LSB, elfFile.Header.Data);
        }

        [Fact]
        public void CorrectEndiannessBE()
        {
            var stream = new FileStream("Binaries/helloworld64be", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfHeader.ELFDATA2MSB, elfFile.Header.Data);
        }

        [Fact]
        public void CorrectOSABI()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfOSABI.None, elfFile.Header.OSABI);
        }

        [Fact]
        public void CorrectOSABIVersion()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0, elfFile.Header.OSABIVersion);
        }

        [Fact]
        public void CorrectFlags()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0U, elfFile.Header.Flags);
        }
    }
}

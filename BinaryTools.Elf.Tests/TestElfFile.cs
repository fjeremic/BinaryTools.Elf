namespace BinaryTools.Elf.Tests
{
    using System;
    using System.IO;
    using BinaryTools.Elf.Io;
    using Xunit;

    public class TestElfFile
    {
        [Fact]
        public void TestFileExists()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            _ = ElfFile.ReadElfFile(reader);
        }

        [Fact]
        public void TestClosedStream()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            stream.Close();

            void Action() => new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            Assert.Throws<ArgumentException>(Action);
        }

        [Fact]
        public void TestNativeEnidanness()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            Assert.Equal(reader.Endianness, EndianBitConverter.NativeEndianness);
        }

        [Fact]
        public void TestInvalidMagicBytes()
        {
            var stream = new FileStream("Binaries/invalidmagicbytes", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            void Action() => ElfFile.ReadElfFile(reader);

            Assert.Throws<FileFormatException>(Action);
        }

        [Fact]
        public void TestInvalidClass()
        {
            var stream = new FileStream("Binaries/invalidclass", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            void Action() => ElfFile.ReadElfFile(reader);

            Assert.Throws<FileFormatException>(Action);
        }

        [Fact]
        public void TestInvalidEndianness()
        {
            var stream = new FileStream("Binaries/invalidendianness", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            void Action() => ElfFile.ReadElfFile(reader);

            Assert.Throws<FileFormatException>(Action);
        }
    }
}

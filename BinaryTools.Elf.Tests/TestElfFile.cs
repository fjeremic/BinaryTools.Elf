using BinaryTools.Elf.Io;
using System;
using System.IO;
using Xunit;

namespace BinaryTools.Elf.Tests
{
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

            void action() => new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            Assert.Throws<ArgumentException>(action);
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
            void action() => ElfFile.ReadElfFile(reader);

            Assert.Throws<FileFormatException>(action);
        }

        [Fact]
        public void TestInvalidClass()
        {
            var stream = new FileStream("Binaries/invalidclass", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            void action() => ElfFile.ReadElfFile(reader);

            Assert.Throws<FileFormatException>(action);
        }

        [Fact]
        public void TestInvalidEndianness()
        {
            var stream = new FileStream("Binaries/invalidendianness", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            void action() => ElfFile.ReadElfFile(reader);

            Assert.Throws<FileFormatException>(action);
        }
    }
}

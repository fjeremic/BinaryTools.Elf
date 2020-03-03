﻿using BinaryTools.Elf.Io;
using System.IO;
using Xunit;

namespace BinaryTools.Elf.Tests
{
    public class TestElfHeader
    {
        [Fact]
        public void CorrectClass32()
        {
            var stream = new FileStream("Binaries/helloworld32le", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfClass.Elf32, elfFile.Header.Class);
        }

        [Fact]
        public void CorrectClass64()
        {
            var stream = new FileStream("Binaries/helloworld64le", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfClass.Elf64, elfFile.Header.Class);
        }

        [Fact]
        public void CorrectEndiannessLE()
        {
            var stream = new FileStream("Binaries/helloworld64le", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfData.Lsb, elfFile.Header.Data);
        }

        [Fact]
        public void CorrectEndiannessBE()
        {
            var stream = new FileStream("Binaries/helloworld64be", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfData.Msb, elfFile.Header.Data);
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

        [Fact]
        public void CorrectType()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfType.Executable, elfFile.Header.Type);
        }

        [Fact]
        public void CorrectMachineX8664()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfMachine.X8664, elfFile.Header.Machine);
        }

        [Fact]
        public void CorrectMachineI386()
        {
            var stream = new FileStream("Binaries/helloworld32le", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfMachine.I386, elfFile.Header.Machine);
        }

        [Fact]
        public void CorrectMachineS390()
        {
            var stream = new FileStream("Binaries/helloworld64be", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(ElfMachine.S390, elfFile.Header.Machine);
        }

        [Fact]
        public void CorrectVersion()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(1U, elfFile.Header.Version);
        }

        [Fact]
        public void CorrectEntryOffset()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(0x4019e0UL, elfFile.Header.EntryOffset);
        }

        [Fact]
        public void CorrectSectionHeaderOffset()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(37808UL, elfFile.Header.SectionHeaderOffset);
        }

        [Fact]
        public void CorrectSectionHeaderSize()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(64, elfFile.Header.SectionHeaderSize);
        }

        [Fact]
        public void CorrectSectionHeaderEntryCount()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(29, elfFile.Header.SectionHeaderEntryCount);
        }

        [Fact]
        public void CorrectProgramHeaderOffset()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(64UL, elfFile.Header.ProgramHeaderOffset);
        }

        [Fact]
        public void CorrectProgramHeaderSize()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(56, elfFile.Header.ProgramHeaderSize);
        }

        [Fact]
        public void CorrectProgramHeaderEntryCount()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(9, elfFile.Header.ProgramHeaderEntryCount);
        }

        [Fact]
        public void CorrectStringSectionIndex()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.Equal(28, elfFile.Header.StringSectionIndex);
        }
    }
}

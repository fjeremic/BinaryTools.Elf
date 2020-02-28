using BinaryTools.Elf.Io;
using System.IO;
using Xunit;

namespace BinaryTools.Elf.Tests
{
    public class TestElfStringTable
    {
        [Fact]
        public void TestCount()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfStringTable>(elfFile.Sections[6]);

            ElfStringTable symbolTable = elfFile.Sections[6] as ElfStringTable;
            Assert.Equal(71, symbolTable.Count);
        }

        [Fact]
        public void TestValue()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfStringTable>(elfFile.Sections[6]);

            ElfStringTable symbolTable = elfFile.Sections[6] as ElfStringTable;
            Assert.Equal("libc.so.6", symbolTable[0].Value);
            Assert.Equal("fflush", symbolTable[1].Value);
            Assert.Equal("__printf_chk", symbolTable[2].Value);
            Assert.Equal("setlocale", symbolTable[3].Value);
            Assert.Equal("mbrtowc", symbolTable[4].Value);
            Assert.Equal("realloc", symbolTable[13].Value);
            Assert.Equal("stdin", symbolTable[15].Value);
            Assert.Equal("program_invocation_name", symbolTable[18].Value);
            Assert.Equal("calloc", symbolTable[22].Value);
            Assert.Equal("malloc", symbolTable[34].Value);
            Assert.Equal("fputs_unlocked", symbolTable[59].Value);
            Assert.Equal("__gmon_start__", symbolTable[64].Value);
            Assert.Equal("GLIBC_2.3.4", symbolTable[66].Value);
        }

        [Fact]
        public void TestIndex()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfStringTable>(elfFile.Sections[6]);

            ElfStringTable symbolTable = elfFile.Sections[6] as ElfStringTable;
            Assert.Equal(0x001U, symbolTable[0].Index);
            Assert.Equal(0x00bU, symbolTable[1].Index);
            Assert.Equal(0x012U, symbolTable[2].Index);
            Assert.Equal(0x01fU, symbolTable[3].Index);
            Assert.Equal(0x029U, symbolTable[4].Index);
            Assert.Equal(0x078U, symbolTable[13].Index);
            Assert.Equal(0x086U, symbolTable[15].Index);
            Assert.Equal(0x099U, symbolTable[18].Index);
            Assert.Equal(0x0e4U, symbolTable[22].Index);
            Assert.Equal(0x150U, symbolTable[34].Index);
            Assert.Equal(0x25eU, symbolTable[59].Index);
            Assert.Equal(0x29aU, symbolTable[64].Index);
            Assert.Equal(0x2b3U, symbolTable[66].Index);
        }
    }
}
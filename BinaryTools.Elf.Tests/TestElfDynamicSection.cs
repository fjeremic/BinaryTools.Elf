namespace BinaryTools.Elf.Tests
{
    using System.IO;
    using BinaryTools.Elf.Io;
    using Xunit;

    public class TestElfDynamicSection
    {
        [Fact]
        public void TestCount()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfDynamicSection>(elfFile.Sections[22]);

            ElfDynamicSection dynamicSection = elfFile.Sections[22] as ElfDynamicSection;
            Assert.Equal(24, dynamicSection.Count);
        }

        [Fact]
        public void TestTag()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfDynamicSection>(elfFile.Sections[22]);

            ElfDynamicSection dynamicSection = elfFile.Sections[22] as ElfDynamicSection;
            Assert.Equal(ElfDynamicArrayTag.Needed, dynamicSection[0].Tag);
            Assert.Equal(ElfDynamicArrayTag.Init, dynamicSection[1].Tag);
            Assert.Equal(ElfDynamicArrayTag.Fini, dynamicSection[2].Tag);
            Assert.Equal(ElfDynamicArrayTag.InitArray, dynamicSection[3].Tag);
            Assert.Equal(ElfDynamicArrayTag.InitArraySz, dynamicSection[4].Tag);
            Assert.Equal(ElfDynamicArrayTag.FiniArray, dynamicSection[5].Tag);
            Assert.Equal(ElfDynamicArrayTag.FiniArraySz, dynamicSection[6].Tag);
            Assert.Equal(ElfDynamicArrayTag.PltRelSz, dynamicSection[14].Tag);
            Assert.Equal(ElfDynamicArrayTag.JmpRel, dynamicSection[16].Tag);
            Assert.Equal(ElfDynamicArrayTag.RelAEnt, dynamicSection[19].Tag);
            Assert.Equal(ElfDynamicArrayTag.Null, dynamicSection[23].Tag);
        }

        [Fact]
        public void TestValue()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfDynamicSection>(elfFile.Sections[22]);

            ElfDynamicSection dynamicSection = elfFile.Sections[22] as ElfDynamicSection;
            Assert.Equal(0x401358UL, dynamicSection[1].Value);
            Assert.Equal(0x405bccUL, dynamicSection[2].Value);
            Assert.Equal(0x608e10UL, dynamicSection[3].Value);
            Assert.Equal(8UL, dynamicSection[4].Value);
            Assert.Equal(0x608e18UL, dynamicSection[5].Value);
            Assert.Equal(8UL, dynamicSection[6].Value);
            Assert.Equal(1392UL, dynamicSection[14].Value);
            Assert.Equal(0x400de8UL, dynamicSection[16].Value);
            Assert.Equal(24UL, dynamicSection[19].Value);
            Assert.Equal(0x0UL, dynamicSection[23].Value);
        }

        [Fact]
        public void TestName()
        {
            var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            Assert.IsAssignableFrom<ElfDynamicSection>(elfFile.Sections[22]);

            ElfDynamicSection dynamicSection = elfFile.Sections[22] as ElfDynamicSection;
            Assert.Equal("libc.so.6", dynamicSection[0].Name);
            Assert.Equal(string.Empty, dynamicSection[1].Name);
        }
    }
}

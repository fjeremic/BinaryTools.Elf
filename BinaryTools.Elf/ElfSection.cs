using System;

namespace BinaryTools.Elf
{
    /// <summary>
    /// Represents an ELF section.
    /// </summary>
    public abstract class ElfSection
    {
        /// <summary>
        /// Gets the index value of a section representing an undefined section.
        /// </summary>
        public const UInt16 SHN_UNDEF = 0x0000;

        /// <summary>
        /// Gets the index value of a section representing the lower bound of the range of reserved indexes.
        /// </summary>
        public const UInt16 SHN_LORESERVE = 0xFF00;

        /// <summary>
        /// Gets the index value of a section representing the upper bound of the range of reserved indexes.
        /// </summary>
        public const UInt16 SHN_HIRESERVE = 0xFFFF;

        /// <summary>
        /// Gets the index value of a section representing the lower bound of the indices reserved for processor specific semantics.
        /// </summary>
        public const UInt16 SHN_LOPROC = 0xFF00;

        /// <summary>
        /// Gets the index value of a section representing the upper bound of the indices reserved for processor specific semantics.
        /// </summary>
        public const UInt16 SHN_HIPROC = 0xFF1F;

        /// <summary>
        /// Gets the index value of a section representing the absolute values for the corresponding reference.
        /// </summary>
        public const UInt16 SHN_ABS = 0xFFF1;

        /// <summary>
        /// Gets the index value of a section representing that the symbols are defined relative to this section are common symbols.
        /// </summary>
        public const UInt16 SHN_COMMON = 0xFFF2;

        /// <summary>
        /// Gets the type value of a section representing an inactive section.
        /// </summary>
        public const UInt32 SHT_NULL = 0x00000000;

        /// <summary>
        /// Gets the type value of a section representing information defined by the program.
        /// </summary>
        public const UInt32 SHT_PROGBITS = 0x00000001;

        /// <summary>
        /// Gets the type value of a section representing a symbol table.
        /// </summary>
        public const UInt32 SHT_SYMTAB = 0x00000002;

        /// <summary>
        /// Gets the type value of a section representing a string table.
        /// </summary>
        public const UInt32 SHT_STRTAB = 0x00000003;

        /// <summary>
        /// Gets the type value of a section representing relIBM.OMR.CoreAnalyzer.ion entries.
        /// </summary>
        public const UInt32 SHT_RELA = 0x00000004;

        /// <summary>
        /// Gets the type value of a section representing a symbol hash table.
        /// </summary>
        public const UInt32 SHT_HASH = 0x00000005;

        /// <summary>
        /// Gets the type value of a section representing dynamic linking information.
        /// </summary>
        public const UInt32 SHT_DYN = 0x00000006;

        /// <summary>
        /// Gets the type value of a section representing auxiliary information.
        /// </summary>
        public const UInt32 SHT_NOTE = 0x00000007;

        /// <summary>
        /// Gets the type value of a section representing that the section occupies no space in the file.
        /// </summary>
        public const UInt32 SHT_NOBITS = 0x00000008;

        /// <summary>
        /// Gets the type value of a section representing relIBM.OMR.CoreAnalyzer.ion entires.
        /// </summary>
        public const UInt32 SHT_REL = 0x00000009;

        /// <summary>
        /// Gets the type value of a section representing unspecified semantics.
        /// </summary>
        public const UInt32 SHT_SHLIB = 0x0000000A;

        /// <summary>
        /// Gets the type value of a section representing a symbol table.
        /// </summary>
        public const UInt32 SHT_DYNSYM = 0x0000000B;

        /// <summary>
        /// Gets the type value of a section representing the lower bound of a section holding OS specific semantics.
        /// </summary>
        public const UInt32 SHT_LOOS = 0x60000000;

        /// <summary>
        /// Gets the type value of a section representing the upper bound of a section holding OS specific semantics.
        /// </summary>
        public const UInt32 SHT_HIOS = 0x6FFFFFFF;

        /// <summary>
        /// Gets the type value of a section representing the lower bound of a section holding processor specific semantics.
        /// </summary>
        public const UInt32 SHT_LOPROC = 0x70000000;

        /// <summary>
        /// Gets the type value of a section representing the upper bound of a section holding processor specific semantics.
        /// </summary>
        public const UInt32 SHT_HIPROC = 0x7FFFFFFF;

        /// <summary>
        /// Gets the type value of a section representing the lower bound of a section holding application specific semantics.
        /// </summary>
        public const UInt32 SHT_LOUSER = 0x80000000;

        /// <summary>
        /// Gets the type value of a section representing the upper bound of a section holding application specific semantics.
        /// </summary>
        public const UInt32 SHT_HIUSER = 0xFFFFFFFF;

        /// <summary>
        /// Gets the name of this section.
        /// </summary>
        public String Name
        {
            get; internal set;
        }

        /// <summary>
        /// Gets the offset in the string table of the name of this section.
        /// </summary>
        public UInt32 NameOffset
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the size in number of bytes of this section.
        /// </summary>
        public UInt64 Size
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the size of the fixed-sized entries of this section.
        /// </summary>
        public UInt64 EntrySize
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the offset from the beginning of the ELF file the first byte in this section.
        /// </summary>
        public UInt64 Offset
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the address of this section.
        /// </summary>
        public UInt64 Address
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the address alignment of this section.
        /// </summary>
        public UInt64 Alignment
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the type of this section.
        /// </summary>
        public UInt32 Type
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the flags of this section.
        /// </summary>
        public UInt64 Flags
        {
            get; protected set;
        }

        /// <summary>
        /// Gets a section header table index link whose interpretation depends on the section type.
        /// </summary>
        public UInt32 Link
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the extra information whose interpretation depends on the section type.
        /// </summary>
        public UInt32 Info
        {
            get; protected set;
        }
    }
}

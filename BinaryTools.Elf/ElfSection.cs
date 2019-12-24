using System;

namespace BinaryTools.Elf
{
    /// <summary>
    /// Represents an ELF section.
    /// </summary>
    public abstract class ElfSection
    {
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
        public ElfSectionType Type
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the flags of this section.
        /// </summary>
        public ElfSectionFlags Flags
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

﻿using System;

namespace BinaryTools.Elf
{
    /// <summary>
    /// Represents an ELF segment.
    /// </summary>
    public abstract class ElfSegment
    {
        /// <summary>
        /// Gets the type value of a segment that is unused.
        /// </summary>
        public const UInt32 PT_NULL = 0x00000000;

        /// <summary>
        /// Gets the type value of a segment representing a loadable segment.
        /// </summary>
        public const UInt32 PT_LOAD = 0x00000001;

        /// <summary>
        /// Gets the type value of a segment representing dynamic linking information.
        /// </summary>
        public const UInt32 PT_DYNAMIC = 0x00000002;

        /// <summary>
        /// Gets the type value of a segment representing the lIBM.OMR.CoreAnalyzer.ion and size of a null-terminated path name to invoke as an interpreter.
        /// </summary>
        public const UInt32 PT_INTERP = 0x00000003;

        /// <summary>
        /// Gets the type value of a segment representing the lIBM.OMR.CoreAnalyzer.ion and size of auxiliary information.
        /// </summary>
        public const UInt32 PT_NOTE = 0x00000004;

        /// <summary>
        /// Gets the type value of a segment with unspecified semantics.
        /// </summary>
        public const UInt32 PT_SHLIB = 0x00000005;

        /// <summary>
        /// Gets the type value of a segment representing the lIBM.OMR.CoreAnalyzer.ion and size of the program header table itself.
        /// </summary>
        public const UInt32 PT_PHDR = 0x00000006;

        /// <summary>
        /// Gets the type value representing the lower bound of a segment holding processor specific semantics.
        /// </summary>
        public const UInt32 PT_LOPROC = 0x70000000;

        /// <summary>
        /// Gets the type value representing the upper bound of a segment holding processor specific semantics.
        /// </summary>
        public const UInt32 PT_HIPROC = 0x7FFFFFFF;

        /// <summary>
        /// Gets the flag value representing an executable segment.
        /// </summary>
        public const UInt32 PF_X = 0x00000001;

        /// <summary>
        /// Gets the flag value representing a writable segment.
        /// </summary>
        public const UInt32 PF_W = 0x00000002;

        /// <summary>
        /// Gets the flag value representing a readable segment.
        /// </summary>
        public const UInt32 PF_R = 0x00000004;

        /// <summary>
        /// Gets the size in number of bytes of the segment on disk.
        /// </summary>
        public UInt64 FileSize
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the offset from the beginning of the ELF file the first byte in this segment.
        /// </summary>
        public UInt64 Offset
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the size in number of bytes of this segment in memory.
        /// </summary>
        public UInt64 MemorySize
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the virtual address of this segment.
        /// </summary>
        public UInt64 VirtualAddress
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the physical address of this segment.
        /// </summary>
        public UInt64 PhysicalAddress
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the address alignment of this segment.
        /// </summary>
        public UInt64 Alignment
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the type of this segment.
        /// </summary>
        public UInt32 Type
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the flags of this segment.
        /// </summary>
        public UInt32 Flags
        {
            get; protected set;
        }
    }
}

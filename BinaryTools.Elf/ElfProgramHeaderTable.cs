﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace BinaryTools.Elf
{
    /// <summary>
    /// Represents an ELF program header table which describes a list of ELF segments.
    /// </summary>
    public sealed class ElfProgramHeaderTable : IReadOnlyList<ElfSegment>
    {
        /// <summary>
        /// Gets the list of ELF segments in this program header table.
        /// </summary>
        private readonly List<ElfSegment> segments = new List<ElfSegment>();

        /// <summary>
        /// Gets an ELF segment at an index.
        /// </summary>
        /// 
        /// <param name="index">
        /// The index of the ELF segment.
        /// </param>
        /// 
        /// <returns>
        /// The ELF segment at the given index.
        /// </returns>
        public ElfSegment this[Int32 index]
        {
            get
            {
                return segments[index];
            }
        }

        /// <summary>
        /// Gets the number of ELF segments in this program header table.
        /// </summary>
        public Int32 Count
        {
            get
            {
                return segments.Count;
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ElfProgramHeaderTable"/> by examining an ELF header.
        /// </summary>
        /// 
        /// <param name="reader">
        /// The reader used to extract the data needed to parse the ELF file.
        /// </param>
        /// 
        /// <param name="header">
        /// The ELF header used to extract the metadata about this program header table.
        /// </param>
        internal ElfProgramHeaderTable(BinaryReader reader, ElfHeader header)
        {
            // Initialize all segments
            for (var i = 0; i < header.ProgramHeaderEntryCount; i++)
            {
                ElfSegment segment;

                switch (header.Class)
                {
                    case ElfHeader.ELFCLASS32:
                        {
                            segment = new Bit32.ElfSegment(reader, (Int64)(header.ProgramHeaderOffset + (UInt64)(i * header.ProgramHeaderSize)));
                        }
                        break;

                    case ElfHeader.ELFCLASS64:
                        {
                            segment = new Bit64.ElfSegment(reader, (Int64)(header.ProgramHeaderOffset + (UInt64)(i * header.ProgramHeaderSize)));
                        }
                        break;

                    default:
                        {
                            throw new InvalidOperationException("Unreachable case reached");
                        }
                }

                segments.Add(segment);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the ELF segments.
        /// </summary>
        /// 
        /// <returns>
        /// An enumerator that can be used to iterate through the ELF segments.
        /// </returns>
        public IEnumerator<ElfSegment> GetEnumerator()
        {
            return segments.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the ELF segments.
        /// </summary>
        /// 
        /// <returns>
        /// An enumerator that can be used to iterate through the ELF segments.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

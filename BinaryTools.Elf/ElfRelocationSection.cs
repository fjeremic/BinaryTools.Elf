using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTools.Elf
{
    public abstract class ElfRelocationSection : ElfSection, IReadOnlyList<ElfRelocationEntry>
    {
        /// <summary>
        /// Gets the list of relocation entries in this relocation section.
        /// </summary>
        protected readonly List<ElfRelocationEntry> entries = new List<ElfRelocationEntry>();

        /// <summary>
        /// Gets the type value of a segment that is unused.
        /// </summary>
        public const UInt32 R_X86_64_JUMP_SLO = 0x00000007;

        /// <summary>
        /// Gets a relocation entry at an index.
        /// </summary>
        /// 
        /// <param name="index">
        /// The index of the relocation entry.
        /// </param>
        /// 
        /// <returns>
        /// The relocation entry at the given index.
        /// </returns>
        public ElfRelocationEntry this[Int32 index]
        {
            get
            {
                return entries[index];
            }
        }

        /// <summary>
        /// Gets the number of relocation entries in this section.
        /// </summary>
        public Int32 Count
        {
            get
            {
                return entries.Count;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the relocation section entries.
        /// </summary>
        /// 
        /// <returns>
        /// An enumerator that can be used to iterate through the relocation section entries.
        /// </returns>
        public IEnumerator<ElfRelocationEntry> GetEnumerator()
        {
            return entries.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the relocation section entries.
        /// </summary>
        /// 
        /// <returns>
        /// An enumerator that can be used to iterate through the relocation section entries.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

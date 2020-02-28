using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTools.Elf
{
    public abstract class ElfStringTable : ElfSection, IReadOnlyList<ElfStringTableEntry>
    {
        /// <summary>
        /// Gets the list of string entries (index and value) in this string table.
        /// </summary>
        protected readonly List<ElfStringTableEntry> entries = new List<ElfStringTableEntry>();

        /// <summary>
        /// Gets a string entry at an index.
        /// </summary>
        /// 
        /// <param name="index">
        /// The index of the string entry.
        /// </param>
        /// 
        /// <returns>
        /// The string entry at the given index.
        /// </returns>
        public ElfStringTableEntry this[Int32 index]
        {
            get
            {
                return entries[index];
            }
        }

        /// <summary>
        /// Gets the number of strings in this section.
        /// </summary>
        public Int32 Count
        {
            get
            {
                return entries.Count;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the string table entries.
        /// </summary>
        /// 
        /// <returns>
        /// An enumerator that can be used to iterate through the string table entries.
        /// </returns>
        public IEnumerator<ElfStringTableEntry> GetEnumerator()
        {
            return entries.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the string table entries.
        /// </summary>
        /// 
        /// <returns>
        /// An enumerator that can be used to iterate through the string table entries.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTools.Elf
{
    public abstract class ElfDynamicSection : ElfSection, IReadOnlyList<ElfDynamicEntry>
    {
        /// <summary>
        /// Gets the list of dynamic entries in this dynamic section.
        /// </summary>
        protected readonly List<ElfDynamicEntry> entries = new List<ElfDynamicEntry>();

        /// <summary>
        /// Gets a dynamic entry at an index.
        /// </summary>
        /// 
        /// <param name="index">
        /// The index of the dynamic entry.
        /// </param>
        /// 
        /// <returns>
        /// The dynamic entry at the given index.
        /// </returns>
        public ElfDynamicEntry this[Int32 index]
        {
            get
            {
                return entries[index];
            }
        }

        /// <summary>
        /// Gets the number of dynamic entries in this section.
        /// </summary>
        public Int32 Count
        {
            get
            {
                return entries.Count;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the dynamic section entries.
        /// </summary>
        /// 
        /// <returns>
        /// An enumerator that can be used to iterate through the dynamic section entries.
        /// </returns>
        public IEnumerator<ElfDynamicEntry> GetEnumerator()
        {
            return entries.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the dynamic section entries.
        /// </summary>
        /// 
        /// <returns>
        /// An enumerator that can be used to iterate through the dynamic section entries.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

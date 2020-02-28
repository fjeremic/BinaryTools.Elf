using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTools.Elf
{
    public abstract class ElfSymbolTable : ElfSection, IReadOnlyList<ElfSymbolTableEntry>
    {
        /// <summary>
        /// Gets the list of symbol entries in this symbol table.
        /// </summary>
        protected readonly List<ElfSymbolTableEntry> entries = new List<ElfSymbolTableEntry>();

        /// <summary>
        /// Gets a symbol entry at an index.
        /// </summary>
        /// 
        /// <param name="index">
        /// The index of the symbol entry.
        /// </param>
        /// 
        /// <returns>
        /// The symbol entry at the given index.
        /// </returns>
        public ElfSymbolTableEntry this[Int32 index]
        {
            get
            {
                return entries[index];
            }
        }

        /// <summary>
        /// Gets the number of symbol entries in this section.
        /// </summary>
        public Int32 Count
        {
            get
            {
                return entries.Count;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the symbol table entries.
        /// </summary>
        /// 
        /// <returns>
        /// An enumerator that can be used to iterate through the symbol table entries.
        /// </returns>
        public IEnumerator<ElfSymbolTableEntry> GetEnumerator()
        {
            return entries.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the symbol table entries.
        /// </summary>
        /// 
        /// <returns>
        /// An enumerator that can be used to iterate through the symbol table entries.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

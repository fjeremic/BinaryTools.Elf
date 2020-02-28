using System;

namespace BinaryTools.Elf
{
    public abstract class ElfRelocationEntry
    {
        /// <summary>
        /// Gets the location at which to apply the relocation action. For a relocatable file, the value is the byte offset from the beginning of the section to the storage unit affected by the relocation. For an executable file or a shared object, the value is the virtual address of the storage unit affected by the relocation.
        /// </summary>
        public UInt64 Offset
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the symbol table index with respect to which the relocation must be made, and the type of relocation to apply.
        /// </summary>
        public UInt64 Info
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the processor specific relocation type. See <see cref="ElfRelocationSection"/> for more details.
        /// </summary>
        public UInt32 Type
        {
            get; protected set;
        }

        /// <summary>
        /// Gets a constant addend used to compute the value to be stored into the relocatable field, if it exists.
        /// </summary>
        public UInt64 Addend
        {
            get; protected set;
        }

        /// <summary>
        /// Gets name of the symbol to relocate.
        /// </summary>
        public String Symbol
        {
            get; internal set;
        }

        /// <summary>
        /// Gets symbol table index with respect to which the relocation must be made.
        /// </summary>
        public Int32 SymbolIndex
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the value from the symbol table corresponding to this relocation symbol.
        /// </summary>
        public UInt64 SymbolValue
        {
            get; internal set;
        }
    }
}

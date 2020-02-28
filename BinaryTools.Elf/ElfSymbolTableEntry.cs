using System;

namespace BinaryTools.Elf
{
    public abstract class ElfSymbolTableEntry
    {
        /// <summary>
        /// Gets the name of the symbol.
        /// </summary>
        public String Name
        {
            get; internal set;
        }
        /// <summary>
        /// Gets an index into the object file's symbol string table, which holds the character representations of the symbol names.
        /// </summary>
        public UInt32 NameIndex
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the value of the associated symbol.
        /// </summary>
        public UInt64 Value
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the size associated with the symbol. For example, a data object's size is the number of bytes contained in the object.
        /// </summary>
        public UInt64 Size
        {
            get; internal set;
        }

        /// <summary>
        /// Gets the symbol's binding.
        /// </summary>
        public ElfSymbolBinding Binding
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the symbol's type.
        /// </summary>
        public ElfSymbolType Type
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the symbol's visibility.
        /// </summary>
        public ElfSymbolVisibility Visibility
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the relevant section header table index for which this symbol entry is defined.
        /// </summary>
        public UInt16 ShIndex
        {
            get; protected set;
        }
    }
}

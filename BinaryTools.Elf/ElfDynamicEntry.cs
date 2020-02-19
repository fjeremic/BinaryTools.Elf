using System;

namespace BinaryTools.Elf
{
    public abstract class ElfDynamicEntry
    {
        /// <summary>
        /// Gets the tag which controls the interpretation of the <see cref="Value"/>.
        /// </summary>
        public ElfDynamicArrayTag Tag
        {
            get; protected set;
        }

        /// <summary>
        /// Gets an integer value with various interpretations, including program virtual addresses.
        /// </summary>
        public UInt64 Value
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the string value of this entry if the <see cref="Tag"/> indicates that the <see cref="Value"/> holds
        /// an index into the table recorded in the DT_STRTAB entry.
        /// </summary>
        public String Name
        {
            get; internal set;
        }
    }
}

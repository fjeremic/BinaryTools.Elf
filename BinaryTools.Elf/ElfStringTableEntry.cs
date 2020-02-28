using System;

namespace BinaryTools.Elf
{
    public class ElfStringTableEntry
    {
        /// <summary>
        /// Gets the string value.
        /// </summary>
        public String Value
        {
            get; set;
        }
        /// <summary>
        /// Gets index (in number of bytes) from the start of the string table section to this string entry.
        /// </summary>
        public UInt32 Index
        {
            get; set;
        }
    }
}

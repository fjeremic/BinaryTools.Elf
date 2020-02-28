using System;
using System.IO;

namespace BinaryTools.Elf.Bit32
{
    internal sealed class ElfRelocationEntry : Elf.ElfRelocationEntry
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ElfRelocationEntry"/> by extracting data from a <see cref="BinaryReader"/>.
        /// </summary>
        /// 
        /// <param name="reader">
        /// The reader used to extract the data needed to initialize this type.
        /// </param>
        /// 
        /// <param name="position">
        /// The position within the <paramref name="reader"/> base stream at which the entry begins.
        /// </param>
        /// 
        /// <param name="hasAddend">
        /// Determines whether to parse the addend field.
        /// </param>
        internal ElfRelocationEntry(BinaryReader reader, Int64 position, Boolean hasAddend)
        {
            reader.BaseStream.Position = position;

            // Represents Elf32_Rel(a).r_offset
            Offset = reader.ReadUInt32();

            // Represents Elf32_Rel(a).r_info
            Info = reader.ReadUInt32();

            // Represents ELF32_R_SYM(i)
            SymbolIndex = (Int32)(Info >> 8);

            // Represents ELF32_R_TYPE(i)
            Type = (UInt32)(Info & 0xFFUL);

            if (hasAddend)
            {
                Addend = reader.ReadUInt32();
            }

            Symbol = String.Empty;
        }
    }
}

﻿using System;
using System.IO;

namespace BinaryTools.Elf.Bit32
{
    internal sealed class ElfRelocationSection : Elf.ElfRelocationSection
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ElfRelocationSection"/> by extracting data from a <see cref="BinaryReader"/>.
        /// </summary>
        /// 
        /// <param name="reader">
        /// The reader used to extract the data needed to initialize this type.
        /// </param>
        /// 
        /// <param name="position">
        /// The position within the <paramref name="reader"/> base stream at which the ELF section begins.
        /// </param>
        internal ElfRelocationSection(BinaryReader reader, Int64 position)
        {
            reader.BaseStream.Position = position;

            // Represents Elf32_Shdr.sh_name
            NameOffset = reader.ReadUInt32();

            // Represents Elf32_Shdr.sh_type
            Type = (ElfSectionType)reader.ReadUInt32();

            // Represents Elf32_Shdr.sh_flags
            Flags = (ElfSectionFlags)reader.ReadUInt32();

            // Represents Elf32_Shdr.sh_addr
            Address = reader.ReadUInt32();

            // Represents Elf32_Shdr.sh_offset
            Offset = reader.ReadUInt32();

            // Represents Elf32_Shdr.sh_size
            Size = reader.ReadUInt32();

            // Represents Elf32_Shdr.sh_link
            Link = reader.ReadUInt32();

            // Represents Elf32_Shdr.sh_info
            Info = reader.ReadUInt32();

            // Represents Elf32_Shdr.sh_addralign
            Alignment = reader.ReadUInt32();

            // Represents Elf32_Shdr.sh_entsize
            EntrySize = reader.ReadUInt32();

            // Initialize all dynamic entries
            for (UInt64 i = 0; i < Size / EntrySize; i++)
            {
                var entry = new ElfRelocationEntry(reader, (Int64)(Offset + i * EntrySize), Type == ElfSectionType.RelA);

                entries.Add(entry);
            }
        }
    }
}
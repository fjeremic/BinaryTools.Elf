﻿using System;
using System.IO;

namespace BinaryTools.Elf.Bit32
{
    internal sealed class ElfStringTable : Elf.ElfStringTable
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ElfStringTable"/> by extracting data from a <see cref="BinaryReader"/>.
        /// </summary>
        /// 
        /// <param name="reader">
        /// The reader used to extract the data needed to initialize this type.
        /// </param>
        /// 
        /// <param name="position">
        /// The position within the <paramref name="reader"/> base stream at which the ELF section begins.
        /// </param>
        internal ElfStringTable(BinaryReader reader, Int64 position)
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

            // Update position to start of the string table and skip the first byte as it is allways '\0'
            reader.BaseStream.Position = (Int64)(Offset + 1);

            Int64 startPosition = reader.BaseStream.Position;

            // Parse all strings
            while (reader.BaseStream.Position < startPosition + (Int64)Size)
            {
                var entry = new ElfStringTableEntry
                {
                    Index = (UInt32)(reader.BaseStream.Position - startPosition) + 1,
                    Value = reader.ReadELFString(),
                };

                entries.Add(entry);
            }
        }
    }
}
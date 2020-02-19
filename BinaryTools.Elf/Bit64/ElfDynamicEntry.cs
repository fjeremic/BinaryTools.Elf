﻿using System;
using System.IO;

namespace BinaryTools.Elf.Bit64
{
    internal sealed class ElfDynamicEntry : Elf.ElfDynamicEntry
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ElfDynamicSection"/> by extracting data from a <see cref="BinaryReader"/>.
        /// </summary>
        /// 
        /// <param name="reader">
        /// The reader used to extract the data needed to initialize this type.
        /// </param>
        /// 
        /// <param name="position">
        /// The position within the <paramref name="reader"/> base stream at which the entry begins.
        /// </param>
        internal ElfDynamicEntry(BinaryReader reader, Int64 position)
        {
            reader.BaseStream.Position = position;

            // Represents Elf64_Dyn.d_tag
            Tag = (ElfDynamicArrayTag)reader.ReadUInt64();

            // Represents Elf64_Dyn.d_val
            Value = reader.ReadUInt64();

            Name = String.Empty;
        }
    }
}

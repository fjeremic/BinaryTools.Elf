using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryTools.Elf
{
    /// <summary>
    /// Represents an ELF section header table which describes a list of ELF sections.
    /// </summary>
    public sealed class ElfSectionHeaderTable : IReadOnlyList<ElfSection>
    {
        /// <summary>
        /// Gets the list of ELF sections in this section header table.
        /// </summary>
        private readonly List<ElfSection> sections = new List<ElfSection>();

        /// <summary>
        /// Gets an ELF section at an index.
        /// </summary>
        /// 
        /// <param name="index">
        /// The index of the ELF section.
        /// </param>
        /// 
        /// <returns>
        /// The ELF section at the given index.
        /// </returns>
        public ElfSection this[Int32 index]
        {
            get
            {
                return sections[index];
            }
        }

        /// <summary>
        /// Gets an ELF section by name.
        /// </summary>
        /// 
        /// <param name="index">
        /// The name of the ELF section.
        /// </param>
        /// 
        /// <returns>
        /// The ELF section with the specified name if it exists; <c>null</c> otherwise.
        /// </returns>
        public ElfSection this[String name]
        {
            get
            {
                return this.FirstOrDefault(item => item.Name == name);
            }
        }

        /// <summary>
        /// Gets the number of ELF sections in this section header table.
        /// </summary>
        public Int32 Count
        {
            get
            {
                return sections.Count;
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ElfSectionHeaderTable"/> by examining an ELF header.
        /// </summary>
        /// 
        /// <param name="reader">
        /// The reader used to extract the data needed to parse the ELF file.
        /// </param>
        /// 
        /// <param name="header">
        /// The ELF header used to extract the metadata about this section header table.
        /// </param>
        internal ElfSectionHeaderTable(BinaryReader reader, ElfHeader header)
        {
            // Initialize all segments
            for (var i = 0; i < header.SectionHeaderEntryCount; ++i)
            {
                ElfSection section;

                switch (header.Class)
                {
                    case ElfHeader.ELFCLASS32:
                    {
                        section = new Bit32.ElfSection(reader, (Int64)(header.SectionHeaderOffset + (UInt64)(i * header.SectionHeaderSize)));

                        switch (section.Type)
                        {
                            case ElfSectionType.Dynamic:
                            {
                                section = new Bit32.ElfDynamicSection(reader, (Int64)(header.SectionHeaderOffset + (UInt64)(i * header.SectionHeaderSize)));
                            }
                            break;

                            case ElfSectionType.DynSym:
                            {
                                section = new Bit32.ElfSymbolTable(reader, (Int64)(header.SectionHeaderOffset + (UInt64)(i * header.SectionHeaderSize)));
                            }
                            break;

                            case ElfSectionType.Rel:
                            case ElfSectionType.RelA:
                            {
                                section = new Bit32.ElfRelocationSection(reader, (Int64)(header.SectionHeaderOffset + (UInt64)(i * header.SectionHeaderSize)));
                            }
                            break;

                            case ElfSectionType.StrTab:
                            {
                                section = new Bit32.ElfStringTable(reader, (Int64)(header.SectionHeaderOffset + (UInt64)(i * header.SectionHeaderSize)));
                            }
                            break;
                        }
                    }
                    break;

                    case ElfHeader.ELFCLASS64:
                    {
                        section = new Bit64.ElfSection(reader, (Int64)(header.SectionHeaderOffset + (UInt64)(i * header.SectionHeaderSize)));

                        switch (section.Type)
                        {
                            case ElfSectionType.Dynamic:
                            {
                                section = new Bit64.ElfDynamicSection(reader, (Int64)(header.SectionHeaderOffset + (UInt64)(i * header.SectionHeaderSize)));
                            }
                            break;

                            case ElfSectionType.DynSym:
                            {
                                section = new Bit64.ElfSymbolTable(reader, (Int64)(header.SectionHeaderOffset + (UInt64)(i * header.SectionHeaderSize)));
                            }
                            break;

                            case ElfSectionType.Rel:
                            case ElfSectionType.RelA:
                            {
                                section = new Bit64.ElfRelocationSection(reader, (Int64)(header.SectionHeaderOffset + (UInt64)(i * header.SectionHeaderSize)));
                            }
                            break;

                            case ElfSectionType.StrTab:
                            {
                                section = new Bit64.ElfStringTable(reader, (Int64)(header.SectionHeaderOffset + (UInt64)(i * header.SectionHeaderSize)));
                            }
                            break;
                        }
                    }
                    break;

                    default:
                    {
                        throw new InvalidOperationException("Unreachable case reached");
                    }
                }

                sections.Add(section);
            }

            UInt16 shStrIndex = header.StringSectionIndex;

            if (shStrIndex != (UInt16)ElfSectionType.Null)
            {
                // Initialize section names
                for (var i = 0; i < header.SectionHeaderEntryCount; i++)
                {
                    sections[i].Name = reader.ReadELFString(this[shStrIndex], this[i].NameOffset);
                }
            }

            // Parse all dynamic entries names now that we have all sections initalized
            foreach (ElfDynamicSection dynamicSection in sections.OfType<ElfDynamicSection>())
            {
                ElfDynamicEntry strTab = dynamicSection.FirstOrDefault(e => e.Tag == ElfDynamicArrayTag.StrTab);

                if (strTab != null)
                {
                    ElfSection dynSymSection = sections.First(s => s.Address == strTab.Value);

                    foreach (ElfDynamicEntry entry in dynamicSection)
                    {
                        switch (entry.Tag)
                        {
                            case ElfDynamicArrayTag.Needed:
                            case ElfDynamicArrayTag.SOName:
                            case ElfDynamicArrayTag.RPath:
                            case ElfDynamicArrayTag.RunPath:
                            {
                                entry.Name = reader.ReadELFString(dynSymSection, entry.Value);
                            }
                            break;
                        }
                    }
                }
            }

            var symTab = sections.OfType<ElfSymbolTable>().FirstOrDefault();
            var dynStr = sections.OfType<ElfStringTable>().Where(s => s.Name == ".dynstr").FirstOrDefault();

            // Parse all relocation entries symbols now that we have all sections initalized
            foreach (ElfSymbolTableEntry entry in symTab)
            {
                entry.Name = reader.ReadELFString(dynStr, entry.NameIndex);
            }

            // Parse all relocation entries symbols now that we have all sections initalized
            foreach (ElfRelocationSection relocationSection in sections.OfType<ElfRelocationSection>())
            {
                foreach (ElfRelocationEntry entry in relocationSection)
                {
                    entry.Symbol = symTab[entry.SymbolIndex].Name;
                    entry.SymbolValue = symTab[entry.SymbolIndex].Value;
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the ELF sections.
        /// </summary>
        /// 
        /// <returns>
        /// An enumerator that can be used to iterate through the ELF sections.
        /// </returns>
        public IEnumerator<ElfSection> GetEnumerator()
        {
            return sections.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the ELF sections.
        /// </summary>
        /// 
        /// <returns>
        /// An enumerator that can be used to iterate through the ELF sections.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

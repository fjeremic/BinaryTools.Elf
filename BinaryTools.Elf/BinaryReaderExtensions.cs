using System;
using System.IO;
using System.Text;

namespace BinaryTools.Elf
{
    /// <summary>
    /// An extension class providing <see cref="BinaryReader"/> utility methods for extracting ELF specific data.
    /// </summary>
    public static class BinaryReaderExtensions
    {
        /// <summary>
        /// Reads a string value from the binary reader.
        /// </summary>
        /// 
        /// <param name="reader">
        /// The binary reader used to extract data.
        /// </param>
        /// 
        /// <returns>
        /// The string value.
        /// </returns>
        /// 
        /// <remarks>
        /// The string is defined as a null terminated sequence of character values.
        /// </remarks>
        public static String ReadELFString(this BinaryReader reader)
        {
            StringBuilder builder = new StringBuilder();

            Char c = (Char)reader.ReadByte();

            // Read the entire null terminated string
            while (c != 0)
            {
                builder.Append(c); c = (Char)reader.ReadByte();
            }

            return builder.ToString();
        }

        /// <summary>
        /// Reads a string value from an index into the ELF string table section.
        /// </summary>
        /// 
        /// <param name="reader">
        /// The binary reader used to extract data.
        /// </param>
        /// 
        /// <param name="section">
        /// The ELF string table section.
        /// </param>
        /// 
        /// <param name="offset">
        /// The offset of the string in the ELF string table section.
        /// </param>
        /// 
        /// <returns>
        /// The string value extracted from the ELF string table section at the specified offset.
        /// </returns>
        /// 
        /// <remarks>
        /// The string is defined as a null terminated sequence of character values.
        /// </remarks>
        public static String ReadELFString(this BinaryReader reader, ElfSection section, UInt64 offset)
        {
            String value = null;

            if (section != null && offset < section.Size)
            {
                Int64 savedPosition = reader.BaseStream.Position;

                reader.BaseStream.Position = (Int64)(section.Offset + offset);

                // Read the entire null terminated string
                value = reader.ReadELFString();

                reader.BaseStream.Position = savedPosition;
            }

            return value;
        }
    }
}

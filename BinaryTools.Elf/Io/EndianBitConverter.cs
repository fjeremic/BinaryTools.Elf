using System;

namespace BinaryTools.Elf.Io
{
    /// <summary>
    /// Converts integral values to the native endianness of this computer architecture.
    /// </summary>
    public static class EndianBitConverter
    {
        /// <summary>
        /// Gets the native endianness of this computer architecture.
        /// </summary>
        public static readonly Endianness NativeEndianness = BitConverter.IsLittleEndian ? Endianness.LittleEndian : Endianness.BigEndian;

        /// <summary>
        /// Converts a value from the specified endianness to the native endianness.
        /// </summary>
        /// 
        /// <param name="value">
        /// The value to convert.
        /// </param>
        /// 
        /// <param name="endianness">
        /// The endianness of <paramref name="value"/>.
        /// </param>
        /// 
        /// <returns>
        /// The value converted from the specified endianness to the native endianness (<see cref="NativeEndianness"/>).
        /// </returns>
        public static UInt16 Convert(UInt16 value, Endianness endianness)
        {
            if (endianness == NativeEndianness)
            {
                return value;
            }
            else
            {
                unchecked
                {
                    return (UInt16)((value & 0x00FFU) << 8 |
                                     (value & 0xFF00U) >> 8);
                }
            }
        }

        /// <summary>
        /// Converts a value from the specified endianness to the native endianness.
        /// </summary>
        /// 
        /// <param name="value">
        /// The value to convert.
        /// </param>
        /// 
        /// <param name="endianness">
        /// The endianness of <paramref name="value"/>.
        /// </param>
        /// 
        /// <returns>
        /// The value converted from the specified endianness to the native endianness (<see cref="NativeEndianness"/>).
        /// </returns>
        public static UInt32 Convert(UInt32 value, Endianness endianness)
        {
            if (endianness == NativeEndianness)
            {
                return value;
            }
            else
            {
                unchecked
                {
                    return (value & 0x000000FFU) << 24 |
                           (value & 0xFF000000U) >> 24 |
                           (value & 0x0000FF00U) << 8 |
                           (value & 0x00FF0000U) >> 8;
                }
            }
        }

        /// <summary>
        /// Converts a value from the specified endianness to the native endianness.
        /// </summary>
        /// 
        /// <param name="value">
        /// The value to convert.
        /// </param>
        /// 
        /// <param name="endianness">
        /// The endianness of <paramref name="value"/>.
        /// </param>
        /// 
        /// <returns>
        /// The value converted from the specified endianness to the native endianness (<see cref="NativeEndianness"/>).
        /// </returns>
        public static UInt64 Convert(UInt64 value, Endianness endianness)
        {
            if (endianness == NativeEndianness)
            {
                return value;
            }
            else
            {
                unchecked
                {
                    return (value & 0x00000000000000FFUL) << 56 |
                           (value & 0xFF00000000000000UL) >> 56 |
                           (value & 0x000000000000FF00UL) << 40 |
                           (value & 0x00FF000000000000UL) >> 40 |
                           (value & 0x0000000000FF0000UL) << 24 |
                           (value & 0x0000FF0000000000UL) >> 24 |
                           (value & 0x00000000FF000000UL) << 8 |
                           (value & 0x000000FF00000000UL) >> 8;
                }
            }
        }

        /// <summary>
        /// Converts a value from the specified endianness to the native endianness.
        /// </summary>
        /// 
        /// <param name="value">
        /// The value to convert.
        /// </param>
        /// 
        /// <param name="endianness">
        /// The endianness of <paramref name="value"/>.
        /// </param>
        /// 
        /// <returns>
        /// The value converted from the specified endianness to the native endianness (<see cref="NativeEndianness"/>).
        /// </returns>
        public static Int16 Convert(Int16 value, Endianness endianness)
        {
            return (Int16)Convert((UInt16)value, endianness);
        }

        /// <summary>
        /// Converts a value from the specified endianness to the native endianness.
        /// </summary>
        /// 
        /// <param name="value">
        /// The value to convert.
        /// </param>
        /// 
        /// <param name="endianness">
        /// The endianness of <paramref name="value"/>.
        /// </param>
        /// 
        /// <returns>
        /// The value converted from the specified endianness to the native endianness (<see cref="NativeEndianness"/>).
        /// </returns>
        public static Int32 Convert(Int32 value, Endianness endianness)
        {
            return (Int32)Convert((UInt32)value, endianness);
        }

        /// <summary>
        /// Converts a value from the specified endianness to the native endianness.
        /// </summary>
        /// 
        /// <param name="value">
        /// The value to convert.
        /// </param>
        /// 
        /// <param name="endianness">
        /// The endianness of <paramref name="value"/>.
        /// </param>
        /// 
        /// <returns>
        /// The value converted from the specified endianness to the native endianness (<see cref="NativeEndianness"/>).
        /// </returns>
        public static Int64 Convert(Int64 value, Endianness endianness)
        {
            return (Int64)Convert((UInt64)value, endianness);
        }
    }
}

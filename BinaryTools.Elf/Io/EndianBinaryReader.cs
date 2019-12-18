using System;
using System.IO;
using System.Text;

namespace BinaryTools.Elf.Io
{
    /// <summary>
    /// Reads primitive data types as binary values in a specific encoding and endianness.
    /// </summary>
    public class EndianBinaryReader : BinaryReader
    {
        /// <summary>
        /// Gets the endianness of the data in the input stream.
        /// </summary>
        public Endianness Endianness
        {
            get;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EndianBinaryReader"/> based on the specified stream, endianness, and using UTF-8
        /// encoding.
        /// </summary>
        /// 
        /// <param name="input">
        /// The input stream.
        /// </param>
        /// 
        /// <param name="endianness">
        /// The endianness of the data in the input stream.
        /// </param>
        /// 
        /// <exception cref="System.ArgumentException">
        /// The stream does not support reading, is null, or is already closed.
        /// </exception>
        public EndianBinaryReader(Stream input, Endianness endianness)
        :
            this(input, endianness, Encoding.UTF8)
        {
            // Void
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EndianBinaryReader"/> based on the specified stream, endianness, and character
        /// encoding.
        /// </summary>
        /// 
        /// <param name="input">
        /// The input stream.
        /// </param>
        /// 
        /// <param name="endianness">
        /// The endianness of the data in the input stream.
        /// </param>
        /// 
        /// <param name="encoding">
        /// The character encoding to use.
        /// </param>
        /// 
        /// <exception cref="System.ArgumentException">
        /// The stream does not support reading, is null, or is already closed.
        /// </exception>
        public EndianBinaryReader(Stream input, Endianness endianness, Encoding encoding)
        :
            this(input, endianness, encoding, false)
        {
            // Void
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EndianBinaryReader"/> based on the specified stream, endianness, and character
        /// encoding, and optionally leaves the stream open.
        /// </summary>
        /// 
        /// <param name="input">
        /// The input stream.
        /// </param>
        /// 
        /// <param name="endianness">
        /// The endianness of the data in the input stream.
        /// </param>
        /// 
        /// <param name="encoding">
        /// The character encoding to use.
        /// </param>
        /// 
        /// <param name="leaveOpen">
        /// <c>true</c> to leave the stream open after the <see cref="EndianBinaryReader"/> object is disposed; <c>false</c> otherwise.
        /// </param>
        /// 
        /// <exception cref="System.ArgumentException">
        /// The stream does not support reading, is null, or is already closed.
        /// </exception>
        public EndianBinaryReader(Stream input, Endianness endianness, Encoding encoding, Boolean leaveOpen)
        :
            base(input, encoding, leaveOpen)
        {
            Endianness = endianness;
        }

        /// <summary>
        /// Reads a decimal value from the current stream and advances the current position of the stream by sixteen bytes.
        /// </summary>
        /// 
        /// <returns>
        /// A decimal value read from the current stream.
        /// </returns>
        public override Decimal ReadDecimal()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads an 8-byte floating point value from the current stream and advances the current position of the stream by eight bytes.
        /// </summary>
        /// 
        /// <returns>
        /// An 8-byte floating point value read from the current stream.
        /// </returns>
        public override Double ReadDouble()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a 2-byte signed integer from the current stream and advances the current position of the stream by two bytes.
        /// </summary>
        /// 
        /// <returns>
        /// A 2-byte signed integer read from the current stream.
        /// </returns>
        public override Int16 ReadInt16()
        {
            return EndianBitConverter.Convert(base.ReadInt16(), Endianness);
        }

        /// <summary>
        /// Reads a 4-byte signed integer from the current stream and advances the current position of the stream by four bytes.
        /// </summary>
        /// 
        /// <returns>
        /// A 4-byte signed integer read from the current stream.
        /// </returns>
        public override Int32 ReadInt32()
        {
            return EndianBitConverter.Convert(base.ReadInt32(), Endianness);
        }

        /// <summary>
        /// Reads an 8-byte signed integer from the current stream and advances the current position of the stream by eight bytes.
        /// </summary>
        /// 
        /// <returns>
        /// An 8-byte signed integer read from the current stream.
        /// </returns>
        public override Int64 ReadInt64()
        {
            return EndianBitConverter.Convert(base.ReadInt64(), Endianness);
        }

        /// <summary>
        /// Reads a 4-byte floating point value from the current stream and advances the current position of the stream by four bytes.
        /// </summary>
        /// 
        /// <returns>
        /// A 4-byte floating point value read from the current stream.
        /// </returns>
        public override Single ReadSingle()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a string from the current stream. The string is prefixed with the length, encoded as an integer seven bits at a time.
        /// </summary>
        /// 
        /// <returns>
        /// The string being read.
        /// </returns>
        public override String ReadString()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a 2-byte unsigned integer from the current stream using little-endian encoding and advances the position of the stream by
        /// two bytes.
        /// </summary>
        /// 
        /// <returns>
        /// A 2-byte unsigned integer read from this stream.
        /// </returns>
        public override UInt16 ReadUInt16()
        {
            return EndianBitConverter.Convert(base.ReadUInt16(), Endianness);
        }

        /// <summary>
        /// Reads a 4-byte unsigned integer from the current stream using little-endian encoding and advances the position of the stream by
        /// four bytes.
        /// </summary>
        /// 
        /// <returns>
        /// A 4-byte unsigned integer read from this stream.
        /// </returns>
        public override UInt32 ReadUInt32()
        {
            return EndianBitConverter.Convert(base.ReadUInt32(), Endianness);
        }

        /// <summary>
        /// Reads an 8-byte unsigned integer from the current stream using little-endian encoding and advances the position of the stream by
        /// eight bytes.
        /// </summary>
        /// 
        /// <returns>
        /// An 8-byte unsigned integer read from this stream.
        /// </returns>
        public override UInt64 ReadUInt64()
        {
            return EndianBitConverter.Convert(base.ReadUInt64(), Endianness);
        }
    }
}

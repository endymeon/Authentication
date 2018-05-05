using System;

namespace TWG.Authentication.Core.Database
{
    public sealed class Conversion
    {
        private Conversion()
        {
        }
        static Conversion()
        {
            DEFAULT_DATETIME = DateTime.MinValue;
        }

        // NOTE: If these change, be certain to update the xml 
        // documentation for the appropriate methods!
        /// <summary>Default value used when DBNull is passed to DBNullToBoolean</summary>
        public const bool DEFAULT_BOOLEAN = false;
        /// <summary>Default value used when DBNull is passed to DBNullToString</summary>
        public const string DEFAULT_STRING = "";
        /// <summary>Default value used when DBNull is passed to DBNullToDateTime</summary>
        public static readonly DateTime DEFAULT_DATETIME;
        // equals "1/1/0001 12:00:00 AM"
        /// <summary>Default value used when DBNull is passed to DBNullToSingle</summary>
        public const float DEFAULT_SINGLE = 0;
        /// <summary>Default value used when DBNull is passed to DBNullToDouble</summary>
        public const double DEFAULT_DOUBLE = 0;
        /// <summary>Default value used when DBNull is passed to DBNullToDecimal</summary>
        public const decimal DEFAULT_DECIMAL = 0;
        /// <summary>Default value used when DBNull is passed to DBNullToInt64</summary>
        public const long DEFAULT_INT64 = 0;
        /// <summary>Default value used when DBNull is passed to DBNullToInt32</summary>
        public const int DEFAULT_INT32 = 0;
        /// <summary>Default value used when DBNull is passed to DBNullToInt16</summary>
        public const short DEFAULT_INT16 = 0;
        /// <summary>Default value used when DBNull is passed to DBNullToByteArray</summary>
        public static byte[] DEFAULT_BYTE_ARRAY = new byte[-1 + 1];
        /// <summary>Default value used when DBNull is passed to DBNullToByte</summary>
        public const byte DEFAULT_BYTE = 0;
        /// <summary>Default value used when DBNull is passed to DBNullToUInt64</summary>
        public const ulong DEFAULT_UINT64 = 0;
        /// <summary>Default value used when DBNull is passed to DBNullToUInt32</summary>
        public const uint DEFAULT_UINT32 = 0;
        /// <summary>Default value used when DBNull is passed to DBNullToUInt16</summary>
        public const ushort DEFAULT_UINT16 = 0;
        /// <summary>Default value used when DBNull is passed to DBNullToSByte</summary>
        public const sbyte DEFAULT_SBYTE = 0;
        /// <summary>Default value used when DBNull is passed to DBNullToChar</summary>
        public const char DEFAULT_CHAR = Char.MinValue;
        // equals ' '
        /// <summary>
        /// Returns either the original database value as a boolean 
        /// or false if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>false if input is DBNull, input converted to boolean otherwise</returns>
        public static bool DBNullToBoolean(object input)
        {
            return DBNullToBoolean(input, DEFAULT_BOOLEAN);
        }
        /// <summary>
        /// Returns either the input database value as a boolean 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to boolean otherwise</returns>
        public static bool DBNullToBoolean(object input, bool defaultValue)
        {
            return DBNullToNullableBoolean(input) ?? defaultValue;
        }
        /// <summary>
        /// Returns either the original database value as a boolean 
        /// or null if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>null if input is DBNull, input converted to boolean otherwise</returns>
        public static System.Nullable<bool> DBNullToNullableBoolean(object input)
        {
            if (input is DBNull)
            {
                return null;
            }
            return Convert.ToBoolean(input);
        }

        /// <summary>
        /// Returns either the original database value as a string
        /// or an empty string if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Empty string if input is DBNull, input converted to string otherwise</returns>
        public static string DBNullToString(object input)
        {
            return DBNullToString(input, DEFAULT_STRING);
        }
        /// <summary>
        /// Returns either the input database value as a string 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to string otherwise</returns>
        public static string DBNullToString(object input, string defaultValue)
        {
            if (input is DBNull)
            {
                return defaultValue;
            }
            return Convert.ToString(input);
        }

        /// <summary>
        /// Returns either the original database value as a DateTime
        /// or DateTime.MinValue if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>DateTime.MinValue if input is DBNull, input converted to DateTime otherwise</returns>
        public static DateTime DBNullToDateTime(object input)
        {
            return DBNullToDateTime(input, DEFAULT_DATETIME);
        }
        /// <summary>
        /// Returns either the input database value as a DateTime 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to DateTime otherwise</returns>
        public static DateTime DBNullToDateTime(object input, DateTime defaultValue)
        {
            return DBNullToNullableDateTime(input) ?? defaultValue;
        }
        /// <summary>
        /// Returns either the original database value as a DateTime
        /// or null if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>null if input is DBNull, input converted to DateTime otherwise</returns>
        public static System.Nullable<DateTime> DBNullToNullableDateTime(object input)
        {
            if (input is DBNull)
            {
                return null;
            }
            return Convert.ToDateTime(input);
        }

        /// <summary>
        /// Returns either the original database value as a float/single 
        /// or zero if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Zero if input is DBNull, input converted to float/single otherwise</returns>
        public static float DBNullToSingle(object input)
        {
            return DBNullToSingle(input, DEFAULT_SINGLE);
        }

        /// <summary>
        /// Returns either the input database value as a float/single 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to float/single otherwise</returns>
        public static float DBNullToSingle(object input, float defaultValue)
        {
            return DBNullToNullableSingle(input) ?? defaultValue;
        }

        /// <summary>
        /// Returns either the original database value as a float/single 
        /// or null if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Null if input is DBNull, input converted to float/single otherwise</returns>
        public static System.Nullable<float> DBNullToNullableSingle(object input)
        {
            if (input is DBNull)
            {
                return null;
            }
            return Convert.ToSingle(input);
        }

        /// <summary>
        /// Returns either the original database value as a double 
        /// or zero if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Zero if input is DBNull, input converted to double otherwise</returns>
        public static double DBNullToDouble(object input)
        {
            return DBNullToDouble(input, DEFAULT_DOUBLE);
        }

        /// <summary>
        /// Returns either the input database value as a double 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to double otherwise</returns>
        public static double DBNullToDouble(object input, double defaultValue)
        {
            return DBNullToNullableDouble(input) ?? defaultValue;
        }

        /// <summary>
        /// Returns either the original database value as a double 
        /// or null if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Null if input is DBNull, input converted to double otherwise</returns>
        public static System.Nullable<double> DBNullToNullableDouble(object input)
        {
            if (input is DBNull)
            {
                return null;
            }
            return Convert.ToDouble(input);
        }

        /// <summary>
        /// Returns either the original database value as a decimal 
        /// or Decimal.Zero if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Decimal.Zero if input is DBNull, input converted to decimal otherwise</returns>
        public static decimal DBNullToDecimal(object input)
        {
            return DBNullToDecimal(input, DEFAULT_DECIMAL);
        }

        /// <summary>
        /// Returns either the input database value as a decimal 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to decimal otherwise</returns>
        public static decimal DBNullToDecimal(object input, decimal defaultValue)
        {
            return DBNullToNullableDecimal(input) ?? defaultValue;
        }

        /// <summary>
        /// Returns either the original database value as a decimal 
        /// or null if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Null if input is DBNull, input converted to decimal otherwise</returns>
        public static System.Nullable<decimal> DBNullToNullableDecimal(object input)
        {
            if (input is DBNull)
            {
                return null;
            }
            return Convert.ToDecimal(input);
        }

        /// <summary>
        /// Returns either the original database value as a long/Int64
        /// or zero if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Zero if input is DBNull, input converted to long/Int64 otherwise</returns>
        public static long DBNullToInt64(object input)
        {
            return DBNullToInt64(input, DEFAULT_INT64);
        }

        /// <summary>
        /// Returns either the input database value as a long/Int64 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to long/Int64 otherwise</returns>
        public static long DBNullToInt64(object input, long defaultValue)
        {
            return DBNullToNullableInt64(input) ?? defaultValue;
        }

        /// <summary>
        /// Returns either the original database value as a long/Int64
        /// or null if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Null if input is DBNull, input converted to long/Int64 otherwise</returns>
        public static System.Nullable<long> DBNullToNullableInt64(object input)
        {
            if (input is DBNull)
            {
                return null;
            }
            return Convert.ToInt64(input);
        }

        /// <summary>
        /// Returns either the original database value as an int/Int32
        /// or zero if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Zero if input is DBNull, input converted to int/Int32 otherwise</returns>
        public static int DBNullToInt32(object input)
        {
            return DBNullToInt32(input, DEFAULT_INT32);
        }

        /// <summary>
        /// Returns either the input database value as an int/Int32 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to int/Int32 otherwise</returns>
        public static int DBNullToInt32(object input, int defaultValue)
        {
            return DBNullToNullableInt32(input) ?? defaultValue;
        }

        /// <summary>
        /// Returns either the original database value as an int/Int32
        /// or null if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Null if input is DBNull, input converted to int/Int32 otherwise</returns>
        public static System.Nullable<int> DBNullToNullableInt32(object input)
        {
            if (input is DBNull)
            {
                return null;
            }
            return Convert.ToInt32(input);
        }

        /// <summary>
        /// Returns either the original database value as a short/Int16
        /// or zero if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Zero if input is DBNull, input converted to short/Int16 otherwise</returns>
        public static short DBNullToInt16(object input)
        {
            return DBNullToInt16(input, DEFAULT_INT16);
        }

        /// <summary>
        /// Returns either the input database value as a short/Int16 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to short/Int16 otherwise</returns>
        public static short DBNullToInt16(object input, short defaultValue)
        {
            return DBNullToNullableInt16(input) ?? defaultValue;
        }

        /// <summary>
        /// Returns either the original database value as a short/Int16
        /// or null if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Null if input is DBNull, input converted to short/Int16 otherwise</returns>
        public static System.Nullable<short> DBNullToNullableInt16(object input)
        {
            if (input is DBNull)
            {
                return null;
            }
            return Convert.ToInt16(input);
        }

        /// <summary>
        /// Returns either the original database value as a byte
        /// or zero if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Zero if input is DBNull, input converted to byte otherwise</returns>
        public static byte DBNullToByte(object input)
        {
            return DBNullToByte(input, DEFAULT_BYTE);
        }

        /// <summary>
        /// Returns either the input database value as a byte 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to byte otherwise</returns>
        public static byte DBNullToByte(object input, byte defaultValue)
        {
            return DBNullToNullableByte(input) ?? defaultValue;
        }

        /// <summary>
        /// Returns either the original database value as a byte
        /// or null if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Null if input is DBNull, input converted to byte otherwise</returns>
        public static System.Nullable<byte> DBNullToNullableByte(object input)
        {
            if (input is DBNull)
            {
                return null;
            }
            return Convert.ToByte(input);
        }

        /// <summary>
        /// Returns either the original database value as a ulong/UInt64
        /// or zero if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Zero if input is DBNull, input converted to ulong/UInt64 otherwise</returns>
        public static ulong DBNullToUInt64(object input)
        {
            return DBNullToUInt64(input, DEFAULT_UINT64);
        }

        /// <summary>
        /// Returns either the input database value as a ulong/UInt64 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to ulong/UInt64 otherwise</returns>
        public static ulong DBNullToUInt64(object input, ulong defaultValue)
        {
            return DBNullToNullableUInt64(input) ?? defaultValue;
        }

        /// <summary>
        /// Returns either the original database value as a ulong/UInt64
        /// or null if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Null if input is DBNull, input converted to ulong/UInt64 otherwise</returns>
        public static System.Nullable<ulong> DBNullToNullableUInt64(object input)
        {
            if (input is DBNull)
            {
                return null;
            }
            return Convert.ToUInt64(input);
        }

        /// <summary>
        /// Returns either the original database value as a uint/UInt32
        /// or zero if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Zero if input is DBNull, input converted to uint/UInt32 otherwise</returns>
        public static uint DBNullToUInt32(object input)
        {
            return DBNullToUInt32(input, DEFAULT_UINT32);
        }

        /// <summary>
        /// Returns either the input database value as a uint/UInt32 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to uint/UInt32 otherwise</returns>
        public static uint DBNullToUInt32(object input, uint defaultValue)
        {
            return DBNullToNullableUInt32(input) ?? defaultValue;
        }

        /// <summary>
        /// Returns either the original database value as a uint/UInt32
        /// or null if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Null if input is DBNull, input converted to uint/UInt32 otherwise</returns>
        public static System.Nullable<uint> DBNullToNullableUInt32(object input)
        {
            if (input is DBNull)
            {
                return null;
            }
            return Convert.ToUInt32(input);
        }

        /// <summary>
        /// Returns either the original database value as a ushort/UInt16
        /// or zero if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Zero if input is DBNull, input converted to ushort/UInt16 otherwise</returns>
        public static ushort DBNullToUInt16(object input)
        {
            return DBNullToUInt16(input, DEFAULT_UINT16);
        }

        /// <summary>
        /// Returns either the input database value as a ushort/UInt16 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to ushort/UInt16 otherwise</returns>
        public static ushort DBNullToUInt16(object input, ushort defaultValue)
        {
            return DBNullToNullableUInt16(input) ?? defaultValue;
        }

        /// <summary>
        /// Returns either the original database value as a ushort/UInt16
        /// or null if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Null if input is DBNull, input converted to ushort/UInt16 otherwise</returns>
        public static System.Nullable<ushort> DBNullToNullableUInt16(object input)
        {
            if (input is DBNull)
            {
                return null;
            }
            return Convert.ToUInt16(input);
        }

        /// <summary>
        /// Returns either the original database value as an sbyte
        /// or zero if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Zero if input is DBNull, input converted to sbyte otherwise</returns>
        public static sbyte DBNullToSByte(object input)
        {
            return DBNullToSByte(input, DEFAULT_SBYTE);
        }

        /// <summary>
        /// Returns either the input database value as an sbyte 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to sbyte otherwise</returns>
        public static sbyte DBNullToSByte(object input, sbyte defaultValue)
        {
            return DBNullToNullableSByte(input) ?? defaultValue;
        }

        /// <summary>
        /// Returns either the original database value as an sbyte
        /// or null if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Null if input is DBNull, input converted to sbyte otherwise</returns>
        public static System.Nullable<sbyte> DBNullToNullableSByte(object input)
        {
            if (input is DBNull)
            {
                return null;
            }
            return Convert.ToSByte(input);
        }

        /// <summary>
        /// Returns either the original database value as a char
        /// or zero if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Char.MinValue if input is DBNull, input converted to char otherwise</returns>
        public static char DBNullToChar(object input)
        {
            return DBNullToChar(input, DEFAULT_CHAR);
        }

        /// <summary>
        /// Returns either the input database value as a char 
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to char otherwise</returns>
        public static char DBNullToChar(object input, char defaultValue)
        {
            return DBNullToNullableChar(input) ?? defaultValue;
        }

        /// <summary>
        /// Returns either the original database value as a char
        /// or null if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>Null if input is DBNull, input converted to char otherwise</returns>
        public static System.Nullable<char> DBNullToNullableChar(object input)
        {
            if (input is DBNull)
            {
                return null;
            }
            return Convert.ToChar(input);
        }

        /// <summary>
        /// Returns either the original database value as a byte array
        /// or an array of zero bytes if that value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <returns>An array of zero bytes if input is DBNull, input converted to byte[] otherwise</returns>
        public static byte[] DBNullToByteArray(object input)
        {
            return DBNullToByteArray(input, DEFAULT_BYTE_ARRAY);
        }

        /// <summary>
        /// Returns either the input database value as a byte array
        /// or the defaultValue parameter if the value is DBNull
        /// </summary>
        /// <param name="input">Database value to inspect</param>
        /// <param name="defaultValue">Value to use as default if input is DBNull</param>
        /// <returns>defaultValue if input is DBNull, input converted to byte[] otherwise</returns>
        public static byte[] DBNullToByteArray(object input, byte[] defaultValue)
        {
            if (input is DBNull)
            {
                return defaultValue;
            }
            return input as byte[];
        }

        /// <summary>
        /// Generic conversion from DBNull to type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T DBNullToT<T>(object input) where T : IConvertible
        {
            T retval = default(T);

            if (!(input is DBNull))
            {
                if (typeof(T).BaseType.Name == "Enum")
                {
                    return (T)Enum.Parse(typeof(T), input.ToString(), true);
                }
                retval = (T)Convert.ChangeType(input, typeof(T));
            }

            return retval;
        }

        /// <summary>
        /// Generic conversion from DBNull to type with specified default value which overrides
        /// the type's defined default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T DBNullToT<T>(object input, T defaultValue) where T : IConvertible
        {
            T retval = defaultValue;

            if (!(input is DBNull))
            {
                if (typeof(T).BaseType.Name == "Enum")
                {
                    return (T)Enum.Parse(typeof(T), input.ToString(), true);
                }
                retval = (T)Convert.ChangeType(input, typeof(T));
            }

            return retval;
        }
    }
}
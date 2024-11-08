using System;
using System.Text;

namespace Base.Utility
{
    public static partial class Utility
    {
        public static class Converter
        {
            private const float InchesToCentimeters = 2.54f; // 1 inch = 2.54 cm
            private const float CentimetersToInches = 1f / InchesToCentimeters; // 1 cm = 0.3937 inches

            public static bool IsLittleEndian => BitConverter.IsLittleEndian;

            public static float ScreenDpi
            {
                get;
                set;
            }

            public static float GetCentimetersFromPixels(float pixels)
            {
                if (ScreenDpi <= 0)
                {
                    throw new GameDKException("You must set screen DPI first.");
                }

                return InchesToCentimeters * pixels / ScreenDpi;
            }

            public static float GetPixelsFromCentimeters(float centimeters)
            {
                if (ScreenDpi <= 0)
                {
                    throw new GameDKException("You must set screen DPI first.");
                }

                return CentimetersToInches * centimeters * ScreenDpi;
            }

            public static float GetInchesFromPixels(float pixels)
            {
                if (ScreenDpi <= 0)
                {
                    throw new GameDKException("You must set screen DPI first.");
                }

                return pixels / ScreenDpi;
            }

            public static float GetPixelsFromInches(float inches)
            {
                if (ScreenDpi <= 0)
                {
                    throw new GameDKException("You must set screen DPI first.");
                }

                return inches * ScreenDpi;
            }

            public static byte[] GetBytes(bool value)
            {
                var buffer = new byte[1];
                GetBytes(value, buffer, 0);

                return buffer;
            }

            public static void GetBytes(bool value, byte[] buffer)
            {
                GetBytes(value, buffer, 0);
            }

            public static void GetBytes(bool value, byte[] buffer, int startIndex)
            {
                if (buffer == null)
                {
                    throw new GameDKException("Buffer is invalid.");
                }

                if (startIndex < 0 || startIndex + 1 > buffer.Length)
                {
                    throw new GameDKException("Start index is invalid.");
                }

                buffer[startIndex] = value ? (byte)1 : (byte)0;
            }

            public static bool GetBoolean(byte[] value)
            {
                return BitConverter.ToBoolean(value, 0);
            }

            public static bool GetBoolean(byte[] value, int startIndex)
            {
                return BitConverter.ToBoolean(value, startIndex);
            }

            public static char GetChar(byte[] value)
            {
                return BitConverter.ToChar(value, 0);
            }

            public static char GetChar(byte[] value, int startIndex)
            {
                return BitConverter.ToChar(value, startIndex);
            }

            public static short GetInt16(byte[] value)
            {
                return BitConverter.ToInt16(value, 0);
            }

            public static ushort GetUInt16(byte[] value)
            {
                return BitConverter.ToUInt16(value, 0);
            }

            public static ushort GetUInt16(byte[] value, int startIndex)
            {
                return BitConverter.ToUInt16(value, startIndex);
            }

            public static int GetInt32(byte[] value)
            {
                return BitConverter.ToInt32(value, 0);
            }

            public static int GetInt32(byte[] value, int startIndex)
            {
                return BitConverter.ToInt32(value, startIndex);
            }

            public static uint GetUInt32(byte[] value)
            {
                return BitConverter.ToUInt32(value, 0);
            }

            public static uint GetUInt32(byte[] value, int startIndex)
            {
                return BitConverter.ToUInt32(value, startIndex);
            }

            public static long GetInt64(byte[] value)
            {
                return BitConverter.ToInt64(value, 0);
            }

            public static long GetInt64(byte[] value, int startIndex)
            {
                return BitConverter.ToInt64(value, startIndex);
            }

            public static ulong GetUInt64(byte[] value)
            {
                return BitConverter.ToUInt64(value, 0);
            }

            public static ulong GetUInt64(byte[] value, int startIndex)
            {
                return BitConverter.ToUInt64(value, startIndex);
            }

            public static float GetSingle(byte[] value)
            {
                return BitConverter.ToSingle(value, 0);
            }

            public static float GetSingle(byte[] value, int startIndex)
            {
                return BitConverter.ToSingle(value, startIndex);
            }

            public static double GetDouble(byte[] value)
            {
                return BitConverter.ToDouble(value, 0);
            }

            public static double GetDouble(byte[] value, int startIndex)
            {
                return BitConverter.ToDouble(value, startIndex);
            }

            public static byte[] GetBytes(string value)
            {
                return Encoding.UTF8.GetBytes(value);
            }

            public static string GetString(byte[] value)
            {
                if (value == null)
                {
                    throw new GameDKException("Value is invalid.");
                }

                return Encoding.UTF8.GetString(value);
            }

            public static string GetString(byte[] value, int startIndex, int length)
            {
                if (value == null)
                {
                    throw new GameDKException("Value is invalid.");
                }

                return Encoding.UTF8.GetString(value, startIndex, length);
            }
        }
    }
}
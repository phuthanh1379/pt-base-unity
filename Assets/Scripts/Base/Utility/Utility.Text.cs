using System;
using System.Globalization;
using System.Text;

namespace Base.Utility
{
    public static partial class Utility
    {
        public static class Text
        {
            private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            [ThreadStatic] private static StringBuilder _cachedStringBuilder = null;

            public static string Format(string format, object arg0)
            {
                if (format == null)
                {
                    throw new GameDKException("Format is invalid.");
                }

                CheckCachedStringBuilder();
                _cachedStringBuilder.Length = 0;
                _cachedStringBuilder.AppendFormat(format, arg0);

                return _cachedStringBuilder.ToString();
            }

            public static string Format(string format, object arg0, object arg1)
            {
                if (format == null)
                {
                    throw new GameDKException("Format is invalid.");
                }

                CheckCachedStringBuilder();
                _cachedStringBuilder.Length = 0;
                _cachedStringBuilder.AppendFormat(format, arg0, arg1);

                return _cachedStringBuilder.ToString();
            }

            public static string Format(string format, object arg0, object arg1, object arg2)
            {
                if (format == null)
                {
                    throw new GameDKException("Format is invalid.");
                }

                CheckCachedStringBuilder();
                _cachedStringBuilder.Length = 0;
                _cachedStringBuilder.AppendFormat(format, arg0, arg1, arg2);

                return _cachedStringBuilder.ToString();
            }

            public static string Join<T>(T[] array, char separator)
            {
                CheckCachedStringBuilder();
                _cachedStringBuilder.Length = 0;
                var count = array.Length;
                for (var i = 0; i < count; ++i)
                {
                    _cachedStringBuilder.Append(array[i]).Append(separator);
                }

                return _cachedStringBuilder.ToString().TrimEnd(separator);
            }

            private static void CheckCachedStringBuilder()
            {
                _cachedStringBuilder ??= new StringBuilder(1024);
            }

            public static string SizeSuffix(long value, int decimalPlaces = 1)
            {
                if (decimalPlaces < 0)
                {
                    return string.Empty;
                }

                if (value < 0)
                {
                    return "-" + SizeSuffix(-value);
                }

                if (value == 0)
                {
                    return string.Format(CultureInfo.InvariantCulture, "{0:n" + decimalPlaces + "} bytes", 0);
                }

                var maq = (int)Math.Log(value, 1024);
                var adjustedSize = (decimal)value / (1L << (maq * 10));

                if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
                {
                    maq += 1;
                    adjustedSize /= 1024;
                }

                return string.Format(CultureInfo.InvariantCulture, "{0:n" + decimalPlaces + "} {1}", adjustedSize,
                    SizeSuffixes[maq]);
            }
        }
    }
}
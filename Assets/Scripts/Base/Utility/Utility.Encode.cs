using System;
using System.Security.Cryptography;
using System.Text;

namespace Base.Utility
{
    public static partial class Utility
    {
        public static class Encode
        {
            private static readonly Random _random = new();

            public static Rfc2898Value Rfc2898(string token)
            {
                var challenge = string.Empty;
                var hash = string.Empty;
                if (string.IsNullOrEmpty(token))
                {
                    return new(challenge, hash);
                }

                var value = _random.Next(0, int.MaxValue);
                var invertChallenge = value.ToString("X8");
                var password = Encoding.UTF8.GetBytes(invertChallenge);

                // Invert challenge
                var bytes = Encoding.UTF8.GetBytes(invertChallenge);
                for (var i = 0; i < bytes.Length; ++i)
                {
                    bytes[i] = (byte)(255 - bytes[i]);
                }

                challenge = Convert.ToBase64String(bytes);

                // Generate salt
                var pos = value % token.Length;
                var salt = Encoding.UTF8.GetBytes(token.Remove(pos, 1));
                var encrypt = new Rfc2898DeriveBytes(password, salt, 100);

                hash = Convert.ToBase64String(encrypt.GetBytes(16));
                return new(challenge, hash);
            }

            public record Rfc2898Value(string Challenge, string Hash);
        }
    }
}
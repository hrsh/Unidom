using System;
using System.Collections.Generic;

namespace Unidom
{
    public struct Uuid
    {
        public static Uniky Random(
            int min,
            int max,
            UnikyOptions options = null) =>
            new Uniky(new Utils(options).Random(min, max));

        public static Uniky Random(
            int length,
            UnikyOptions options = null) =>
            new Uniky(new Utils(options).Random(length));

        public static Uniky Odd(
            int length,
            bool allowDuplicate = false) =>
            new Uniky(new Utils(new UnikyOptions
            {
                AllowDuplicate = allowDuplicate,
                UseCapitalLetters = false,
                UseDigits = true,
                UseSmallLetters = false,
                UseSpecialLetters = false
            }).Odd(length, allowDuplicate));

        public static Uniky Even(
            int length,
            bool allowDuplicate = false) =>
            new Uniky(new Utils(new UnikyOptions
            {
                AllowDuplicate = allowDuplicate,
                UseCapitalLetters = false,
                UseDigits = true,
                UseSmallLetters = false,
                UseSpecialLetters = false
            }).Even(length, allowDuplicate));
    }

    public static class UnikyExtensions
    {
        public static Uniky Flat(this Uniky source, int chunk, string seperator = "-")
        {
            if (source.Value.Length < chunk) return source;
            var splited = source.Value.SplitInParts(chunk);
            return string.Join(seperator, splited);
        }

        private static IEnumerable<string> SplitInParts(this string source, int chunk)
        {
            if (source == null)
                yield return string.Empty;
            if (chunk <= 0)
                yield return string.Empty;

            for (var i = 0; i < source.Length; i += chunk)
                yield return source.Substring(i, Math.Min(chunk, source.Length - i));
        }
    }
}
using System;
using System.Security.Cryptography;
using System.Text;

namespace Unidom
{
    internal class Utils
    {
        private readonly RNGCryptoServiceProvider _cryptoServiceProvider;
        private readonly UnikyOptions _options;

        private const string _capitalChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string _smallchars = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string _numbers = "0123456789";
        private static readonly string _specialChars = @"!@#$%*~[]{}/|\=+";

        private readonly char[] _source = new char[0];
        private string _resultHolder;

        public Utils(UnikyOptions options)
        {
            _cryptoServiceProvider = new RNGCryptoServiceProvider();
            _options = options ?? new UnikyOptions();

            if (!_options.UseCapitalLetters &&
                !_options.UseDigits &&
                !_options.UseSmallLetters)
                throw new ArgumentException();

            var builder = new StringBuilder();

            if (_options.UseCapitalLetters)
                builder.Append(_capitalChars);

            if (_options.UseSmallLetters)
                builder.Append(_smallchars);

            if (_options.UseDigits)
                builder.Append(_numbers);

            if (_options.UseSpecialLetters)
                builder.Append(_specialChars);

            _source = builder.ToString().ToCharArray();
            _resultHolder = string.Empty;
        }

        internal string Random(int min, int max) =>
            Random(SetOutputLength(min, max));

        internal string Random(int length)
        {
            if (_source.Length < length)
                throw new ArgumentException("Source length could not be less than output lenght!");

            for (var i = 0; i < length; i++)
            {
                var @char = _source[Position % _source.Length];
                if (!_options.AllowDuplicate && _resultHolder.Contains(@char))
                {
                    do
                    {
                        @char = _source[Position % _source.Length];
                    } while (_resultHolder.Contains(@char));
                }
                _resultHolder += @char;
            }

            return _resultHolder;
        }

        private int Position
        {
            get
            {
                var bytes = new byte[2];
                _cryptoServiceProvider.GetNonZeroBytes(bytes);
                var number = BitConverter.ToInt16(bytes, 0);
                return number < 0 ? -number : number;
            }
        }

        private int SetOutputLength(int min, int max)
        {
            if (min > max)
                throw new ArgumentException("Minimum length could NOT be greater than maximum length!");
            return min + (Position % (max - min));
        }
    }
}
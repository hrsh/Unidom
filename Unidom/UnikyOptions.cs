namespace Unidom
{
    public class UnikyOptions
    {
        public bool UseCapitalLetters { get; set; } = true;

        public bool UseSmallLetters { get; set; } = true;

        public bool UseDigits { get; set; } = true;

        public bool UseSpecialLetters { get; set; }

        public bool AllowDuplicate { get; set; } = false;
    }
}
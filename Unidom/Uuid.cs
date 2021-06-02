namespace Unidom
{
    public class Uuid
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
    }
}
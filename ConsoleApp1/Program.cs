using System;
using Unidom;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 20; i++)
            {
                var o = Uuid.Odd(16, true).Flat(4, "-");
                var e = Uuid.Even(16, true).Flat(4);
                Console.WriteLine($"Odd: {o} - Even: {e}");
            }

            Console.WriteLine(Uuid.Random(8).Flat(4).Value);

            Console.ReadLine();
        }
    }
}

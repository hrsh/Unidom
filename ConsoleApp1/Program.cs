using System;
using Unidom;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Uuid.Random(4, 8);
            Console.WriteLine(t.Value);
            Console.ReadLine();
        }
    }
}

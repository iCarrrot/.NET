using System;
using System.IO;
using System.Linq;

namespace z2_4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var join = from r1 in File.ReadLines("inp.txt")
                       join r2 in File.ReadLines("pnk.txt") on r1.Split(" ").ElementAt(2) equals r2.Split(" ").ElementAt(0)
                       select r1 + " " + r2.Split(" ").ElementAt(1);
            foreach (var i in join)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }

    }
}

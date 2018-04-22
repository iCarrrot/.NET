using System;
using System.IO;
using System.Linq;

namespace z2_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liczby = File.ReadLines("liczby.txt").Select(int.Parse).ToArray();
            var v1 = from l in liczby
                     where l > 100
                     orderby l descending
                     select l;
            foreach (var i in v1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            var v2 = liczby.Where(n => n > 100).OrderByDescending(n => n).Select(n => n);

            foreach (var i in v2)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}

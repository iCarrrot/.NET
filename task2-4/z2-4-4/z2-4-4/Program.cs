using System;
using System.IO;
using System.Linq;

namespace z2_4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirs = new DirectoryInfo("C:/Users/michal/Documents/GitHub/.NET");
            var lens = dirs.GetFiles().Select(x => x.Length);
            var sum = lens.Aggregate((x, y) => x + y);
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}

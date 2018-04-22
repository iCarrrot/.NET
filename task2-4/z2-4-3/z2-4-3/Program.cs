using System;
using System.IO;
using System.Linq;

namespace z2_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = from name in File.ReadLines("nazwiska.txt").ToArray()
                        group name by name[0] into l
                        orderby l.Key
                        select l.Key;
            foreach(var l in names)
            {
                Console.WriteLine(l);
            }

            Console.ReadKey();
        }
    }
}

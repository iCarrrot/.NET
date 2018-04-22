using System;
using System.IO;
using System.Linq;


namespace z2_4_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var ips = from line in File.ReadLines("log.txt").ToArray()
                      group line by line.Split(" ").ElementAt(1) into gip
                      orderby gip.Count() descending
                      select new { ip = gip.Key, count = gip.Count() };
            foreach (var i in ips.Take(3))
            {
                Console.WriteLine("{0}: {1}", i.ip, i.count);
            }

            Console.ReadKey();
        }
    }
}

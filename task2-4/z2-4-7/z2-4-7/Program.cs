using System;
using System.Linq;

namespace z2_4_7
{
    class Program
    {
        static void Main(string[] args)
        {
            var item1 = new { Field1 = "The value1", Field2 = 5 };
            var item2 = new { Field1 = "The value2", Field2 = 10 };
            var list = new[] { item1, item2 }.ToList();
            list.Add(new { Field1 = "The value3", Field2 = 15 });
            foreach (var v in list)
            {
                Console.WriteLine("Field1={0}, Field2={1}", v.Field1, v.Field2);
            }
            Console.ReadKey();
        }
    }
}

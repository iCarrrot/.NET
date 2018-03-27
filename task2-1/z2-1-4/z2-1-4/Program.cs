using System;
using System.Reflection;
using System.Linq;

namespace z2_1_4
{
    public class Oznakowane : Attribute { }
    class Foo
    {
        [Oznakowane]
        public int goodB()
        {
            return 0;
        }

        public int badB1()
        {
            return 1;
        }

        [Oznakowane]
        public char badB2()
        {
            return 'a';
        }

        [Oznakowane]
        public static int badB3()
        {
            return 3;
        }

        [Oznakowane]
        private int basB4()
        {
            return 4;
        }

        [Oznakowane]
        public int badB5(int a)
        {
            return 5+a;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Foo o = new Foo();
            przejrzyj(o);

            Console.ReadKey();
        }

        static void przejrzyj(object o)
        {
            Type typeO = o.GetType();
            MethodInfo[] metody = typeO.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            var good = from a in metody
                       where a.ReturnType == typeof(int) &&
                       a.GetParameters().Length == 0 &&
                       a.GetCustomAttributes(typeof(Oznakowane)).Count() > 0
                       select a;
            foreach(MethodInfo met in good)
            {
                Console.WriteLine($"Metoda: {met}: {met.Invoke(o, null)}");
            }

        }
    }
}

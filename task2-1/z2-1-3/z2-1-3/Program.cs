using System;
using System.Reflection;

/// <summary>
/// zadanie 4
/// </summary>
namespace z2_1_3
{
    /// <summary>
    /// przykłądowa klasa
    /// </summary>
    class Foo
    {
        /// <summary>
        /// licznik
        /// </summary>
        private int _licznik = 0;

        /// <summary>
        /// prywatny licznik
        /// </summary>
        private int licznik
        {
            get
            {
                return _licznik++;
            }
        }

        /// <summary>
        /// licznik 2
        /// </summary>
        private int _pub = 0;
        /// <summary>
        /// publiczny licznik 2
        /// </summary>
        public int Pub
        {
            get
            {
                return _pub++;
            }
        }
        /// <summary>
        /// konstruktor
        /// </summary>
        public Foo() { }
        /// <summary>
        /// przeciążenie konstruktora
        /// </summary>
        /// <param name="i"> stan początkowy prywatnego licznika</param>
        public Foo(int i) { _licznik = i; }
    }
    class Program
    {
        /// <summary>
        ///Główna funkcja programu
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Foo obiekt = new Foo(10);
            int j = 0;
            var prywatnePola = obiekt.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var prywatneWla = obiekt.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var p in prywatneWla)
            {
                Console.WriteLine($"Właściwość: {p.Name}, wartość: {p.GetValue(obiekt)}");
            }

            foreach (var p in prywatnePola)
            {
                Console.WriteLine($"Pole: {p.Name}, wartość: {p.GetValue(obiekt)}");
            }

            int LiczbaProb = 10000000;
            DateTime Start = DateTime.Now;
            for (int i = 0; i < LiczbaProb; ++i)
            {
                j += obiekt.Pub;
            }
            DateTime End = DateTime.Now;
            Console.WriteLine($"Dostęp bezpośredni: {(End - Start):ss\\.ffffff}s. Wynik {j}");

            j = 0;

            Start = DateTime.Now;
            for (int i = 0; i < LiczbaProb; ++i)
            {
                j +=(int)obiekt.GetType().GetProperty("Pub").GetValue(obiekt);
 
            }
            End = DateTime.Now;
            Console.WriteLine($"Dostęp przez refleksje: {(End - Start):ss\\.ffffff}s. Wynik {j}");
            

            Console.ReadKey();  



        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace z2_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = new List<int>();
            ArrayList arrLista = new ArrayList();
            int repeats = 1000000;
            int less = 10000;


            DateTime start = DateTime.Now;
            for (int i = 0; i < repeats; ++i)
            {
                lista.Add(i);
            }
            DateTime end = DateTime.Now;
            Console.WriteLine($"Dodawanie do list<int>: {end - start}");

            start = DateTime.Now;
            for (int i = 0; i < repeats; ++i)
            {
                arrLista.Add(i);
            }
            end = DateTime.Now;
            Console.WriteLine($"Dodawanie do ArrayList: {end - start}");

            int sum = 0;
            start = DateTime.Now;
            foreach (int i in lista)
            {
                sum += i;
            }
            end = DateTime.Now;
            Console.WriteLine($"Czytanie list<int>: {end - start}, {sum}");

            sum = 0;
            start = DateTime.Now;
            foreach (int i in arrLista)
            {
                sum += i;
            }
            end = DateTime.Now;
            Console.WriteLine($"Czytanie ArrayList: {end - start}, {sum}");

            start = DateTime.Now;
            for (int i = 0; i < repeats/less; ++i)
            {
                lista.Remove(i);
            }
            end = DateTime.Now;
            Console.WriteLine($"Usuwanie z list<int>: {(end - start)*less}");

            start = DateTime.Now;
            for (int i = 0; i < repeats / less; ++i)
            {
                arrLista.Remove(i);
            }
            end = DateTime.Now;
            Console.WriteLine($"Usuwanie z ArrayList: {(end - start) * less}");

            Console.WriteLine("\n\n\n");

            Dictionary<string, int> dict = new Dictionary<string, int>();
            Hashtable tab = new Hashtable();


            start = DateTime.Now;
            for (int i = 0; i < repeats; ++i)
            {
                dict.Add(i.ToString(), i);
            }
            end = DateTime.Now;
            Console.WriteLine($"Dodawanie do słownika: {end - start}");

            start = DateTime.Now;
            for (int i = 0; i < repeats; ++i)
            {
                tab.Add(i.ToString(), i);
            }
            end = DateTime.Now;
            Console.WriteLine($"Dodawanie do tablicy: {end - start}");

            sum = 0;
            start = DateTime.Now;
            foreach (KeyValuePair<string, int> kvp in dict)
            {
                sum += kvp.Value;
            }
            end = DateTime.Now;
            Console.WriteLine($"Czytanie słownika: {end - start}, {sum}");

            sum = 0;
            start = DateTime.Now;
            foreach (DictionaryEntry de in tab)
            {
                sum += (int)de.Value;
            }
            end = DateTime.Now;
            Console.WriteLine($"Czytanie tablicy: {end - start}, {sum}");



            start = DateTime.Now;
            for (int i = 0; i < repeats; ++i)
            {
                dict.Remove(i.ToString());
            }
            end = DateTime.Now;
            Console.WriteLine($"Usuwanie z słownika: {end - start}");

            start = DateTime.Now;
            for (int i = 0; i < repeats; ++i)
            {
                tab.Remove(i.ToString());
            }
            end = DateTime.Now;
            Console.WriteLine($"Usuwanie z tablicy: {end - start}");



            Console.ReadKey();
        }
    }
}

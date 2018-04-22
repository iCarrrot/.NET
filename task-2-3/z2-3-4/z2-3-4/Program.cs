using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z2_3_4
{
    public class ListHelper
    {
        public static List<TOutput> ConvertAll<T, TOutput>(List<T> list, Converter<T, TOutput> converter)
        {
            List<TOutput> lista = new List<TOutput>();
            foreach (T elem in list)
            {
                lista.Add(converter(elem));
            }
            return lista;
        }
        public static List<T> FindAll<T>(List<T> list, Predicate<T> match)
        {
            List<T> lista = new List<T>();
            foreach (T elem in list)
            {
                if( match(elem))
                    lista.Add(elem);
            }
            return lista;
        }
        public static void ForEach<T>(List<T> list, Action<T> action)
        {
            foreach (T elem in list)
            {
                action(elem);
            }
        }
        public static int RemoveAll<T>(List<T> list,Predicate<T> match)
        {
            int licznik = 0;
            int usunieto = 0;
            while (licznik < list.Count)
            {
                if (match(list[licznik]))
                {
                    list.RemoveAt(licznik);
                    usunieto++;
                }
                else
                    licznik++;
            }
            return usunieto;
        }
        public static void Sort<T>(List<T> list, Comparison<T> comparison)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                for (int j = i; j < list.Count - 1; ++j)
                {
                    if (comparison(list[j], list[j + 1]) > 0)
                    {
                        T tmp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = tmp;
                    }
                }
            }
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            
            List<int> lista = new List<int>();
            for (int i = 0; i < 10; ++i) lista.Add(i);
            List<int> lista3 = ListHelper.ConvertAll(lista,x => 3 * x);
            List<int> przez3 = ListHelper.FindAll(lista, x => lista3.Contains(x));
            ListHelper.ForEach(przez3, x => Console.WriteLine($"Liczba podzielna przez 3: {x}"));
            Console.WriteLine($"Usunieto {lista.RemoveAll(x => przez3.Contains(x))} elementy");
            ListHelper.Sort(lista, (x, y) => y - x);
            foreach (int i in lista)
            {
                Console.Write($"{i}, ");
            }
            Console.ReadKey();
        }

    }
}

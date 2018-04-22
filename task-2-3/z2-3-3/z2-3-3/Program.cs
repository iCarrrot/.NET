using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_2._3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = new List<int>();
            for (int i = 0; i < 10; ++i) lista.Add(i);

            List<int> lista3 = lista.ConvertAll(x => 3*x);
            List<int> przez3 = lista.FindAll(x => lista3.Contains(x));
            przez3.ForEach(x => Console.WriteLine($"Liczba podzielna przez 3: {x}"));
            Console.WriteLine($"Usunieto {lista.RemoveAll(x => przez3.Contains(x))} elementy");
            lista.Sort((x, y) => y - x);
            foreach (int i in lista)
            {
                Console.Write($"{i}, ");
            }

            Console.ReadKey();
        }
    }
}
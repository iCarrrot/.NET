using System;

namespace z2_1_2
{
    public class Grid
    {
        private int a,b;
        private int[,] array;
        public Grid(int i, int j)
        {
            a = i;
            b = j;
            array = new int[i, j];
        }
        public int[] this[int i]
        {
            get
            {
                int[] row = new int[b];
                for(int it=0; it<b; it++)
                {
                    row[it] = array[i, it];
                }
                return row;
            }
        }
        public int this [int i, int j]
        {
            get
            {
                return array[i, j];
            }
            set
            {
                array[i, j] = value;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid(10, 5);
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 5; j++)
                    grid[i, j] = 10 * i + j;
            int[] tab = grid[2];
            for (int j = 0; j < 5; j++)
                Console.WriteLine(tab[j]);
            int x = grid[7][3];
            Console.WriteLine(x);
            Console.ReadKey();
        }
    }
}

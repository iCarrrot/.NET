using System;

namespace z2_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            for (int i = 1; i < 100000; i++)
            {
                int sum = 0;
                int t = i;
                bool isSpecial = true;
                while (t > 0 && isSpecial && t % 10 != 0)
                {
                    if (i % (t % 10) == 0)
                    {
                        sum += t % 10;
                        t = t / 10;
                    }
                    else
                    {
                        isSpecial = false;
                    }
                }
                if (sum!= 0)
                {
                    if (isSpecial && i % sum == 0 && (t==0||t % 10 != 0))
                    {
                        Console.WriteLine(i);
                    }
                }
                
            }
            Console.ReadKey();
        }
    }
}

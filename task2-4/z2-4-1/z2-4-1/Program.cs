using System;

namespace z2_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Kobyła ma mały bok.";
            bool ispalindrome = s.IsPalindrome();
            Console.WriteLine(ispalindrome);
            Console.ReadKey();
        }
    }
    static class stringHelper
    {
        public static bool IsPalindrome(this string input)
        {
            string str = input.ToLower();
            int l = 0, r = str.Length - 1;
            while (l <= r)
            {
                while (!char.IsLetter(str, l)) l++;
                while (!char.IsLetter(str, r)) r--;
                if (str[l] != str[r]) return false;
                l++;
                r--;
            }
            return true;
        }
    }
        
}

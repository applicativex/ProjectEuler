using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4.LargestPalindromeProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            var largestPalindrome = (from a in Enumerable.Range(100, 900)
                                     from b in Enumerable.Range(100, 900)
                                     let p = a * b
                                     where IsPalindrome(p)
                                     select new { A = a, B = b, Palindrome = p }).OrderByDescending(p => p.Palindrome);
        }

        private static int Reverse(int number)
        {
            int reversed = 0;

            while (number > 0)
            {
                reversed = reversed * 10 + number % 10;
                number = number / 10;
            }

            return reversed;
        }

        private static bool IsPalindrome(int number)
        {
            return number == Reverse(number);
        }
    }
}

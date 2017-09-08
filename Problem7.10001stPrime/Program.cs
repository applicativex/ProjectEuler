using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7._10001stPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            var prime = Sieve(150000).ToArray();
        }

        private static IEnumerable<int> Sieve(int n)
        {
            bool[] isPrime = Enumerable.Range(0, n)
                .Select(t => true)
                .ToArray();

            isPrime[0] = isPrime[1] = false;
            var nSquareRoot = (int)Math.Floor(Math.Pow(n, 0.5));

            for (int i = 2; i <= nSquareRoot; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j < n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            for (int i = 2; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    yield return i;
                }
            }
        }
    }
}

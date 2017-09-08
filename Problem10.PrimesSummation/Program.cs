using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10.PrimesSummation
{
    class PrimesSequence : IEnumerable<int>
    {
        private readonly int _upperLimit;

        public PrimesSequence(int upperLimit)
        {
            _upperLimit = upperLimit;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int n = _upperLimit;

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

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var limit = 2000000;
            var primes = new PrimesSequence(limit);
            long sum = 0;
            sum = primes.Aggregate(sum, (s, i) => s + i);
            Console.WriteLine(sum);
        }
    }
}

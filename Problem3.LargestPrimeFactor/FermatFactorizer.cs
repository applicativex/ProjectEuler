using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3.LargestPrimeFactor
{
    class FermatFactorizer
    {
        private readonly long _number;

        public FermatFactorizer(long number)
        {
            _number = number;
        }

        private static IEnumerable<long> Factorize(long number)
        {
            if (number == 1)
            {
                return Enumerable.Empty<long>();
            }

            double y;
            long k = 0, s = (long)Math.Pow(number, 0.5);

            while (!IsInteger(y = Math.Pow((s + k) * (s + k) - number, 0.5)))
            {
                k++;
            }

            long a = s + k + (long)y;
            long b = s + k - (long)y;

            if (a == number)
            {
                return new[] { number };
            }

            return Factorize(a).Concat(Factorize(b));
        }

        private static bool IsInteger(double number)
        {
            return number % 1 == 0;
        }

        public IEnumerable<PrimeFactor> GetPrimeFactors()
        {
            var primeFactors = from pf in Factorize(_number)
                group pf by pf
                into g
                select new PrimeFactor { Value = g.Key, Multiplicity = g.Count() };

            return primeFactors;
        }
    }
}
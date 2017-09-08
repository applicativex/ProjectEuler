using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.Multiples3or5
{
    static class Program
    {
        static void Main(string[] args)
        {
            var upperBound = 1000;
            var range = Enumerable.Range(1, upperBound - 1);

            // simple method
            var simpleSum = range.Where(t => t%3 == 0 || t%5 == 0).Sum();

            // complex method
            var complexSum = range.SumMultiples(3, 5, 7, 87, 701);
        }

        public static long SumMultiples(this IEnumerable<int> range, params int[] multiplies)
        {
            var multipliersWithExclusions = multiplies.SelectMany(
                m => from t in multiplies
                     where t >= m
                     select t == m
                         ? new { Multiplier = m, Index = 1 }
                         : new { Multiplier = t * m, Index = -1 });

            Func<IEnumerable<int>, int, long> sumDivisibleBy = (sequence, multiplier) =>
            {
                int maxMultiple = sequence.Max() / multiplier;
                return multiplier * maxMultiple * (maxMultiple + 1) / 2;
            };

            return multipliersWithExclusions.Select(m => sumDivisibleBy(range, m.Multiplier) * m.Index)
                .Sum();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5.SmallestMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = Enumerable.Range(1, 20).Select(e => (long) e);

            var sm = LeastCommonMultiple(range);
        }

        private static long GreatestCommonDivisor(long a, long b)
        {
            while (b != 0)
            {
                long r = a % b;
                a = b;
                b = r;
            }

            return a;
        }

        private static long LeastCommonMultiple(long a, long b)
        {
            return (a * b) / GreatestCommonDivisor(a, b);
        }

        private static long LeastCommonMultiple(IEnumerable<long> range)
        {
            return range.Aggregate((a, b) => LeastCommonMultiple(a, b));
        }
    }
}

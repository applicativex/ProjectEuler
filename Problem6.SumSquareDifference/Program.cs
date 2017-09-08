using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6.SumSquareDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = Enumerable.Range(1, 100).ToArray();
            long sum = 0;

            var combinations = (from i in range
                                from j in range.Skip(i)
                                select 2 * i * j).Aggregate(sum, (s, i) => s + i);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3.LargestPrimeFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            var primeFactors = new FermatFactorizer(600851475143).GetPrimeFactors().Max(t => t.Value);
        }
    }
}

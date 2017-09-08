using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.FibonacciEvens
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = new FibonacciSequence(4000000).Where(t => t%2 == 0).Sum();

            foreach (var i in new FibonacciSequence(4000000))
            {
                Console.WriteLine("{0} has {1} digits", i, Math.Floor(Math.Log10(i)) + 1);
            }
        }

        class FibonacciSequence : IEnumerable<int>
        {
            private readonly int _upperLimit;
            private int _previous = 1;
            private int _current = 1;

            public FibonacciSequence(int upperLimit)
            {
                _upperLimit = upperLimit;
            }

            public IEnumerator<int> GetEnumerator()
            {
                yield return _previous;
                yield return _current;

                while (_current + _previous < _upperLimit)
                {
                    var next = _previous + _current;
                    _previous = _current;
                    yield return _current = next;
                }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}

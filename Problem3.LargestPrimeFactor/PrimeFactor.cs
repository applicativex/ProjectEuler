using System.Text;
using System.Threading.Tasks;

namespace Problem3.LargestPrimeFactor
{
    class PrimeFactor
    {
        public long Value { get; set; }
        public int Multiplicity { get; set; }

        public override string ToString()
        {
            return string.Format("{0}; {1}", Value, Multiplicity);
        }
    }
}

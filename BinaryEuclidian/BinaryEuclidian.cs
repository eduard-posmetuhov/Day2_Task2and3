using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryEuclidian
{
    public class BinaryEuclidian
    {
        public static int GCD(int a, int b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentException("Числа должны быть положительные");
            if (a == 0) return b;
            if (b == 0) return a;
            if (a == b) return a;
            if (a == 1 || b == 1) return 1;
            if ((a % 2 == 0) && (b % 2 == 0)) return 2 * GCD(a / 2, b / 2);
            if ((a % 2 == 0) && (b % 2 != 0)) return GCD(a / 2, b);
            if ((a % 2 != 0) && (b % 2 == 0)) return GCD(a, b / 2);
            return GCD(b, (int)Math.Abs(a - b));
        }
        public static int GCD(int a, int b, int c)
        {
            return GCD(GCD(a,b),b);
        }
        public static int GCD(params int[]arr)
        {
            Func<int, int, int> delig = GCD;
            return arr.Aggregate<int>(delig);            
        }
    }
}

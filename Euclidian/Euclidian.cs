//Извените, но сначала написал методы, время выпонения оставил на потом
// чтобы не переписывать методы оценку времени сделал как обертку
//над private методами

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclidian
{
    public class Euclidian
    {
        public static int GreatestCommonDivisor(out double ms, int a, int b)
        {
            DateTime Start = DateTime.Now;
            int temp = GreatestCommonDivisor(a, b);
            ms = (DateTime.Now - Start).TotalMilliseconds;
            return temp;
        }

        public static int GreatestCommonDivisor(out double ms, int a, int b, int c)
        {
            DateTime Start = DateTime.Now;
            int temp = GreatestCommonDivisor(a,b,c);
            ms = (DateTime.Now - Start).TotalMilliseconds;
            return temp;
        }

        public static int GreatestCommonDivisor( out double ms, params int[] arr)
        {
            DateTime Start = DateTime.Now;
            int temp = GreatestCommonDivisor(arr);
            ms = (DateTime.Now - Start).TotalMilliseconds;
            return temp;
        }
        private static int GreatestCommonDivisor(int a,int b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentException("Допускаються только положительные значения");
            if (b>a)
            {
                int temp = a;
                a = b;
                b = temp;
            }
            if (b == 0) return a;
             return GreatestCommonDivisor(b, a % b);            
        }
        private static int GreatestCommonDivisor(int a, int b, int c)
        {
            return GreatestCommonDivisor(GreatestCommonDivisor(a,b),c);
        }
        private static int GreatestCommonDivisor(params int[] arr)
        {
            Func<int, int, int> delig = GreatestCommonDivisor;
            return arr.Aggregate<int>(delig);
        }       
    }
}

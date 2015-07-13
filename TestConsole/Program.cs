using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomHexProvider;
using Euclidian;
using BinaryEuclidian;
namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = -1;
                Console.WriteLine("{0:X}", a);
                string s = String.Format(new CustomHexProvider.CustomHexProvider(), "{0:CH}", a);
                Console.WriteLine(s);
                double ts; 
                Console.WriteLine("НОД={0} Время={1} мс",Euclidian.Euclidian.GreatestCommonDivisor(out ts,96, 72),ts);
               // Console.WriteLine(Euclidian.Euclidian.GreatestCommonDivisor(78, 294, 570));
                Console.WriteLine("НОД={0} Время={1} мс",Euclidian.Euclidian.GreatestCommonDivisor(out ts,220, 110,22,33,44,55,66,77,88,99),ts);
               // Console.WriteLine(BinaryEuclidian.BinaryEuclidian.GCD(72, 96));
               // Console.WriteLine(BinaryEuclidian.BinaryEuclidian.GCD(78, 294, 570));
               // Console.WriteLine(BinaryEuclidian.BinaryEuclidian.GCD(78, 294, 570, 3, 12));
            }
            catch (ArgumentException AExp)
            {
                Console.WriteLine(AExp.Message);
            }
            catch (InvalidCastException ICExp)
            {
                Console.WriteLine(ICExp.Message);
            }

            
        }
    }
}

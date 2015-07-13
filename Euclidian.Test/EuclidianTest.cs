using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Euclidian;

namespace Euclidian.Test
{
    [TestClass]
    public class EuclidianTest
    {
        [TestMethod]
        public void EuclidTwoArgs()
        {
            double time;
            int first = 96;
            int second = 72;
            Assert.AreEqual(Euclidian.GreatestCommonDivisor(out time, first, second), 24);
        }
        [TestMethod]
        public void EuclidTreeArgs()
        {
            double time;
            int first = 11;
            int second = 110;
            int third = 22;
            Assert.AreEqual(Euclidian.GreatestCommonDivisor(out time, first, second,third), 11);
        }

        [TestMethod]
         public void EuclidArrayArgs()
        {
            double time;
            int [] arr = {22,33,44,55,66,77,88,99,110};
            Assert.AreEqual(Euclidian.GreatestCommonDivisor(out time, arr), 11);
        }

        [TestMethod]
        public void EuclidBadArgs()
        {
            try
            {
                double time;
                int[] arr = { 22, 33, 44, 55, 66, 77, 88, 99, -110 };
                Euclidian.GreatestCommonDivisor(out time, arr);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, "Допускаються только положительные значения");
            }           
        }

    }
}

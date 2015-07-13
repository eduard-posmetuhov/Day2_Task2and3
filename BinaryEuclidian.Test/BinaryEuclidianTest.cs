using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryEuclidian;

namespace BinaryEuclidian.Test
{
    [TestClass]
    public class BinaryEuclidianTest
    {
        [TestMethod]
        public void BinEuclidTwoArgs()
        {            
            int first = 96;
            int second = 72;
            Assert.AreEqual(BinaryEuclidian.GCD(first, second), 24);
        }

        [TestMethod]
        public void BinEuclidTreeArgs()
        {
            int first = 11;
            int second = 110;
            int third = 22;
            Assert.AreEqual(BinaryEuclidian.GCD(first, second,third), 11);
        }

        [TestMethod]
        public void BinEuclidArrayArgs()
        {
            int[] arr = { 22, 33, 44, 55, 66, 77, 88, 99, 110 };
            Assert.AreEqual(BinaryEuclidian.GCD(arr), 11);
        }

        [TestMethod]
        public void BinEuclidBadArgs()
        {
            try
            {
                int[] arr = { 22, 33, 44, 55, 66, 77, 88, 99, -110 };
                BinaryEuclidian.GCD(arr);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, "Числа должны быть положительные");
            }
        }
        
    }
}

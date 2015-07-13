using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomHexProvider;

namespace CustomHexProvider.Test
{
    [TestClass]
    public class CustomHexProviderTest
    {
        [TestMethod]
        public void CHPMaxValue()
        {
            string result = String.Format(new CustomHexProvider(),"{0:CH}",Int32.MaxValue);
            Assert.AreEqual(result,String.Format("{0:X}",Int32.MaxValue));
        }
        [TestMethod]
        public void CHPMinValue()
        {
            string result = String.Format(new CustomHexProvider(), "{0:CH}", Int32.MinValue);
            Assert.AreEqual(result, String.Format("{0:X}", Int32.MinValue));
        }
        [TestMethod]
        public void CHPZero()
        {
            string result = String.Format(new CustomHexProvider(), "{0:CH}", 0);
            Assert.AreEqual(result, String.Format("{0:X}", 0));
        }

        [TestMethod]
        public void CHPBadArgs()
        {
            try
            {
                string result = String.Format(new CustomHexProvider(), "{0:CH}", "BadArgs");
            }
            catch (InvalidCastException e)
            {
                StringAssert.Contains(e.Message, "Неверный формат аргумента");
            }
        }

        [TestMethod]
        public void CHPBadFormat()
        {
            try
            {
                string result = String.Format(new CustomHexProvider(), "{0:BadFormat}", 10);
            }
            catch (FormatException e)
            {
                StringAssert.Contains(e.Message, "The BadFormat format specifier is invalid");
            }
        }

        [TestMethod]
        public void CHPNotFormat()
        {
                string result = String.Format(new CustomHexProvider(), "{0}", 15);
                Assert.AreEqual(result, String.Format("{0:X}", 15));                        
        }

        [TestMethod]
        public void CHPFloatArgs()
        {
            try
            {
                string result = String.Format(new CustomHexProvider(), "{0:CH}", 15.1);
            }
            catch (InvalidCastException e)
            {
                StringAssert.Contains(e.Message, "Неверный формат аргумента");
            }
        }
    }
}

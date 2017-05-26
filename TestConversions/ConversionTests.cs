using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocationNumerals;
using System.Collections;

namespace TestConversions
{
    [TestClass]
    public class ConversionTests
    {
        [TestMethod]
        public void TestNumeralToDecimal()
        {
            int result;
            string numeral;
            LocationNumeralConverter converter = new LocationNumeralConverter();
            numeral = "acc";
            result = converter.ConvertToDecimal(numeral);
            Assert.IsTrue(result==9);
            numeral = "abbc";
            result = converter.ConvertToDecimal(numeral);
            Assert.IsTrue(result == 9);
            numeral = "bcba";
            result = converter.ConvertToDecimal(numeral);
            Assert.IsTrue(result == 9);
            numeral = "abceg";
            result = converter.ConvertToDecimal(numeral);
            Assert.IsTrue(result == 87);
        }

        [TestMethod]
        public void TestDecimalToNumeral()
        {
            string result;
            int decimalToConvert = 9;
            LocationNumeralConverter converter = new LocationNumeralConverter();
            result = converter.ConvertToNumeral(decimalToConvert);
            Assert.IsTrue(result.Equals("ad"));
        }
        [TestMethod]
        public void TestAbbreviation()
        {
            string result;
            string stringToConvert = "abeefghhyyzz";
            LocationNumeralConverter converter = new LocationNumeralConverter();
            result = converter.AbbreviateNumeral(stringToConvert);
            Assert.IsTrue(result.Equals("abhizzz"));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestStringArgumentException()
        {
            int result;
            string numeral = "a d-";
            LocationNumeralConverter converter = new LocationNumeralConverter();
            result = converter.ConvertToDecimal(numeral);
        }
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestDecimalArgumentException()
        {
            string result;
            int numeral = -12;
            LocationNumeralConverter converter = new LocationNumeralConverter();
            result = converter.ConvertToNumeral(numeral);
        }
    }
}

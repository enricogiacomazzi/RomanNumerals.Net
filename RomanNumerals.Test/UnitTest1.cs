using System;
using System.Linq;
using Xunit;
using RomanNumerals;
using Xunit.Sdk;

namespace RomanNumerals.Test
{
    public class UnitTest1
    {
        [Fact]
        public void ToRoman()
        {
            var res = RomanNumerals.Convert(1910);

            Assert.Equal("MCMX",res);
        }

        [Fact]
        public void ToArab()
        {
            var res = RomanNumerals.Convert("MCMX");

            Assert.Equal(1910, res);
        }

        [Fact]
        public void CompleteTest()
        {
            var items = Enumerable.Range(1, 10000).ToArray();

            var romans = items.Select(RomanNumerals.Convert).ToArray();
            var arabs = romans.Select(RomanNumerals.Convert).ToArray();

            Assert.Equal(items, arabs);
        }
    }
}

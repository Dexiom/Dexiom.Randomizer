using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dexiom.Randomizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dexiom.Randomizer.Tests
{
    [TestClass()]
    public class RandomizerTests
    {
        [TestMethod()]
        public void GetRandomNumberTest()
        {
            const int min = 0;
            const int max = 100;

            for (var i = 0; i < 100; i++)
            {
                var number = Randomizer.GetRandomNumber(min, max);
                if (number < 0 && number > 100)
                {
                    Assert.Fail("Bounds were not respected");
                }
            }
        }

        [TestMethod()]
        public void GetRandomCaracterTest()
        {
            for (var i = 0; i < 100; i++)
            {
                int temp;
                var randomCaracter = Randomizer.GetRandomCaracter(CaracterType.UpperCaseLetter, CaracterType.LowerCaseLetter);
                if (int.TryParse(randomCaracter.ToString(), out temp))
                {
                    Assert.Fail("Restrictions were not respected");
                }
            }
        }
    }
}
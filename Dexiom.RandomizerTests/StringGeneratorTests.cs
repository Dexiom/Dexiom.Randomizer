using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dexiom.Randomizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dexiom.Randomizer.Tests
{
    [TestClass()]
    public class StringGeneratorTests
    {
        [TestMethod()]
        public void GetRandomStringTest()
        {
            //method 1
            Assert.IsTrue(StringGenerator.CreateRandomString(10).Length == 10);

            //method 2
            var method2 = StringGenerator.CreateRandomString("**-**");
            Assert.IsTrue(method2.Length == 5);
            Assert.IsTrue(method2.Substring(2, 1) == "-");
            
            //method 3
            int temp;
            var method3 = StringGenerator.CreateRandomString("****", CaracterType.Number);
            if (!int.TryParse(method3, out temp))
            {
                Assert.Fail("Restrictions were not respected");
            }
        }
    }
}
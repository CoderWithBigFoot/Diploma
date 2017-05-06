using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShareYourself.Business.Tests
{
    [TestClass]
    public class ServiceOperationsTests
    {
        [TestMethod]
        public void SplitTest()
        {
            char[] separators = new char[]
            {
               ',',' '
            };

            string testString = "Some_ , string _ ";

            var result = testString.Split(separators);
           
            

            Assert.AreEqual(result.Length, 6);
            CollectionAssert.Contains(result, "Some_");
            CollectionAssert.Contains(result, "string");
            CollectionAssert.Contains(result, "");
            CollectionAssert.Contains(result, "_");
        }

        private class testClass
        {

        }

        [TestMethod]
        public void TakeTest()
        {
            List<int> collection = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            var result = collection
                .OrderByDescending(x=>x)
                .Skip(7)
                .Take(1)
                .FirstOrDefault();

            Assert.AreEqual(result, 7);
        }
    }
}

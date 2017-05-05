using System;
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
    }
}

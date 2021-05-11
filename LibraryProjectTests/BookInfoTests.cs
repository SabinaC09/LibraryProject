using System;
using LibraryProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryProjectTests
{
    [TestClass]
    public class BookInfoTests
    {
        [TestMethod]
        public void CheckBookData_WrongIsbnData_ReturnFalse()
        {
            var result = BookFactory.CheckBookData("e127876546789", 100);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckBookData_WrongIsbnLength_ReturnFalse()
        {
            var result = BookFactory.CheckBookData("222127876546789", 100);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckBookData_WrongPriceRange_ReturnFalse()
        {
            var result = BookFactory.CheckBookData("3127876546789", 1000);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckBookData_CorrectData_ReturnTrue()
        {
            var result = BookFactory.CheckBookData("2547852000369", 100);
            Assert.IsTrue(result);
        }
    }
}

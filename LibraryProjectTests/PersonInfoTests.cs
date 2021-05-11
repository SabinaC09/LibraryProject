using System;
using LibraryProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryProjectTests
{
    [TestClass]
    public class PersonInfoTests
    {
        [TestMethod]
        public void CheckPersonData_WrongFirstName_ReturnFalse()
        {
            var result = PersonFactory.CheckPersonData("Alexandru33", "Popescu", "1900101411935");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckPersonData_WrongLastName_ReturnFalse()
        {
            var result = PersonFactory.CheckPersonData("Alexandru", "Popesc23u", "1900101411935");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckPersonData_WrongCnpFormat_ReturnFalse()
        {
            var result = PersonFactory.CheckPersonData("Alexandru", "Popescu", "19001014d11935");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckPersonData_WrongCnpLength_ReturnFalse()
        {
            var result = PersonFactory.CheckPersonData("Alexandru", "Popescu", "19001014311935");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckPersonData_InvalidCnp_ReturnFalse()
        {
            var result = PersonFactory.CheckPersonData("Alexandru", "Popescu", "190010143119");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckPersonData_CorrectData_ReturnFalse()
        {
            var result = PersonFactory.CheckPersonData("Alexandru", "Popescu", "1900101411935");
            Assert.IsTrue(result);
        }


    }
}

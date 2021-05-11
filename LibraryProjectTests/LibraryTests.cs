using System;
using System.Collections.Generic;
using LibraryProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryProjectTests
{
    [TestClass]
    public class LibraryTests
    {
       
        [TestMethod]
        public void AddBookToLibrary_LibraryIsEmpty()
        {
            Library library = new Library(new Dictionary<Book, int>(), new Dictionary<Person, List<Loan>>());
            library.AddBookToLibrary("Test Book 1", "2547852000369", 220);

            Book book1 = BookFactory.CreateBook("Test Book 1", "2547852000369", 220);

            Assert.AreEqual(library.LibraryList[book1], 1);

        }

        [TestMethod]
        public void AddBookToLibrary_LibraryHasBook()
        {
            Library library = new Library(new Dictionary<Book, int>(), new Dictionary<Person, List<Loan>>());
            library.AddBookToLibrary("Test Book 1", "2547852000369", 220);
            library.AddBookToLibrary("Test Book 1", "2547852000369", 220);

            Book book1 = BookFactory.CreateBook("Test Book 1", "2547852000369", 220);

            Assert.AreEqual(library.LibraryList[book1], 2);

        }

        [TestMethod]
        public void AddBookToLibrary_LibraryDoesntHaveBook()
        {
            Library library = new Library(new Dictionary<Book, int>(), new Dictionary<Person, List<Loan>>());
            library.AddBookToLibrary("Test Book 1", "2547852000370", 230);
            library.AddBookToLibrary("Test Book 2", "2547852000371", 250);
            library.AddBookToLibrary("Test Book 3", "2547852000369", 220);

            Book book3 = BookFactory.CreateBook("Test Book 3", "2547852000369", 220);

            Assert.AreEqual(library.LibraryList[book3], 1);
        }

        [TestMethod]
        public void LoanBook_NewPerson()
        {
            Library library = new Library(new Dictionary<Book, int>(), new Dictionary<Person, List<Loan>>());
            library.AddBookToLibrary("Test Book 1", "2547852000370", 230);
            library.AddBookToLibrary("Test Book 1", "2547852000370", 230);
            library.AddBookToLibrary("Test Book 1", "2547852000370", 230);
            Book book = BookFactory.CreateBook("Test Book 1", "2547852000370", 230);
            int value = library.LibraryList[book];

            Person person = PersonFactory.CreatePerson("Alexandru", "Popescu", "1900101411935");

            library.LoanBook(person, book);

            Assert.AreEqual(library.LibraryList[book], value-1);
        }

        [TestMethod]
        public void CheckIfNotAlreadyLoaned_Loaned_ReturnFalse()
        {
            Library library = new Library(new Dictionary<Book, int>(), new Dictionary<Person, List<Loan>>());
            library.AddBookToLibrary("Test Book 1", "2547852000370", 230);
            library.AddBookToLibrary("Test Book 1", "2547852000370", 230);
            library.AddBookToLibrary("Test Book 1", "2547852000370", 230);
            Book book = BookFactory.CreateBook("Test Book 1", "2547852000370", 230);
            

            Person person = PersonFactory.CreatePerson("Alexandru", "Popescu", "1900101411935");

            library.LoanBook(person, book);

            var result = library.CheckIfNotAlreadyLoaned(person, book);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckIfNotAlreadyLoaned_NotLoaned_ReturnTrue()
        {
            Library library = new Library(new Dictionary<Book, int>(), new Dictionary<Person, List<Loan>>());
            library.AddBookToLibrary("Test Book 1", "2547852000370", 230);
            library.AddBookToLibrary("Test Book 1", "2547852000370", 230);
            library.AddBookToLibrary("Test Book 1", "2547852000370", 230);
            Book book = BookFactory.CreateBook("Test Book 1", "2547852000370", 230);
            Book book2 = BookFactory.CreateBook("Test Book 2", "2547852000371", 240);

            Person person = PersonFactory.CreatePerson("Alexandru", "Popescu", "1900101411935");
            library.LoanBook(person, book);

            var result = library.CheckIfNotAlreadyLoaned(person, book2);
            Assert.IsTrue(result);
        }




    }
}

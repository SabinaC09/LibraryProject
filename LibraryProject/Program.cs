using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //create person 
            Person person1 = PersonFactory.CreatePerson("Alexandru", "Popescu", "1236541256325");

            //add book to library 
            Library library = new Library(new Dictionary<Book, int>(), new Dictionary<Person, List<Loan>>());
            library.AddBookToLibrary("abc", "2547852000369", 120);
            library.AddBookToLibrary("abc", "2547852000369", 120);
            library.AddBookToLibrary("dddc", "aaaa", 120);

            Console.WriteLine(person1.Firstname+" " +person1.Cnp);

            //view books in the library
            library.ViewAllBooks();
            

            //view available copies
            library.ViewCopies("2547852000369");
            Book book1 = BookFactory.CreateBook("abc", "2547852000369", 120);
            library.ViewCopies(book1);

            //loan from library 
            library.LoanBook(person1, book1);
            library.LoanBook(person1, "2547852000369");
            //return to library
            //unit tests

        }

        
    }
}

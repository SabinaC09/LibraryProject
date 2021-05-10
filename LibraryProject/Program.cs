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
            Person person1 = PersonFactory.CreatePerson("Alexandru", "Popescu", "1920828410021");
            if (person1 != null)
                Console.WriteLine("Person 1 cnp is valid");
            else
                Console.WriteLine("Person 1 cnp is invalid");

            //add book to library 
            Library library = new Library(new Dictionary<Book, int>(), new Dictionary<Person, List<Loan>>());
            library.AddBookToLibrary("abc", "2547852000369", 120);
            library.AddBookToLibrary("abc", "2547852000369", 120);
            library.AddBookToLibrary("dddc", "aaaa", 120);

            Console.WriteLine(person1.Firstname+" " +person1.Cnp);

            //view books in the library
            library.ViewAllBooks();

            Console.WriteLine();
            //view available copies
            library.ViewCopies("2547852000369");
            Book book1 = BookFactory.CreateBook("abc", "2547852000369", 120);
            library.ViewCopies(book1);
            Console.WriteLine();

            //loan from library 
            library.LoanBook(person1, book1);
            library.LoanBook(person1, "2547852000369");
            Console.WriteLine();

            //return to library
            library.ReturnBook(person1, book1);
            Console.WriteLine();

            library.LoanBook(person1, book1, new DateTime(2021, 4, 10));
            library.ReturnBook(person1, book1);
            Console.WriteLine();

            //No penalty to be paid. x2

            //unit tests
        }


    }
}

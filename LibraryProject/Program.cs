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
            Person person1 = new Person("Alexandru", "Popescu", "1563254785214");

            //add book to library 
            Library library = new Library(new Dictionary<Book, int>(), new List<Loan>());
            library.AddBookToLibrary("abc", "2547852000369", 120);
            library.AddBookToLibrary("abc", "2547852000369", 120);
            library.AddBookToLibrary("dddc", "aaaa", 120);

            foreach(Book book in library.LibraryList.Keys)
            {
                Console.WriteLine(book.Name + " "+ library.LibraryList[book]);
                
            }

            

            //loan from library 
            //return to library
            //unit tests

        }

        
    }
}

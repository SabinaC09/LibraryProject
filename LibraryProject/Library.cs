using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Library
    {
        private Dictionary<Book, int> library;
        private List<Loan> loans;
        

        internal Dictionary<Book, int> LibraryList { get => library; set => library = value; }
        internal List<Loan> LoansList { get => loans; set => loans = value; }

        public Library(Dictionary<Book, int> library, List<Loan> loans)
        {
            this.library = library;
            this.loans = loans;
        }

        public void AddBookToLibrary(string name, string isbn, double price)
        {
            Book book = BookFactory.CreateBook(name, isbn, price);
            if (book != null)
            {
                if (LibraryList.Count == 0)
                {
                    LibraryList.Add(book, 1);
                }
                else
                {
                    if (LibraryList.ContainsKey(book))
                        LibraryList[book] += 1;
                    else
                        LibraryList.Add(book, 1);
                }
            }
        }

        public void ViewAllBooks()
        {
            foreach (KeyValuePair<Book, int> book in LibraryList)
            {
                Console.WriteLine(book.Key.ToString() + " Copies:" + book.Value);
            }
        }

        public void ViewCopies(Book book)
        {
            if (LibraryList.ContainsKey(book))
                Console.WriteLine("Copies available: " + LibraryList[book]);
            else
                Console.WriteLine("This book is not in the library");
        }

        public void ViewCopies(string isbn)
        {
            foreach (KeyValuePair<Book, int> book in LibraryList)
            {
                if (book.Key.Isbn.Equals(isbn))
                    Console.WriteLine("Copies available: " + book.Value);
                else
                    Console.WriteLine("This book is not in the library");
            }
        }

        public void LoanBook(Person person, Book book)
        {
            if (LibraryList.ContainsKey(book) && LibraryList[book] > 0)
            {
                LoansList.Add(new Loan(person, book, DateTime.Today));
                LibraryList[book] -= 1;
                Console.WriteLine("Book loan successful!");
            }
            else
                Console.WriteLine("There are no available copies for this book");
        }
        public void LoanBook(Person person, string isbn)
        {
            foreach (KeyValuePair<Book, int> book in LibraryList)
            {
                if (book.Key.Isbn.Equals(isbn) && book.Value > 0)
                {
                    LoansList.Add(new Loan(person, book.Key, DateTime.Today));
                    LibraryList[book.Key] -= 1;
                    Console.WriteLine("Book loan successful!");
                    break;
                }
            }
            //Console.WriteLine("There are no available copies for this book");
        }

        public void ReturnBook(Person person, Book book)
        {
            foreach(Loan loan in loans)
            {
                if(loan.Book.Name.Equals(book.Name) && loan.Person.Firstname.Equals(person.Firstname) && loan.Person.Lastname.Equals(person.Lastname))
                {
                   if(CheckForPenalty(loan))
                    {
                        AddPenalty(loan);
                    }
                }
            }
        }

        bool CheckForPenalty(Loan loan)
        {
            //validare data
            return true;
        }

        

        void AddPenalty(Loan loan)
        {

        }
    }
}

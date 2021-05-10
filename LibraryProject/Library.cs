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
        private Dictionary<Person, List<Loan>> loans;
        

        internal Dictionary<Book, int> LibraryList { get => library; set => library = value; }
        internal Dictionary<Person, List<Loan>> LoansList { get => loans; set => loans = value; }

        public Library(Dictionary<Book, int> library, Dictionary<Person, List<Loan>> loans)
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
                if (LoansList.ContainsKey(person))
                {

                    LoansList[person].Add(new Loan(book, DateTime.Today));
                    Console.WriteLine("Book loan successful!");
                } else
                {
                    List<Loan> loans = new List<Loan>();
                    loans.Add(new Loan(book, DateTime.Today));
                    LoansList.Add(person, loans);
                    LibraryList[book] -= 1;
                    Console.WriteLine("Book loan successful!");
                }             
                
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
                    if (LoansList.ContainsKey(person))
                    {
                        LoansList[person].Add(new Loan(book.Key, DateTime.Today));
                        Console.WriteLine("Book loan successful!");
                        break;
                    }
                    else
                    {
                        List<Loan> loans = new List<Loan>();
                        loans.Add(new Loan(book.Key, DateTime.Today));
                        LoansList.Add(person, loans);
                        LibraryList[book.Key] -= 1;
                        Console.WriteLine("Book loan successful!");
                        break;
                    }
                }
            }
            //Console.WriteLine("There are no available copies for this book");
        }

        public void ReturnBook(Person person, Book book)
        {
            
            
        }

        bool CheckForPenalty(Loan loan)
        {
            //validare data
            return true;
        }

        

        void AddPenalty(int days, Book book)
        {
            double penalty = 0.01 * book.Price / days;
        }
    }
}

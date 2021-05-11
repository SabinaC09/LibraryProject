using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    public class Library
    {
        private Dictionary<Book, int> library;
        private Dictionary<Person, List<Loan>> loans;


        public Dictionary<Book, int> LibraryList { get => library; set => library = value; }
        public Dictionary<Person, List<Loan>> LoansList { get => loans; set => loans = value; }

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
                if (LibraryList.ContainsKey(book))
                    LibraryList[book] += 1;
                else
                    LibraryList.Add(book, 1);
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
            Book book = LibraryList.Keys.Where(b => b.Isbn == isbn).FirstOrDefault();

            if (book != null)
                Console.WriteLine("Copies available: " + LibraryList[book]);
            else
                Console.WriteLine("This book is not in the library");

        }

        public void LoanBook(Person person, Book book)
        {
            if (LibraryList.ContainsKey(book) && LibraryList[book] > 0)
            {
                if (LoansList.ContainsKey(person))
                {
                    if (CheckIfNotAlreadyLoaned(person, book))
                    {
                        LoansList[person].Add(new Loan(book, DateTime.Today));
                        Console.WriteLine("Book loan successful!");
                    }

                }
                else
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

        public void LoanBook(Person person, Book book, DateTime date)
        {
            if (LibraryList.ContainsKey(book) && LibraryList[book] > 0)
            {
                if (LoansList.ContainsKey(person))
                {
                    if (CheckIfNotAlreadyLoaned(person, book))
                    {
                        LoansList[person].Add(new Loan(book, date));
                        Console.WriteLine("Book loan successful!");
                    }

                }
                else
                {
                    List<Loan> loans = new List<Loan>();
                    loans.Add(new Loan(book, date));
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
            Book book = LibraryList.Keys.Where(b => b.Isbn == isbn).FirstOrDefault();
            if (book != null)
            {
                LoanBook(person, book);
            }
        }


        public double ReturnBook(Person person, Book book)
        {
            if (LoansList.ContainsKey(person))
            {
                foreach (Loan loan in LoansList[person].ToList())
                {
                    if (loan.Book.Equals(book))
                    {
                        double penalty = GetPenalty(loan);
                        AddBookToLibrary(loan.Book.Name, loan.Book.Isbn, loan.Book.Price);
                        LoansList[person].Remove(loan);
                        Console.WriteLine("Book has been returned. Penalty: {0}", penalty);
                        return penalty;
                    }
                }
                return 0;
            }
            else
            {
                Console.WriteLine("Wrong personal data!");
                return 0;
            }
        }

        double GetPenalty(Loan loan)
        {
            int daysPassed = (DateTime.Now - loan.LoanDate).Days;
            if (daysPassed > 14)
            {
                double penalty = 0.01 * loan.Book.Price * (daysPassed - 14);
                return penalty;
            }
            else
                return 0;
        }

        public bool CheckIfNotAlreadyLoaned(Person person, Book book)
        {
            Loan loan = LoansList[person].Where(l => l.Book == book).FirstOrDefault();
            if (loan != null)
            {
                Console.WriteLine("Book has been already loaned.");
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}

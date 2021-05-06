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

        

        public void LoanBook(Person person, Book book)
        {
            if(CheckIfBookAvailable(book))
            {
                Loan loan = new Loan(person, book, DateTime.Now);
            }
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

        bool CheckIfBookAvailable(Book book)
        {
            //int available = book.Number;
            //foreach(Loan loan in loans)
            //{
            //    if(loan.Book.Name.Equals(book.Name))
            //    {
            //        available--;
            //    }
            //}
            //if (available > 0)
            //    return true;
            //else 
               return false;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Loan
    {
        private Person person;
        private Book book;
        private DateTime loadDate;

        public Loan(Person person, Book book, DateTime lendDate)
        {
            this.Person = person;
            this.Book = book;
            this.LoanDate = lendDate;
        }

        public DateTime LoanDate { get => loadDate; set => loadDate = value; }
        internal Person Person { get => person; set => person = value; }
        internal Book Book { get => book; set => book = value; }
    }
}

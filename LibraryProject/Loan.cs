using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Loan
    {
        private Book book;
        private DateTime loadDate;

        public Loan(Book book, DateTime lendDate)
        {
            this.Book = book;
            this.LoanDate = lendDate;
        }

        public DateTime LoanDate { get => loadDate; set => loadDate = value; }
        internal Book Book { get => book; set => book = value; }
    }
}

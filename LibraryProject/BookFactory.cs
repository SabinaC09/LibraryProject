using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class BookFactory
    {
        public static Book CreateBook(string name, string isbn, double price)
        {
            return CheckBookData(isbn, price) ? new Book(name, isbn, price) : null;
        }

        static bool CheckBookData(string isbn, double price)
        {
            //validare date carte
            if (int.TryParse(isbn, out _) || isbn.Length != 13)
                return false;
            else if (price <= 0 || price > 500)
                return false;
            else 
                return true;
        }
    }
}

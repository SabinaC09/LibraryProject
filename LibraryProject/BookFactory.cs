using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    public class BookFactory
    {
        public static Book CreateBook(string name, string isbn, double price)
        {
            return CheckBookData(isbn, price) ? new Book(name, isbn, price) : null;
        }

        public static bool CheckBookData(string isbn, double price)
        {
            bool hasOnlyNumbers = long.TryParse(isbn, out _);
            bool hasOkLength = isbn.Length == 13;

            if (!hasOnlyNumbers || !hasOkLength)
                return false;
            else if (price <= 0 || price > 500)
                return false;
            else 
                return true;
        }
    }
}

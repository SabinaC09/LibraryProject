using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class BookFactory
    {
        public static Book CreateBook(string name, string isbn, double price, int number)
        {
            return CheckBookData(isbn, price, number) ? new Book(name, isbn, price, number) : null;
        }

        static bool CheckBookData(string isbn, double price, int number)
        {
            //validare date carte
            if (int.TryParse(isbn, out _) || isbn.Length != 13)
                return false;
            else if (price <= 0 || price > 500)
                return false;
            else if (number <= 0 || number > 1000)
                return false;
            else
                return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Book
    {
        private String name;
        private String isbn;
        private Double price;

        public Book(string name, string isbn, double price)
        {
            this.Name = name;
            this.Isbn = isbn;
            this.Price = price;
        }

        public string Name { get => name; set => name = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public double Price { get => price; set => price = value; }

        public override bool Equals(object obj)
        {
            var otherBook = obj as Book;

            if (otherBook == null)
            {
                return false;
            }

            return this.Isbn.Equals(otherBook.Isbn);
        }

        public override int GetHashCode()
        {
            return this.Isbn.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Name: {0} ISBN: {1} Price: {2}", name, isbn, price);
        }

    }
}

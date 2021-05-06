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
        private int number;

        public Book(string name, string isbn, double price, int number)
        {
            this.Name = name;
            this.Isbn = isbn;
            this.Price = price;
            this.Number = number;
        }

        public string Name { get => name; set => name = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public double Price { get => price; set => price = value; }
        public int Number { get => number; set => number = value; }
    }
}

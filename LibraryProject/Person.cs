using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Person
    {
        private String firstname;
        private String lastname;
        private String cnp;

        public Person(string firstname, string lastname, string cnp)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Cnp = cnp;
        }

        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Cnp { get => cnp; set => cnp = value; }
    }
}

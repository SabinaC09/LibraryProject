using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryProject
{
    class PersonFactory
    {
        public static Person CreatePerson(string firstname, string lastname, string cnp)
        {
            return CheckPersonData(firstname, lastname, cnp) ? new Person(firstname, lastname, cnp) : null; 
        }

        static bool CheckPersonData(string firstname, string lastname, string cnp)
        {
            if (!Regex.IsMatch(firstname, @"^[a-zA-Z]+$"))
                return false;
            else if (!Regex.IsMatch(lastname, @"^[a-zA-Z]+$"))
                return false;
            else if (int.TryParse(cnp, out _) || cnp.Length != 13)
                return false;
            else if (!CheckCnpData(cnp))
                return false;
            else 
                return true;
        }

        static bool CheckCnpData(string cnp)
        {
            //int s = Int32.Parse(cnp.Substring(0, 1));
            //int aa = Int32.Parse(cnp.Substring(1, 2));
            //int ll = Int32.Parse(cnp.Substring(3, 2));
            //int zz = Int32.Parse(cnp.Substring(5, 2));
            //int jj = Int32.Parse(cnp.Substring(7, 2));
            //int nnn = Int32.Parse(cnp.Substring(9, 3));

            //if (Enumerable.Range(1, 8).Contains(s) && Enumerable.Range(0, 99).Contains(aa) && Enumerable.Range(1, 12).Contains(ll)
            //    && Enumerable.Range(1, 31).Contains(zz) && Enumerable.Range(1, 48).Contains(jj) && Enumerable.Range(1, 999).Contains(nnn))
            //{
            if(cnp.Length==13)
                //if (ValidateControlComponent(cnp))
                    return true;
            //}
            
            return false;
        }

        private static bool ValidateControlComponent(string cnp)
        {
            //Calcularea componentei de control se face folosind constanta 279146358279
            //Fiecare cifra din primele 12 cifre este inmultita cu corespondentul din constanta
            //Rezultatele sunt insumate si totalul se imparte la 11
            //Daca restul impartirii este < 10, acela reprezinta valoarea componentei c
            //Daca restul impartirii este 10, valoarea componentei este 1
            
            int sum = cnp[0] * 2 + cnp[1] * 7 + cnp[2] * 9 + cnp[3] * 1 + cnp[4] * 4 + cnp[5] * 6 + 
                cnp[6] * 3 + cnp[7] * 5 + cnp[8] * 8 + cnp[9] * 2 + cnp[10] * 7 + cnp[11] * 9;
            if (sum % 11 < 10 && sum % 11 == cnp[12])
                return true;
            else if (sum % 11 == 10 && cnp[12] == 1)
                return true;
            else
                return false;
        }
    }
}

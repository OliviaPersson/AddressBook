using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Program
    {
        class Person
        {
            public string firstName, lastName, number, email;
            public Person (string fName, string lName, string num, string em)
            {
                firstName = fName;
                lastName = lName;
                number = num;
                email = em;
            }
        }
        static void Main(string[] args)
        {
            List<Person> addressBook = new List<Person>();
            string fileName = @"C: \Users\Olivi\adressbok.txt";
        }
    }
}

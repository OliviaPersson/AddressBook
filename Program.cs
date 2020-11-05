using System;
using System.Collections.Generic;
using System.IO;
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
            string fileName = @"C:\Users\Olivi\adressbok.txt";

            //Källa: https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-read-a-text-file-in-C-Sharp/
            using (StreamReader file = new StreamReader(fileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split('#');
                    Console.WriteLine("{0} {1}  {2}  {3}", words[0], words[1], words[2], words[3]); //Testutskrift
                    addressBook.Add(new Person(words[0], words[1], words[2], words[3]));
                  
                }
                file.Close();
                for (int i = 0; i < addressBook.Count(); i++)
                {
                    //Testutskrift
                    Console.WriteLine($"{addressBook[i].firstName} {addressBook[i].lastName}  {addressBook[i].number}  {addressBook[i].email}");
                }
            }
            Console.WriteLine("Hej och välkommen till adressboken!");
            Console.WriteLine("Skriv 'sluta' om du vill avsluta programmet!");
            Console.Write("> ");
            string command = Console.ReadLine();

            if (command == "sluta")
            {
                Console.WriteLine("Hej då!");
            }
        }
    }
}

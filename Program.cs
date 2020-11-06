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
            public Person(string fName, string lName, string num, string em)
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

            //Source: https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-read-a-text-file-in-C-Sharp/
            using (StreamReader file = new StreamReader(fileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split('#');
                    //Console.WriteLine("{0} {1}  {2}  {3}", words[0], words[1], words[2], words[3]); //TestPrint
                    addressBook.Add(new Person(words[0], words[1], words[2], words[3]));

                }
                file.Close();
            }
            Console.WriteLine("Hej och välkommen till adressboken!");
            Console.WriteLine("Skriv 'sluta' om du vill avsluta programmet!");
            string command;

            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                if (command == "sluta")
                {
                    Console.WriteLine("Hej då!");
                }
                else if (command == "visa")
                {
                    Console.WriteLine("     Namn          Tel              email");
                    for (int i = 0; i < addressBook.Count(); i++)
                    {
                        Console.WriteLine($"{addressBook[i].firstName} {addressBook[i].lastName}  {addressBook[i].number}  {addressBook[i].email}");
                    }
                }
                else if (command == "lägg till person")
                {
                    Console.Write("Skriv in förnamn: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Skriv in efternamn: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Skriv in tel nummer: ");
                    string number = Console.ReadLine();
                    Console.Write("Skriv in email: ");
                    string email = Console.ReadLine();
                    Console.WriteLine($"namn: {firstName} {lastName} num: {number} email: {email}"); //TestPrint
                    addressBook.Add(new Person(firstName, lastName, number, email));
                }
                else if (command == "spara")
                {
                    using (StreamWriter writer = new StreamWriter(fileName))
                        for(int i = 0; i < addressBook.Count(); i++)
                        {
                            writer.WriteLine($"{addressBook[i].firstName}#{addressBook[i].lastName}#{addressBook[i].number}#{addressBook[i].email}");
                        }
                }
            } while (command != "sluta");
        }
    }
}

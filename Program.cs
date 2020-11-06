using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddressBook
{
    class Program
    {
        class Person
        {
            public string name, address, number, email;
            public Person(string name = "", string address = "", string number = "", string email = "")
            {
                this.name = name;
                this.address = address;
                this.number = number;
                this.email = email;
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
                    addressBook.Add(new Person(name: words[0], address: words[1], number: words[2], email: words[3]));

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
                    Console.WriteLine("*************************************************************************************************");
                    Console.WriteLine("  {0,-20}   {1,-20}   {2,-20}   {3,-20}", "Namn", "Adress", "Tel", "E-post");
                    Console.WriteLine("*************************************************************************************************");
                    for (int i = 0; i < addressBook.Count(); i++)
                    {
                        //Console.WriteLine($"{addressBook[i].name} {addressBook[i].address}  {addressBook[i].number}  {addressBook[i].email}");
                        Console.WriteLine("| {0,-20} | {1,-20} | {2,-20} | {3,-20}", addressBook[i].name, addressBook[i].address, addressBook[i].number, addressBook[i].email);
                    }
                }
                else if (command == "lägg till")
                {
                    Console.Write("Skriv in namn: ");
                    string name = Console.ReadLine();
                    Console.Write("Skriv in adress: ");
                    string address = Console.ReadLine();
                    Console.Write("Skriv in tel nummer: ");
                    string number = Console.ReadLine();
                    Console.Write("Skriv in email: ");
                    string email = Console.ReadLine();
                    //Console.WriteLine($"namn: {firstName} {lastName} num: {number} email: {email}"); //TestPrint
                    addressBook.Add(new Person(name, address, number, email));

                    //Source: https://www.c-sharpcorner.com/article/csharp-streamwriter-example/
                    using (StreamWriter writer = new StreamWriter(fileName))
                        for (int i = 0; i < addressBook.Count(); i++)
                        {
                            writer.WriteLine($"{addressBook[i].name}#{addressBook[i].address}#{addressBook[i].number}#{addressBook[i].email}");
                        }
                }
                else if (command == "ta bort")
                {
                    Console.Write("Skriv in email för den person du vill ta bort från listan: ");
                    string remove = Console.ReadLine();

                    for (int i = 0; i < addressBook.Count(); i++)
                    {
                        if (remove == addressBook[i].email)
                        {
                            //Source https://stackoverflow.com/questions/10018957/how-to-remove-item-from-list-in-c
                            addressBook.Remove(addressBook[i]);
                            Console.WriteLine($"{remove} har tagits bort från listan!");
                        }
                    }
                    //Source: https://www.c-sharpcorner.com/article/csharp-streamwriter-example/
                    using (StreamWriter writer = new StreamWriter(fileName))
                        for (int i = 0; i < addressBook.Count(); i++)
                        {
                            writer.WriteLine($"{addressBook[i].name}#{addressBook[i].address}#{addressBook[i].number}#{addressBook[i].email}");
                        }
                }
            } while (command != "sluta");
        }
    }
}

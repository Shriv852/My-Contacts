using System;
using System.Collections.Generic;
using System.Linq;

namespace My_Contacts
{
    class Program
    {
        public class Person {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
        }
        public static List<Person> People = new List<Person>();
        static void Main(string[] args)
        {
            bool loop = true;
            while (loop == true)
            {
                int inputNum = Run();

                if (inputNum == 1) //List All Contacts
                {
                    ListPeople();
                }
                if (inputNum == 2) //Search Contact
                {
                    Console.WriteLine("Enter a first name you would like to search!");
                    string searchName = Console.ReadLine();
                    int index = find(People, searchName);
                    if (index == -1)
                    {
                        Console.WriteLine("Contact was not found");
                    } else
                    {
                        Console.WriteLine("Contact was found!");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("First Name: " + People[index].FirstName);
                        Console.WriteLine("Last Name: " + People[index].LastName);
                        Console.WriteLine("Phone Number: " + People[index].PhoneNumber);
                        Console.WriteLine("Email Address: " + People[index].Address);
                        Console.WriteLine("-------------------------------------------");
                    }
                }
                if (inputNum == 3) //Edit Contact
                {
                    Console.WriteLine("Enter a contact first name you would like to edit!");
                    string searchName = Console.ReadLine();
                    int index = find(People, searchName);

                    if (index != -1)
                    {
                        Console.WriteLine("Enter a Key to Edit:\n First Name - 1 \n Last Name - 2 \n Phone Number - 3 \n Email Address - 4 ");
                        int edit = Convert.ToInt32(Console.ReadLine());

                        if (edit == 1)
                        {
                            Console.WriteLine("Edit First Name");
                            string editFirstName = Console.ReadLine();
                            People[index].FirstName = editFirstName;
                        } else if (edit == 2)
                        {
                            Console.WriteLine("Edit Last Name");
                            string editLastName = Console.ReadLine();
                            People[index].LastName = editLastName;
                        } else if (edit == 3) 
                        {
                            Console.WriteLine("Edit Phone Number");
                            string editPhoneNumber = Console.ReadLine();
                            People[index].PhoneNumber = editPhoneNumber;
                        } else if (edit == 4)
                        {
                            Console.WriteLine("Edit Email Address");
                            string editEmailAddress = Console.ReadLine();
                            People[index].Address = editEmailAddress;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Entry");
                        }

                    }
                    Console.WriteLine("Contact Updated!");
                }
                if (inputNum == 4) //Adding a New Contact
                {
                    AddPerson();
                    
                }
                if (inputNum == 5) //Removing Contact
                {
                    RemovePerson();
                }
                if (inputNum == 6) //Exit
                {
                    Console.WriteLine("Goodbye");
                    loop = false;
                }

            }//End oF loop

        } //End of main Function

        public static int Run()
        {
            Console.WriteLine("-------Main Menu---------");
            Console.WriteLine("Press 1 to Display All Contacts");
            Console.WriteLine("Press 2 to Search for Contact");
            Console.WriteLine("Press 3 to Edit Contact");
            Console.WriteLine("Press 4 to Add a Contact");
            Console.WriteLine("Press 5 to Remove a Contact");
            Console.WriteLine("Press 6 to Exit");
            Console.WriteLine("--------------------------");

            return Convert.ToInt32(Console.ReadLine());
        }
        private static void AddPerson()
        {
            Person person = new Person();

            Console.Write("Enter First Name: ");
            person.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            person.LastName = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            person.PhoneNumber = Console.ReadLine();

            Console.Write("Enter Email Address: ");
            person.Address = Console.ReadLine();

            People.Add(person);
        }
        private static void PrintPerson(Person person)
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("First Name: " + person.FirstName);
            Console.WriteLine("Last Name: " + person.LastName);
            Console.WriteLine("Phone Number: " + person.PhoneNumber);
            Console.WriteLine("Email Address: " + person.Address);
            Console.WriteLine("-------------------------------------------");
        }
        private static void ListPeople()
        {
            if (People.Count == 0)
            {
                Console.WriteLine("Your address book is currently empty.");
            }
            ;
            foreach (var person in People) //Write All The contacts in the person list
            {
                PrintPerson(person);
            }
        }
        private static void RemovePerson()
        {
            Console.WriteLine("Enter the first name of the person you would like to remove.");
            string removeContact = Console.ReadLine(); //Stroing the name to delete
            int index = find(People, removeContact);
            if (index == -1)
            {
                Console.WriteLine("Name Not Found In Contacts");
            } else
            {
                People.Remove(person); //Contact Deleted
            }
           
            Console.WriteLine("Contact Has Been Updated");
        }
        public static int find(List<Person> People, string firstName)
        {
            for (int i = 0; i < People.Count; i++)
            {
                if (People[i].FirstName == firstName)
                {
                    return i;
                } 
            }
            return -1;
        }
    }
}

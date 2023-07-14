using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Phone
{
    internal class PhoneBook
    {

        private List<Contact> Contacts { get; set; }

        //Constructor to initiate a list of contacts
        public PhoneBook()
        {
            Contacts = new List<Contact>();
        }

        public void PhoneBookFunctionality()
        {
            bool isRun = true;
            while (isRun)
            {
                Console.Clear();
                Console.WriteLine("Please choose an option\n" +
                                  "1.Add contact\n" +
                                  "2.Remove contact\n" +
                                  "3.Edit contact\n" +
                                  "4.Show all contacts\n" +
                                  "5.Search contact by name or phone\n" +
                                  "6.Search contact by mobile\n" +
                                  "7.Exit");

                switch (Console.ReadLine() ?? string.Empty)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        RemoveContact();
                        break;
                    case "3":
                        EditContact();
                        break;
                    case "4":
                        ShowContact();
                        Console.WriteLine("Press any key ...");
                        Console.ReadLine();
                        break;
                    case "5":
                        SearchByName();
                        Console.ReadLine();
                        break;
                    case "6":
                        SearchByPhoneNumber();
                        Console.ReadLine();
                        break;
                    case "7":
                        isRun = false;
                        Console.WriteLine("GoodBye!");
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        Console.WriteLine("Press any key ...");
                        Console.ReadLine();
                        break;
                }

            }
        }

        public void AddContact()
        {

           
            Console.Write("Please write full name of contact: ");
            string? name = Console.ReadLine() ?? string.Empty;

            
            if (name == "" || name == null) name = "Contact name was not assign";

            Console.Write("Please write the phone number of the contact: ");

         
            string? phoneNumber = Console.ReadLine() ?? string.Empty;

   
            Contacts.Add(new Contact(name, phoneNumber));

            
            if (phoneNumber == "")
            {

                Console.Write("\nAs a phone number was not inputted a 0 was assign\n");
            }

            Console.WriteLine("\nContact was added!\n");
        }
        public void RemoveContact()
        {
            Console.WriteLine("What contact should we removed: ");
            bool isValidID = int.TryParse(Console.ReadLine(), out int id);
            if (isValidID == false) Console.WriteLine("No contact with that ID was found");
            Contacts.RemoveAt(id - 1);
        }
        private void EditContact()
        {
            Console.Write("Which contact would like to edit: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int id);

            if (isValid && id <= Contacts.Count)
            {
                Console.WriteLine($"{Contacts[id - 1].FullName} Edit it to what? ");
                Contacts[id - 1].FullName = Console.ReadLine() ?? string.Empty;
                Console.WriteLine($"{Contacts[id - 1].PhoneNumber} Edit it to what? ");
                string updatedNumber = Console.ReadLine() ?? string.Empty;
                Contacts[id - 1].PhoneNumber = updatedNumber;
            }
            else
            {
                Console.WriteLine("Contact is out of range, please try again.");
            }



        }
        public void SearchForContact()
        {

            Console.WriteLine("\nDo you want to search by name or by phone number:\n1.Name \n2.Phone Number\n");
            bool choice = int.TryParse(Console.ReadLine(), out int id);

            if (choice && id == 1)
            {
                SearchByName();
            }

            if (choice && id == 2)
            {
                SearchByPhoneNumber();
            }



        }
        private void SearchByName()
        {



            Console.WriteLine("Please type the name of the contact or a part of the name");
            string? contactName = Console.ReadLine() ?? string.Empty;

            foreach (Contact? contact in Contacts)
            {
                if (contact.FullName.Contains(contactName))
                {
                    Console.WriteLine(contact);
                }
            }
        }
        private void SearchByPhoneNumber()
        {


            Console.WriteLine("Please type the phone number or a part of it");
            string? phoneNumber = Console.ReadLine() ?? string.Empty;

            foreach (var contact in Contacts)
            {
                if (contact.PhoneNumber.Contains(phoneNumber))
                {
                    Console.WriteLine(contact);
                }
            }


        }
        public void ShowContact()
        {

            foreach (var contact in Contacts)
            {
                Console.WriteLine(contact);
            }


        }

        

        

       
    }
}

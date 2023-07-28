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
                                  "5.Search contact by name\n" +
                                  "6.Search contact by mobile phone\n" +
                                  "7.Exit\n");

                switch (Console.ReadLine() ?? string.Empty)
                {
                    case "1":
                        AddContact();
                        Console.WriteLine("Press any key to return to the menu");
                        Console.ReadLine();
                        break;
                    case "2":
                        RemoveContact();
                        Console.ReadLine();
                        break;
                    case "3":
                        EditContact();
                        Console.ReadLine();
                        break;
                    case "4":
                        ShowContact();
                        Console.WriteLine("Press any key to return to the menu");
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
                        Console.WriteLine("Press any key to return to the menu");
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

            if (CheckPhoneNumberPattern(phoneNumber))
            {
                Contacts.Add(new Contact(name, phoneNumber));
                Console.WriteLine("\nContact was added!\n");
            }
            else
            {
                Console.WriteLine("Phone number was at an incorrect format, please use the one of the following patterns:\n" +
                                  "+97205xxxxxxxx\n" +
                                  "05xxxxxxxx\n" +
                                  "05x-xxx-xxxx");
            }



        }
        private void RemoveContact()
        {
            if (Contacts.Count < 1)
            {
                Console.WriteLine("No contacts yet, please add a contact using the Add Contact option\n");
            }

            else
            {
                ShowContact();
                Console.WriteLine("Which contact would you like to remove?: ");

                string contactName = Console.ReadLine() ?? string.Empty;


                for (int i = 0; i < Contacts.Count; i++)
                {
                    if (Contacts[i].FullName == contactName)
                    {
                        Contacts.Remove(Contacts[i]);
                        Console.WriteLine("Contact was removed");
                    }

                }
            }






        }
        private void EditContact()
        {
            if (Contacts.Count < 1)
            {
                Console.WriteLine("No contacts yet, please add a contact using the Add Contact option\n");
            }

            else
            {
                ShowContact();
                Console.Write("\nWhich contact would like to edit: ");
                string contactName = Console.ReadLine() ?? string.Empty;

                foreach (var contact in Contacts)
                {

                    if (Contacts.All(x => x.FullName != contactName))
                    {

                        Console.WriteLine("Contact was not found");

                    }
                    else
                    {
                        Console.WriteLine($"{contact.FullName} to what name change it? ");
                        contact.FullName = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine($"{contact.PhoneNumber} to what phone number change it? ");
                        string phoneNumber = Console.ReadLine() ?? string.Empty;
                        if (phoneNumber != "" && CheckPhoneNumberPattern(phoneNumber))
                        {
                            contact.PhoneNumber = phoneNumber;

                        }
                        Console.WriteLine("Contact was edited");
                    }

                }

            }






        }
        private void SearchByName()
        {
            if (Contacts.Count < 1)
            {
                Console.WriteLine("No contacts yet, please add a contact using the Add Contact option\n");
            }
            else
            {
                Console.WriteLine("Please type the name of the contact");
                string? contactName = Console.ReadLine() ?? string.Empty;

                foreach (var contact in Contacts)
                {



                    if (Contacts.All(x => x.FullName != contactName))
                    {

                        Console.WriteLine("Contact was not found");
                    }
                    else
                    {
                        if (contact.FullName == contactName)
                        {
                            Console.WriteLine(contact);
                        }
                    }

                }
            }


        }
        private void SearchByPhoneNumber()
        {
            if (Contacts.Count < 1)
            {
                Console.WriteLine("No contacts yet, please add a contact using the Add Contact option\n");
            }
            else
            {
                Console.WriteLine("Please type the phone number");
                string? phoneNumber = Console.ReadLine() ?? string.Empty;
                foreach (Contact contact in Contacts)
                {
 

                    if (Contacts.All(x => x.PhoneNumber != phoneNumber))
                    {

                        Console.WriteLine("Contact was not found");
                    }
                    else
                    {
                        if(contact.PhoneNumber == phoneNumber)
                        {
                            Console.WriteLine(contact);
                        }

                    }

                }


            }




        }
        private void ShowContact()
        {
            if (Contacts.Count < 1)
            {
                Console.WriteLine("No contacts yet, please add a contact using the Add Contact option\n");
            }
            foreach (var contact in Contacts)
            {
                Console.WriteLine(contact);
            }


        }
        private static bool CheckPhoneNumberPattern(string number)
        {
            string mobilePattern = @"^(00972|0|\+972)[5][0-9]{8}$";


            if (Regex.Match(number, mobilePattern).Success)
            {
                return true;
            }
            return false;
        }








    }
}

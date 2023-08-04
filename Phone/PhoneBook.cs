using System;
using System.Collections;
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
                Console.WriteLine("******************");
                Console.WriteLine("  Phone   Book");
                Console.WriteLine("******************\n");

                Console.WriteLine("Please choose an option\n" +
                                  "1.Add contact\n" +
                                  "2.Remove contact\n" +
                                  "3.Edit contact\n" +
                                  "4.Show all contacts\n" +
                                  "5.Search for contact\n" +
                                  "6.Exit\n");

                switch (Console.ReadLine() ?? string.Empty)
                {
                    case "1":
                        Console.Clear();
                        AddContact();
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadLine();

                        break;
                    case "2":
                        Console.Clear();
                        RemoveContact();
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        EditContact();
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        ShowContact();

                        Console.ReadLine();
                        break;
                    case "5":
                        Console.Clear();
                        SearchContact();
                        Console.ReadLine();
                        break;
                    case "6":
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


            Console.Write("Please write the name of your contact: ");
            string? name = Console.ReadLine() ?? string.Empty;


            if (name == "" || name == null) name = "Contact name was not assign";

            Console.Write("Please write the phone number of your contact: ");


            string? phoneNumber = Console.ReadLine() ?? string.Empty;

            if (CheckPhoneNumberPattern(phoneNumber))
            {
                Contacts.Add(new Contact(name, phoneNumber));
                Console.WriteLine("\nContact was added!\n");
            }




        }
        private void RemoveContact()
        {
            if (Contacts.Count < 1)
            {
                Console.WriteLine("No contacts yet, please add a contact using the Add Contact option\n");
                Console.WriteLine("Press any key to return to the main menu...");
            }

            else
            {
                ShowContact();
                Console.WriteLine("Choose contact ID to delete from your contact: ");
                _ = int.TryParse(Console.ReadLine(), out int choosenID);
                try
                {
                    Contacts.Remove(Contacts[choosenID - 1]);
                    Console.WriteLine("Contact was removed, please press any key to return to the main menu...");
                }
                catch
                {
                    Console.WriteLine($"Contact with ID {choosenID} was not found, press any key to return to the main menu...");
                }


            }






        }
        private void EditContact()
        {
            if (Contacts.Count < 1)
            {
                Console.WriteLine("No contacts yet, please add a contact using the Add Contact option\n");
                Console.WriteLine("Press any key to return to the main menu...");
            }

            else
            {
                ShowContact();
                Console.Write("\nPlease choose the ID of the contact you want to edit: \n");
                _ = int.TryParse(Console.ReadLine(), out int choosenID);
                Console.Clear();

                try
                {
                    Console.WriteLine($"The contact you choose to edit is: {Contacts[choosenID - 1]}");
                    Console.Write("Would you like change the contact name? please press Y(yes) or N(no): ");
                    string changeName = Console.ReadLine()?.ToLower() ?? string.Empty;
                    if (changeName != "y" && changeName != "n")
                    {
                        Console.WriteLine("Invalid input, please press Y or N, press any key to return to the main menu");
                        return;
                    }
                    if (changeName == "y")
                    {
                        Console.Write("Change contact name to: ");
                        string? newContactName = Console.ReadLine();
                        Contacts[choosenID - 1].FullName = newContactName ?? string.Empty;
                    }


                    Console.Write("Would you like change the contact phone number? please press Y(yes) or N(no): ");
                    string changePhoneNumber = Console.ReadLine() ?? string.Empty;
                    if (changePhoneNumber != "y" && changePhoneNumber != "n")
                    {
                        Console.WriteLine("Invalid input, please press Y or N, press any key to return to the main menu");
                        return;
                    }
                    if (changePhoneNumber == "y")
                    {
                        Console.Write("Change phone number to: ");
                        string? newContactMobile = Console.ReadLine() ?? string.Empty;
                        if (CheckPhoneNumberPattern(newContactMobile))
                        {
                            Contacts[choosenID - 1].PhoneNumber = newContactMobile;

                        }
                    }

                    EditContactMessage(changeName, changePhoneNumber);

                }
                catch
                {
                    Console.WriteLine($"Contact with ID {choosenID} was not found, press any key to return to the main menu...");
                }




            }






        }
        private void SearchContact()
        {
            if (Contacts.Count < 1)
            {
                Console.WriteLine("No contacts yet, please add a contact using the Add Contact option\n");
                Console.WriteLine("Press any key to return to the main menu...");
            }
            else
            {
                Console.WriteLine("Please write the name or mobile of the contact you are searching for:");
                string? nameOrMobile = Console.ReadLine()?.ToLower() ?? string.Empty;

                List<Contact> foundContact = Contacts.Where(x => x.FullName.ToLower().Contains(nameOrMobile) || x.PhoneNumber.Contains(nameOrMobile)).ToList();

                if (foundContact.Count <= 0)
                {
                    Console.WriteLine("No Contact was found, press any key to return to the main menu...");
                    return;
                }

                Console.WriteLine("\n");
                Console.WriteLine("Searching...\n");
                Thread.Sleep(1500);
                Console.WriteLine($"{foundContact.Count} contact/s was/were found:\n");

                foreach (var contact in foundContact)
                {
                    Console.WriteLine(contact);
                }




            }

        }
        private void ShowContact()
        {
            if (Contacts.Count < 1)
            {
                Console.WriteLine("No contacts yet, please add a contact using the Add Contact option\n");
                Console.WriteLine("Press any key to return to the main menu...");

                return;
            }

            Console.WriteLine(" ID | Contact Name | Contact Mobile");
            Console.WriteLine("-----------------------------------");
            for (int i = 0; i < Contacts.Count; i++)
            {
                Console.WriteLine($" {i + 1,-3}     {Contacts[i].FullName,-9}{Contacts[i].PhoneNumber,14}\n");
            }
            Console.WriteLine("Press any key to return to the main menu...");


        }
        private static bool CheckPhoneNumberPattern(string number)
        {
            string mobilePattern = @"^(00972|0|\+972)[5][0-9]{8}$";


            if (Regex.Match(number, mobilePattern).Success)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Phone number was at an incorrect format, please use the one of the following patterns:\n" +
                                  "+97205xxxxxxxx\n" +
                                  "05xxxxxxxx\n" +
                                  "05x-xxx-xxxx");
                return false;
            }

        }
        private void EditContactMessage(string name, string number)
        {
            if (name == "y" && number == "y")
            {
                Console.WriteLine("Contact was edited, press any key to return to the main menu...");
            }
            else if (name == "y" && number == "n")
            {
                Console.WriteLine("Contact name edited, press any key to return to the main menu...");
            }
            else if (name == "n" && number == "y")
            {
                Console.WriteLine("Contact phone number edited, press any key to return to the main menu...");
            }
            else
            {
                Console.WriteLine("No changes were made for the contact.");
            }
        }








    }
}

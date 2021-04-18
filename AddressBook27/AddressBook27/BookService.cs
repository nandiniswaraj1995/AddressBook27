using AddressBook27.Model;
using AddressBook27.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook27
{
    class BookService
    {
        ContactRepo contactRepo = new ContactRepo();
        ContactModel contactModel = new ContactModel();

        public void addDetails(string bookName)
        {
            if (!contactRepo.GetBookByName(bookName))
            {
                contactRepo.AddBook(bookName);
            }
            contactModel.bookName = bookName;
            Console.WriteLine("Enter First Name:");
            contactModel.firstName = Console.ReadLine();
            if (contactRepo.checkDuplicateNameByBook(contactModel))
            {
                Console.WriteLine("person all ready exists");
                return;
            }
            Console.WriteLine("Enter Last Name");
            contactModel.lastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            contactModel.address = Console.ReadLine();
            Console.WriteLine("Enter City");
            contactModel.city = Console.ReadLine();
            Console.WriteLine("Enter State");
            contactModel.state = Console.ReadLine();
            Console.WriteLine("Enter zip");
            contactModel.zip = Console.ReadLine();
            Console.WriteLine("Enter Phone Number");
            contactModel.phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email");
            contactModel.email = Console.ReadLine();
           
            if (contactRepo.AddContact(contactModel))
                Console.WriteLine("Records added successfully");

        }


        internal void editContact(string firstName)
        {
            if (!contactRepo.GetPersonByName(firstName))
            {
                Console.WriteLine("Person  Not Exist");
            }
            else
            {
                ContactModel contactModel = new ContactModel();
                Console.WriteLine("which data you want to edit please enter your choice");
                Console.WriteLine("1.first Name");
                Console.WriteLine("2.last Name");
                Console.WriteLine("3.address");
                Console.WriteLine("4.city ");
                Console.WriteLine("5.state");
                Console.WriteLine("6.zip code");
                Console.WriteLine("7.phone number");
                Console.WriteLine("8.email");
                string choice = Console.ReadLine();
                switch (choice)
                {

                    case "1":
                        contactRepo.updateFirstName(firstName);
                        break;
                    case "2":
                        contactRepo.updateLastName(firstName);
                        break;
                    case "3":
                        contactRepo.updateAddress(firstName);
                        break;
                    case "4":
                        contactRepo.updateCity(firstName);
                        break;
                    case "5":
                        contactRepo.updateState(firstName);
                        break;
                    case "6":
                        contactRepo.updateZip(firstName);
                        break;
                    case "7":
                        contactRepo.updatePhoneNumber(firstName);
                        break;
                    case "8":
                        contactRepo.updateEmail(firstName);
                        break;
                    default:
                        Console.WriteLine("Invalid choice try again!");
                        break;

                }

            }
        }


        public void deleteContact(string firstName)
        {
            if (!contactRepo.GetPersonByName(firstName))
            {
                Console.WriteLine("Person  Not Exist");
            }
            else
            {
                contactRepo.DeleteContact(firstName);
            }

        }


       public void searchPersonAccrossCityOrState(string cityOrState)
        {
            contactRepo.searchPersonAccrossCityOrState(cityOrState);
        }

        public void countPersonAccrossCityOrState(string cityOrState , int choice)
        {
            contactRepo.countPersonAccrossCityOrState(cityOrState , choice);
        }





    }
}

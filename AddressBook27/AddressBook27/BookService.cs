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
            Console.WriteLine("Enter First Name:");
            contactModel.firstName = Console.ReadLine();
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
            contactModel.bookName = bookName;

            if (contactRepo.AddContact(contactModel))
                Console.WriteLine("Records added successfully");

        }
    }
}

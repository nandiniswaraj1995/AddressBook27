using AddressBook27.Model;
using System;

namespace AddressBook27
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactModel model = new ContactModel();
            BookService service = new BookService();
            Console.WriteLine("Wellcome to AddressBook Program!");
            string choice = "";
            while (choice != "close")
            {
                Console.WriteLine("1.AddPerson");
                Console.WriteLine("2.Edit Existing Contact By First Name");
                Console.WriteLine("0.close");
                Console.WriteLine("Enter your choice");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter Book Name");
                        model.bookName = Console.ReadLine();
                        service.addDetails(model.bookName);
                        break;
                    case "2":
                        Console.WriteLine("Enter person's Fisrt name whose data want to edit");
                        model.firstName = Console.ReadLine();
                        service.editContact(model.firstName);
                        break;

                    case "0":
                        choice = "close";
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }

            }

        }
    }
}

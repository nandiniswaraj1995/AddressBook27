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

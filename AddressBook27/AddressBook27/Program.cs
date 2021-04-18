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
                Console.WriteLine("3.Delete Contact By First Name");
                Console.WriteLine("4.Search person by city or state in all address book");
                Console.WriteLine("5.count total person by city or state");
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
                    case "3":
                        Console.WriteLine("Enter person's Fisrt name whose data want to delete");
                        model.firstName = Console.ReadLine();
                        service.deleteContact(model.firstName);
                        break;
                    case "4":
                        Console.WriteLine("Enter choice 1.find persons by city     2.find persons by state");
                        int choice1 = Convert.ToInt32(Console.ReadLine());
                        if(choice1 == 1)
                        {
                            Console.WriteLine("Enter city");
                            model.city = Console.ReadLine();
                            service.searchPersonAccrossCityOrState(model.city);
                        }
                        else
                        {
                            Console.WriteLine("Enter state");
                            model.state = Console.ReadLine();
                            service.searchPersonAccrossCityOrState(model.state);

                        }
                        break;
                    case "5":
                        Console.WriteLine("Enter choice 1.count persons by city     2.count persons by state");
                        int choice2 = Convert.ToInt32(Console.ReadLine());
                        if (choice2 == 1)
                        {
                            Console.WriteLine("Enter city");
                            model.city = Console.ReadLine();
                            service.countPersonAccrossCityOrState(model.city, choice2);
                        }
                        else
                        {
                            Console.WriteLine("Enter state");
                            model.state = Console.ReadLine();
                            service.countPersonAccrossCityOrState(model.state, choice2);

                        }
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

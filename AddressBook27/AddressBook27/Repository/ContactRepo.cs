using AddressBook27.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBook27.Repository
{
    class ContactRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=addressBook27DB;Integrated Security=True";


        public bool GetBookByName(string bookName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                ContactModel model = new ContactModel();
                using (connection)
                {
                    string query = @"Select * from book;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            model.bookName = dr.GetString(1);
                          
                            if (model.bookName == bookName)
                            {
                                return true;
                            }
                            /*  else if (model.bookName == bookModel.bookName && model.bookType != bookModel.bookType)
                              {
                                  Console.WriteLine("bookType Mismatch!");
                              }*/
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool AddBook(string bookName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("sp_AddBook", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@book_name", bookName);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                connection.Close();
            }
            return false;
        }




        public bool AddContact(ContactModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("sp_AddContactInotBook", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@first_name", model.firstName);
                    command.Parameters.AddWithValue("@last_name", model.lastName);
                    command.Parameters.AddWithValue("@address", model.address);
                    command.Parameters.AddWithValue("@city", model.city);
                    command.Parameters.AddWithValue("@state", model.state);
                    command.Parameters.AddWithValue("@zip", model.zip);
                    command.Parameters.AddWithValue("@phone_number", model.phoneNumber);
                    command.Parameters.AddWithValue("@email", model.email);
                    command.Parameters.AddWithValue("@book_name", model.bookName);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                connection.Close();
            }
            return false;
        }


        public bool GetPersonByName(string fisrtName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            ContactModel model = new ContactModel();

            try
            {
                using (connection)
                {
                    string query = @"Select * from contact ;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            model.firstName = dr.GetString(0);
                           
                            if (model.firstName == fisrtName)
                            {
                                return true;
                            }
                            /*  else if (model.bookName == bookModel.bookName && model.bookType != bookModel.bookType)
                              {
                                  Console.WriteLine("bookType Mismatch!");
                              }*/
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return false;
        }



        internal void updateFirstName(string firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            ContactRepo contactRepo = new ContactRepo();
            Console.WriteLine("Enter New Name");
            string newName = Console.ReadLine();
            string query = @"update contact set first_name = '" + newName + "' where first_name = '" + firstName + "';";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result != 0)
            {
                Console.WriteLine("Data Updated Sucessfully");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }


        }

        internal void updateLastName(string firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine("Enter New Last Name");
            string newLastName = Console.ReadLine();
            string query = @"update contact set last_name = '" + newLastName + "' where first_name = '" + firstName + "';";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result != 0)
            {
                Console.WriteLine("Data Updated Sucessfully");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }

        }

        internal void updateAddress(string firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine("Enter New Address");
            string newAddress = Console.ReadLine();
            string query = @"update contact set address = '" + newAddress + "' where first_name = '" + firstName + "';";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result != 0)
            {
                Console.WriteLine("Data Updated Sucessfully");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }


        }

        internal void updateCity(string firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine("Enter New City");
            string newCity = Console.ReadLine();
            string query = @"update contact set city = '" + newCity + "' where first_name = '" + firstName + "';";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result != 0)
            {
                Console.WriteLine("Data Updated Sucessfully");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }


        }

        internal void updateState(string firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine("Enter New State");
            string newState = Console.ReadLine();
            string query = @"update contact set state = '" + newState + "' where first_name = '" + firstName + "';";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result != 0)
            {
                Console.WriteLine("Data Updated Sucessfully");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }

        }

        internal void updateZip(string firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine("Enter New Zip Code");
            string newZip = Console.ReadLine();
            string query = @"update contact set zip = '" + newZip + "' where first_name = '" + firstName + "';";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result != 0)
            {
                Console.WriteLine("Data Updated Sucessfully");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }

        }

        internal void updatePhoneNumber(string firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine("Enter New Phone Number");
            string newPhoneNumner = Console.ReadLine();
            string query = @"update contact set phone_number = '" + newPhoneNumner + "' where first_name = '" + firstName + "';";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result != 0)
            {
                Console.WriteLine("Data Updated Sucessfully");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }

        }

        internal void updateEmail(string firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine("Enter New Email");
            string newEmail = Console.ReadLine();
            string query = @"update contact set email = '" + newEmail + "' where first_name = '" + firstName + "';";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result != 0)
            {
                Console.WriteLine("Data Updated Sucessfully");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }
        }


        internal void DeleteContact(string firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"delete from contact  where first_name = '" + firstName + "';";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            if (result != 0)
            {
                Console.WriteLine("Data Deleted Sucessfully");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }

        }


        public bool checkDuplicateNameByBook(ContactModel contactModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"Select * from contact where book_name = '"+contactModel.bookName+"' and first_name = '"+contactModel.firstName+"';";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string name = dr.GetString(0);
                            string book = dr.GetString(8);
                          
                            if (contactModel.firstName.Equals(name) && contactModel.bookName.Equals(book))
                            {
                                return true;
                            }
                           }
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return false;

        }


        public void searchPersonAccrossCityOrState(string cityOrState)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            ContactModel model = new ContactModel();
            try
            {
                using (connection)
                {
                    string query = @"Select * from contact where city = '" + cityOrState + "' or  state = '" + cityOrState + "';";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            model.firstName = dr.GetString(0);
                            model.lastName = dr.GetString(1);
                            model.address = dr.GetString(2);
                            model.city = dr.GetString(3);
                            model.state = dr.GetString(4);
                            model.zip = dr.GetString(5);
                            model.phoneNumber = dr.GetString(6);
                            model.email = dr.GetString(7);
                            model.bookName = dr.GetString(8);
                            Console.Write(model.firstName+"  "+model.lastName+"  "+model.address+"  "+model.city+"  "+model.state+"  "+model.zip);
                            Console.WriteLine(model.phoneNumber+"  "+model.email+"  "+model.bookName);

                           }
                    }
                    else
                    {
                        Console.WriteLine("No person in this city or state");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

        }

        public void countPersonAccrossCityOrState(string cityOrState , int choice)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            if (choice == 1)
            {
                string query = @"Select count(city) from contact where city = '" + cityOrState + "';";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                var totalPerson = cmd.ExecuteScalar().ToString();
               Console.WriteLine("totalPerson in city : " + totalPerson);
            }
            else
            {
                string query = @"Select count(state) from contact where state = '" + cityOrState + "' ;";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                var totalPerson = cmd.ExecuteScalar().ToString();
               Console.WriteLine("totalPerson in state : " + totalPerson);

            }
        }
                 
        



    }
}

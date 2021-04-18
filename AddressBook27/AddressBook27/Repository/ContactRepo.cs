﻿using AddressBook27.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBook27.Repository
{
    class ContactRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=addressBook27DB;Integrated Security=True";

        public bool AddContact(ContactModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("sp_AddContact", connection);
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


        public bool isPersonNameValid(string firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                ContactModel model = new ContactModel();
                using (connection)
                {
                    string query = @"Select * from address_book;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            model.firstName = dr.GetString(0);
                           
                            if (model.firstName == firstName)
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
            Console.WriteLine("Enter New Name");
            string newName = Console.ReadLine();
            string query = @"update address_book set first_name = '" + newName + "' where first_name = '" + firstName + "';";
            Console.WriteLine(query);
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
            string query = @"update address_book set last_name = '" + newLastName + "' where first_name = '" + firstName + "';";
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
            string query = @"update address_book set address = '" + newAddress + "' where first_name = '" + firstName + "';";
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
            string query = @"update address_book set city = '" + newCity + "' where first_name = '" + firstName + "';";
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
            string query = @"update address_book set state = '" + newState + "' where first_name = '" + firstName + "';";
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
            string query = @"update address_book set zip = '" + newZip + "' where first_name = '" + firstName + "';";
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
            string query = @"update address_book set phone_number = '" + newPhoneNumner + "' where first_name = '" + firstName + "';";
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
            string query = @"update address_book set email = '" + newEmail + "' where first_name = '" + firstName + "';";
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



    }
}

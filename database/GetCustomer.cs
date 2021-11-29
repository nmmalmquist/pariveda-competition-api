using API.Models;
using API.Interfaces;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace API.database
{
    public class GetCustomer : IGetCustomer
    {
        Customer IGetCustomer.GetCustomer(string email)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM customers WHERE email = @email";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@email", email);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            return (
                new Customer()
                {
                    Id = rdr.GetInt32(0),
                    FirstName = rdr.GetString(1),
                    LastName = rdr.GetString(2),
                    Email = rdr.GetString(3),
                    Password = rdr.GetString(4),
                    Birthdate = rdr.GetDateTime(5),
                    DateCreated = rdr.GetDateTime(6),
                    Deleted = rdr.GetBoolean(7)
                }
            );
        }

        public List<Customer> GetAllCustomers()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM customers WHERE deleted = False ORDER BY last_name";
            
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<Customer> allCustomers = new List<Customer>();
            while (rdr.Read())
            {
                allCustomers.Add(new Customer()
                {
                    Id = rdr.GetInt32(0),
                    FirstName = rdr.GetString(1),
                    LastName = rdr.GetString(2),
                    Email = rdr.GetString(3),
                    Password = rdr.GetString(4),
                    Birthdate = rdr.GetDateTime(5),
                    DateCreated = rdr.GetDateTime(6),
                    Deleted = rdr.GetBoolean(7)
                });
            }

            return allCustomers;

        }
    }
}
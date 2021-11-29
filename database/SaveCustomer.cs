using System;
using API.Models;
using API.Interfaces;
using MySql.Data.MySqlClient;

namespace API.database
{
    public class SaveCustomer : ISaveCustomer
    {
        public void AddCustomer(Customer newCustomer )
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "INSERT INTO customers (first_name, last_name, email, password, birthdate, date_created, deleted) VALUES (@first_name, @last_name, @email, @password, @birthdate, @date_created, False)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@first_name", newCustomer.FirstName.ToLower() );
            cmd.Parameters.AddWithValue("@last_name", newCustomer.LastName.ToLower() );
            cmd.Parameters.AddWithValue("@email", newCustomer.Email.ToLower() );
            cmd.Parameters.AddWithValue("@password",  newCustomer.Password.ToLower() );
            cmd.Parameters.AddWithValue("@birthdate", newCustomer.Birthdate);
            cmd.Parameters.AddWithValue("@date_created", DateTime.Now);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        
        }
    }
}
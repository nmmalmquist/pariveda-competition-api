using System;
using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.database{

    public class SaveAdmin : ICreateAdmin
    {
        public void AddAdmin(Admin newAdmin)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "INSERT INTO admins (first_name, last_name, email, password, date_initialize, date_terminated, deleted) VALUES (@first_name, @last_name, @email, @password, @date_initialize, @date_terminated, False)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@first_name", newAdmin.FirstName.ToLower() );
            cmd.Parameters.AddWithValue("@last_name", newAdmin.LastName.ToLower() );
            cmd.Parameters.AddWithValue("@email", newAdmin.Email.ToLower() );
            cmd.Parameters.AddWithValue("@password",  newAdmin.Password.ToLower() );
            cmd.Parameters.AddWithValue("@date_terminated", new DateTime(0001,01,01));
            cmd.Parameters.AddWithValue("@date_initialize", DateTime.Now);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
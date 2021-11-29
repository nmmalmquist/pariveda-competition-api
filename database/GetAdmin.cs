using API.Models;
using API.Interfaces;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace API.database
{
    public class GetAdmins : IGetAdmin
    {
        Admin IGetAdmin.GetAdmin(string email)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM admins WHERE email = @email";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@email", email);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            return (
                new Admin()
                {
                    Id = rdr.GetInt32(0),
                    FirstName = rdr.GetString(1),
                    LastName = rdr.GetString(2),
                    Email = rdr.GetString(3),
                    Password = rdr.GetString(4),
                    DateInitialized = rdr.GetDateTime(5),
                    DateTerminated = rdr.GetDateTime(6),
                    Deleted = rdr.GetBoolean(7)
                }
            );
        }

        public List<Admin> GetAllAdmins()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM admins WHERE deleted = False ORDER BY last_name";
            
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<Admin> allAdmins = new List<Admin>();
            while (rdr.Read())
            {
                allAdmins.Add(new Admin()
                {
                    Id = rdr.GetInt32(0),
                    FirstName = rdr.GetString(1),
                    LastName = rdr.GetString(2),
                    Email = rdr.GetString(3),
                    Password = rdr.GetString(4),
                    DateInitialized = rdr.GetDateTime(5),
                    DateTerminated = rdr.GetDateTime(6),
                    Deleted = rdr.GetBoolean(7)
                });
            }

            return allAdmins;

        }
    }
}
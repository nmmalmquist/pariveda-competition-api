using System;
using API.Models;
using API.Interfaces;
using MySql.Data.MySqlClient;

namespace API.database
{
    public class DeleteAdmin :IDeleteAdmin
    {
        void IDeleteAdmin.DeleteAdmin(int id)
        {
            ConnectionString myConnectionString = new ConnectionString();
            string cs = myConnectionString.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE admins SET deleted = True WHERE id = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }
    }
}
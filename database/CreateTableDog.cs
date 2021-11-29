using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.database
{
    public class CreateTableDog : ICreateTable
    {
        public void CreateTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE dogs(id INTEGER PRIMARY KEY AUTO_INCREMENT, breed TEXT, age INTEGER, Cost INTEGER)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();


        }
    }
}
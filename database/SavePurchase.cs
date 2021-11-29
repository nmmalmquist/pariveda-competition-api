using System;

using API.Models;
using API.Interfaces;
using MySql.Data.MySqlClient;

namespace API.database
{
    public class SavePurchase :IPostPurchase
    {
         public void AddPurchase(Purchase newPurchase )
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "INSERT INTO Purchases (customerFirstName, customerLastName, customerEmail, customerPhoneNumber, date, cost) VALUES (@first_name, @last_name, @email, @phoneNumber, @date, @cost)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@first_name", newPurchase.CustomerFirstName.ToLower() );
            cmd.Parameters.AddWithValue("@last_name", newPurchase.CustomerLastName.ToLower() );
            cmd.Parameters.AddWithValue("@email", newPurchase.CustomerEmail.ToLower() );
            cmd.Parameters.AddWithValue("@phoneNumber",  newPurchase.CustomerPhoneNumber.ToLower() );
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@cost", newPurchase.Cost);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        
        }
    }
}
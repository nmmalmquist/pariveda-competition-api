using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.database
{
    public class SaveDog : ISaveDog
    {
        public void CreateDog(Dog myDog)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO dogs(breed, age, cost, name, description, sale_type, deleted) VALUES(@breed, @age, @cost, @name, @description, @sale_type, False)";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue(@"breed", myDog.Breed);
            cmd.Parameters.AddWithValue(@"age", myDog.Age);
            cmd.Parameters.AddWithValue(@"cost", myDog.Cost);
            cmd.Parameters.AddWithValue(@"name", myDog.Name);
            cmd.Parameters.AddWithValue(@"description", myDog.Description);
            cmd.Parameters.AddWithValue(@"sale_type", myDog.SaleType);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            


        }

        void ISaveDog.SaveDog(Dog myDog)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE dogs SET breed = @breed, age = @age, cost = @cost WHERE id = @id";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue(@"id", myDog.Id);
            cmd.Parameters.AddWithValue(@"breed", myDog.Breed);
            cmd.Parameters.AddWithValue(@"age", myDog.Age);
            cmd.Parameters.AddWithValue(@"cost", myDog.Cost);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

        }
    }
}
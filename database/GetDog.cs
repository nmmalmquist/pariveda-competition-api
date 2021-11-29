using System;
using System.Collections.Generic;
using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;


namespace API.database
{
    public class GetDog : IGetDogData
    {
        private const string PIC_EXTENSION = ".jpg";
        public List<Dog> GetAllDogs(string saleType)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            //our sql statement will be determined based on what saleType is passed into dogController
            string stm = "";
            if (saleType == "rent")
            {
                stm = "SELECT * FROM dogs WHERE sale_type = 'Rent' ORDER BY name";
            }
            else if (saleType == "buy")
            {
                stm = "SELECT * FROM dogs WHERE sale_type = 'Buy' ORDER BY name";
            }
            else if (saleType == "all")
            {
                stm = "SELECT * FROM dogs ORDER BY name";
            }
            else
            {
                Console.WriteLine("Invalid SQL statement.");
                stm = "This is not a valid sql statement";
            }

            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<Dog> allDogs = new List<Dog>();
            while (rdr.Read())
            {
                allDogs.Add(new Dog()
                {
                    Id = rdr.GetInt32(0),
                    Breed = rdr.GetString(1),
                    Age = rdr.GetInt32(2),
                    Cost = rdr.GetInt32(3),
                    Name = rdr.GetString(4),
                    Description = rdr.GetString(5),
                    SaleType = rdr.GetString(6),
                    MainImageName = "dog-pic-main-" + rdr.GetInt32(0) + PIC_EXTENSION,
                    Image1Name = "dog-pic-image1-" + rdr.GetInt32(0) + PIC_EXTENSION,
                    Image2Name =  "dog-pic-image2-" + rdr.GetInt32(0) + PIC_EXTENSION,
                    Image3Name =  "dog-pic-image3-" + rdr.GetInt32(0) + PIC_EXTENSION,
                    Deleted = rdr.GetBoolean(7)
                });
            }

            return allDogs;

        }


        Dog IGetDogData.GetDog(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM dogs WHERE id = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
          
            return (new Dog()
            {
                Id = rdr.GetInt32(0),
                Breed = rdr.GetString(1),
                Age = rdr.GetInt32(2),
                Cost = rdr.GetInt32(3),
                Name = rdr.GetString(4),
                Description = rdr.GetString(5),
                SaleType = rdr.GetString(6),
                MainImageName = "dog-pic-main-" + rdr.GetInt32(0) + PIC_EXTENSION,
                Image1Name = "dog-pic-image1-" + rdr.GetInt32(0) + PIC_EXTENSION,
                Image2Name = "dog-pic-image2-" + rdr.GetInt32(0) + PIC_EXTENSION,
                Image3Name =  "dog-pic-image3-" + rdr.GetInt32(0) + PIC_EXTENSION,
                Deleted = rdr.GetBoolean(7)
            });
        }
        public Dog GetMostRecentDog()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM dogs ORDER BY id DESC LIMIT 1";
            using var cmd = new MySqlCommand(stm, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
          
            return (new Dog()
            {
                Id = rdr.GetInt32(0),
                Breed = rdr.GetString(1),
                Age = rdr.GetInt32(2),
                Cost = rdr.GetInt32(3),
                Name = rdr.GetString(4),
                Description = rdr.GetString(5),
                SaleType = rdr.GetString(6),
                MainImageName = "dog-pic-main-" + rdr.GetInt32(0) + PIC_EXTENSION,
                Image1Name = "dog-pic-image1-" + rdr.GetInt32(0) + PIC_EXTENSION,
                Image2Name = "dog-pic-image2-" + rdr.GetInt32(0) + PIC_EXTENSION,
                Image3Name =  "dog-pic-image3-" + rdr.GetInt32(0) + PIC_EXTENSION,
                Deleted = rdr.GetBoolean(7)
            });
        }
    }
}
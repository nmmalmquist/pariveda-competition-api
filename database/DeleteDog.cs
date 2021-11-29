using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.database
{
    public class DeleteDog : IDeleteDog, IDropTable
    {
        
        public void DropTable(){
            ConnectionString myConnectionString = new ConnectionString();
            string cs = myConnectionString.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS dogs";

            using var cmd = new MySqlCommand(stm,con);
            cmd.ExecuteNonQuery();


        }
        
        void IDeleteDog.DeleteDog(int id)
        {
            ConnectionString myConnectionString = new ConnectionString();
            string cs = myConnectionString.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE dogs SET deleted = True WHERE id = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }
    }
}
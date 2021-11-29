namespace API.Models
{
    public class ConnectionString
    {
        public string cs { get; set; }

        public ConnectionString()
        {
            string server = "g84t6zfpijzwx08q.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "giykc2fb0eehkbqj";
            string port = "3306";
            string username = "q0aut42w3uq82cxz";
            string password = "vxhvlpl6bntgm5ii";

            cs = $@"server={server};user={username};database={database};port={port};password={password};";
        }
    }
}
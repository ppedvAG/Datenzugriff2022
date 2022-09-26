using Microsoft.Data.SqlClient;

namespace HalloDatenbank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string conString = "Server=(localdb)\\mssqllocaldb;Database=NORTHWND;Trusted_Connection=true;TrustServerCertificate=true;";

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            Console.WriteLine("DB Verbindung wurde hergestellt");
                       
        }
    }
}
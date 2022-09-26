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

            try
            {
                con.Open();
                Console.WriteLine("DB Verbindung wurde hergestellt");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT COUNT(*) FROM Employees";
                var count = cmd.ExecuteScalar();
                Console.WriteLine($"Es wurde {count} Employees gefunden");

                SqlCommand queryCmd = new SqlCommand();
                queryCmd.Connection = con;
                queryCmd.CommandText = "SELECT * FROM Employees";
                SqlDataReader reader = queryCmd.ExecuteReader();
                while(reader.Read())
                {
                    //string vorName = reader.GetString(2);
                    //string nachName = (string)reader["LastName"];
                    //int id = reader.GetInt32(0);

                    string nachName = reader.GetString(reader.GetOrdinal("LastName"));
                    string vorName = reader.GetString(reader.GetOrdinal("FirstName"));
                    int id = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
                    DateTime gebDatum = reader.GetDateTime(reader.GetOrdinal("BirthDate"));

                    Console.WriteLine($"[{id}] {vorName} {nachName} ({gebDatum:d})");
                }
                reader.Close();
                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"DB-ERROR: {ex.Message} Code {ex.Number}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

        }
    }
}
using Microsoft.Data.SqlClient;

namespace HalloDbTransaction
{
    internal class Program
    {
        static string conString = "Server=(localdb)\\mssqllocaldb;Database=NORTHWND;Trusted_Connection=true;TrustServerCertificate=true;";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello DB-Transaction");

            IEnumerable<Employee> employees = LoadAllEmployeesFromDB();
            ShowEmployees(employees);
        }

        private static void ShowEmployees(IEnumerable<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"[{emp.Id}] {emp.FirstName} {emp.LastName} ({emp.BirthDate:d})");

            }
        }

        static IEnumerable<Employee> LoadAllEmployeesFromDB()
        {
            using var con = new SqlConnection(conString);
            con.Open();
            using var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Employees";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var emp = new Employee()
                {
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    Id = reader.GetInt32(reader.GetOrdinal("EmployeeId")),
                    BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate"))
                };
                yield return emp;
            }
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
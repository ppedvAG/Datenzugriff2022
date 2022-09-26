using Microsoft.Data.SqlClient;

namespace HalloDbTransaction
{
    internal class Program
    {
        static string conString = "Server=(localdb)\\mssqllocaldb;Database=NORTHWND;Trusted_Connection=true;TrustServerCertificate=true;";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello DB-Transaction");

            IEnumerable<Employee> employees = LoadAllEmployeesFromDB().ToList();
            ShowEmployees(employees);
            Console.WriteLine("Alle 1 Jahr jünger:");
            MakeAllYounger(employees);
            ShowEmployees(employees);
            UpdateEmployeesBirthDate(employees);

        }

        private static void UpdateEmployeesBirthDate(IEnumerable<Employee> employees)
        {
            using var con = new SqlConnection(conString);
            con.Open();
            foreach (var emp in employees)
            {
                using var cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Employees SET BirthDate=@bdate WHERE EmployeeId=@id";
                cmd.Parameters.AddWithValue("@id", emp.Id);
                cmd.Parameters.AddWithValue("@bdate", emp.BirthDate);
                var rowCount = cmd.ExecuteNonQuery();
                if (rowCount == 0) Console.WriteLine($"{emp.LastName} wurde nicht verjüngt!");
                if (rowCount == 1) Console.WriteLine($"{emp.LastName} wurde verjüngt!");
                if (rowCount > 1) Console.WriteLine($"{emp.LastName} PANIK!");
            }

        }

        private static void MakeAllYounger(IEnumerable<Employee> employees)
        {
            foreach (var emp in employees)
            {
                emp.BirthDate = emp.BirthDate.AddYears(1);
            }
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
using System.Runtime.CompilerServices;

namespace HalloLinq
{
    public partial class Form1 : Form
    {
        List<Employee> Employees { get; set; } = new List<Employee>();

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 100; i++)
            {
                Employees.Add(new Employee()
                {
                    Id = i,
                    Name = $"Fred #{i:000}",
                    BirthDate = DateTime.Now.AddDays(-1).AddYears(-40).AddDays(i * 17)
                });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Employees;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = from emp in Employees
                        where emp.BirthDate.Year >= 1984 && emp.Name.StartsWith("F")
                        orderby emp.BirthDate.Month, emp.BirthDate.Day descending
                        select emp;

            dataGridView1.DataSource = query.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Employees.Where(emp => emp.BirthDate.Year >= 1984 && emp.Name.StartsWith("F"))
                                                .OrderBy(x => x.BirthDate.Month)
                                                .ThenByDescending(x => x.BirthDate.Day)
                                                .ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var buttonCount = flowLayoutPanel1.Controls.OfType<Button>().Count();
            MessageBox.Show($"{buttonCount} Buttons");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var avg = Employees.Sum(x => x.BirthDate.Year);
            MessageBox.Show($"{avg} ist das Durchschnittsjahr");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool hasBirthDay = Employees.Any(x => x.BirthDate.Month == DateTime.Now.Month &&
                                                  x.BirthDate.Day == DateTime.Now.Day);
            if (hasBirthDay)
                MessageBox.Show("Einer hat GebTag");
            else
                MessageBox.Show("Keiner hat GebTag");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            Employee nextBirthDay = Employees.FirstOrDefault(x => x.BirthDate >= new DateTime(x.BirthDate.Year, now.Month, now.Day));
            if (nextBirthDay == null)
                MessageBox.Show("Keiner :-(");
            else
                MessageBox.Show($"{nextBirthDay.Name}");
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
using EfCoreCodeFirst.Data;
using EfCoreCodeFirst.Model;

namespace EfCoreCodeFirst
{
    public partial class Form1 : Form
    {
        EfContext _context = new EfContext();

        public Form1()
        {
            InitializeComponent();

            _context.Database.EnsureCreated();
        }

        private void ladenButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _context.Mitarbeiter.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var abt1 = new Abteilung() { Bezeichnung = "Holz" };
            var abt2 = new Abteilung() { Bezeichnung = "Steine" };

            for (int i = 0; i < 100; i++)
            {
                var m = new Mitarbeiter()
                {
                    Name = $"Fred {i:000}",
                    Beruf = "Macht dinge",
                    GebDatum = DateTime.Now.AddYears(-40).AddDays(i * 17)
                };
                if (i % 2 == 0)
                    m.Abteilungen.Add(abt1);
                if (i % 3 == 0)
                    m.Abteilungen.Add(abt2);

                _context.Mitarbeiter.Add(m);
            }
            _context.SaveChanges();
        }
    }
}
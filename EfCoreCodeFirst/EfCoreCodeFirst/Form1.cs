using EfCoreCodeFirst.Data;
using EfCoreCodeFirst.Model;
using Microsoft.EntityFrameworkCore;

namespace EfCoreCodeFirst
{
    public partial class Form1 : Form
    {
        EfContext _context = new EfContext();

        public Form1()
        {
            InitializeComponent();

            _context.Database.EnsureCreated();

            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void DataGridView1_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is IEnumerable<Abteilung> abts)
                e.Value = string.Join(", ", abts.Select(x => x.Bezeichnung));
        }

        private void ladenButton_Click(object sender, EventArgs e)
        {
            _context = new EfContext();

            var query = _context.Mitarbeiter//.Include(x => x.Abteilungen).Include(x => x.Kunden)
                                            .Where(x => x.GebDatum.Month < 13)
                                            .OrderBy(x => x.Abteilungen.Sum(y => y.Bezeichnung.Length));

            dataGridView1.DataSource = query.ToList();

            dataGridView1.Columns.RemoveAt(1);
            dataGridView1.Columns.RemoveAt(1);
            //MessageBox.Show(query.ToQueryString());
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentRow.DataBoundItem is Mitarbeiter m)
            {
                var abts = _context.Abteilungen.Where(x => x.Mitarbeiter.Contains(m));
                var expTxt = $"Explizit: {string.Join(", ", abts.Select(x => x.Bezeichnung))}";
                var direktTxt = $"Direkt: {string.Join(", ", m.Abteilungen.Select(x => x.Bezeichnung))}";

                MessageBox.Show($"{m.Name} \n {expTxt} \n {direktTxt}");
            }
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.DataBoundItem is Mitarbeiter m)
            {
                var msg = $"Soll der Mitarbeiter {m.Name} wirklich gelöscht werden?";
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _context.Mitarbeiter.Remove(m);
                    //_context.SaveChanges();
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int affRows = _context.SaveChanges();
            MessageBox.Show($"{affRows} Zeilen wurden geändert");
        }
    }
}
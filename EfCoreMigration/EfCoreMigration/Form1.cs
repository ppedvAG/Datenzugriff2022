using EfCoreMigration.Data;
using EfCoreMigration.Model;

namespace EfCoreMigration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PizzaContext _context = new PizzaContext();

        private void ladenButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _context.Pizza.ToList();
        }

        private void speichernButton_Click(object sender, EventArgs e)
        {
            _context.SaveChanges();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var newP = new Pizza() { Name = "NEU", Preis = 7m };
            _context.Pizza.Add(newP);
            _context.SaveChanges();
        }
    }
}
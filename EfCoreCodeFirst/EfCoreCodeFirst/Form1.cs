using EfCoreCodeFirst.Data;

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
    }
}
using EfCoreDbFirst.Data;
using System.Linq;
using System.Windows.Forms;

namespace EfCoreDbFirst
{
    public partial class Form1 : Form
    {
        NORTHWNDContext _context = new NORTHWNDContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = _context.Customers.ToList();
        }
    }
}
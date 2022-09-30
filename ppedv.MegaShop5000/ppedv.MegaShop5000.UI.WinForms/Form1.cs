using Bogus;
using ppedv.MegaShop5000.Model;
using ppedv.MegaShop5000.Model.Contracts;
using System.ComponentModel;

namespace ppedv.MegaShop5000.UI.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = liste;
        }

        IRepository repo = new Data.EfCore.EfRepository();

        BindingList<Produkt> liste = new BindingList<Produkt>();

        private void LadenButton_Click(object sender, EventArgs e)
        {
            liste.Clear();
            foreach (var item in repo.Query<Produkt>())
            {
                liste.Add(item);
            }
        }

        private void SapeichernButton_Click(object sender, EventArgs e)
        {
            repo.SaveAll();
        }

        private void DemoButton_Click(object sender, EventArgs e)
        {
            var faker = new Faker<Produkt>().UseSeed(7)
                        .RuleFor(x => x.Name, x => x.Commerce.ProductName())
                        .RuleFor(x => x.Beschreibung, x => x.Commerce.ProductDescription())
                        .RuleFor(x => x.Gewicht, x => Math.Round(x.Random.Double(0.1, 5), 2));

            foreach (var prod in faker.Generate(100))
            {
                repo.Add(prod);
                liste.Add(prod);
            }
        }
    }
}
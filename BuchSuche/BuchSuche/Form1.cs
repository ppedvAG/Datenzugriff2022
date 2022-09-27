using System.Text.Json;

namespace BuchSuche
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={textBox1.Text}";
            var http = new HttpClient();
            var json = await http.GetStringAsync(url);

            BooksResults result = JsonSerializer.Deserialize<BooksResults>(json);

            dataGridView1.DataSource = result.items.Select(x => x.volumeInfo).ToList();

            var sumPrice = result.items.Select(x => x.saleInfo)
                                       .Where(x => x.retailPrice != null)
                                       .Sum(x => x.retailPrice.amount);
            
            MessageBox.Show($"Preis {sumPrice:c}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var data = (IEnumerable<Volumeinfo>)dataGridView1.DataSource;
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText("book.json", json);
            MessageBox.Show("Speichern erfolgreich");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var json = File.ReadAllText("book.json");
            var result = JsonSerializer.Deserialize<IEnumerable<Volumeinfo>>(json);
            dataGridView1.DataSource = result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var data = (IEnumerable<Volumeinfo>)dataGridView1.DataSource;
            var pageCount = data.Sum(x => x.pageCount);
            MessageBox.Show($"{pageCount} Seiten insgesamt");
        }
    }
}
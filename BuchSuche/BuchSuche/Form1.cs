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
        }
    }
}
using ppedv.MegaShop5000.Logic.ProduktService;
using ppedv.MegaShop5000.Model;
using ppedv.MegaShop5000.Model.Contracts;

namespace ppedv.MegaShop5000.UI.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Mega Shop 5000 ***");

            IRepository repo = new Data.EfCore.EfRepository();
            ProduktManager pm = new ProduktManager(repo);

            foreach (var pro in repo.GetAll<Produkt>())
            {
                Console.WriteLine($"{pro.Name} {pro.Gewicht}Kg - {pro.Beschreibung}");
            }

            Console.WriteLine($"Best sold: {pm.GetMostSoldProdukt().Name}");
        }
    }
}
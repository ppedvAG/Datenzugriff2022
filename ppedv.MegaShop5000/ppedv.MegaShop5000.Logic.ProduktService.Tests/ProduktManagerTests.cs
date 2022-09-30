using ppedv.MegaShop5000.Model;

namespace ppedv.MegaShop5000.Logic.ProduktService.Tests
{
    public class ProduktManagerTests
    {
        [Fact]
        public void CalculateBestellung_Bestellung_results_14()
        {
            var pm = new ProduktManager();
            var p1 = new Produkt() { Name = "P1" };
            var p2 = new Produkt() { Name = "P2" };
            var best = new Bestellung();
            best.Positionen.Add(new BestellPosition() { Produkt = p1, Menge = 2 });
            best.Positionen.Add(new BestellPosition() { Produkt = p2, Menge = 1 });
            var pl = new PreisListe();
            pl.Preise.Add(new Preis() { Produkt = p1, Betrag = 5m });
            pl.Preise.Add(new Preis() { Produkt = p2, Betrag = 4m });

            var result = pm.CalculateBestellung(best, pl);

            Assert.Equal(14m, result);
        }
    }
}
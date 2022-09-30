using ppedv.MegaShop5000.Model;
using ppedv.MegaShop5000.Model.Contracts;

namespace ppedv.MegaShop5000.Logic.ProduktService
{
    public class ProduktManager
    {
        public IRepository Repository { get; }

        public ProduktManager(IRepository repository)
        {
            Repository = repository;
        }

        public Produkt GetMostSoldProdukt()
        {
            return Repository.Query<Produkt>()
                             .OrderByDescending(x => x.Positionen.Sum(y => y.Menge))
                             .FirstOrDefault();
        }

        public decimal CalculateBestellung(Bestellung bestellung, PreisListe preisListe)
        {
            if (bestellung == null) throw new ArgumentNullException("bestellung");
            if (preisListe == null) throw new ArgumentNullException("preisListe");

            decimal result = 0;
            foreach (var pos in bestellung.Positionen)
            {
                var preis = preisListe.Preise.FirstOrDefault(x => x.Produkt == pos.Produkt);
                if (preis == null)
                    throw new ArgumentException($"Preis für {pos.Produkt.Name} wurde nicht gefunden");

                result += preis.Betrag * (decimal)pos.Menge;
            }
            return result;
        }
    }
}
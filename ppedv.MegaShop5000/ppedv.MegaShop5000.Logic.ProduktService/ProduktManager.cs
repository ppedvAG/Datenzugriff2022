using ppedv.MegaShop5000.Model;
using System.Security.Cryptography.X509Certificates;

namespace ppedv.MegaShop5000.Logic.ProduktService
{
    public class ProduktManager
    {
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
namespace ppedv.MegaShop5000.Model
{
    public class Preis : Entity
    {
        public decimal Betrag { get; set; }
        public virtual Produkt? Produkt { get; set; }
        public virtual PreisListe? PreisListe { get; set; }
    }
}
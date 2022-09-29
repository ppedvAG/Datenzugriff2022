namespace ppedv.MegaShop5000.Model
{
    public class BestellPosition : Entity
    {
        public double Menge { get; set; }
        public decimal EinzelPreis { get; set; }
        public virtual Bestellung? Bestellung { get; set; }
        public virtual Produkt? Produkt { get; set; }
    }
}
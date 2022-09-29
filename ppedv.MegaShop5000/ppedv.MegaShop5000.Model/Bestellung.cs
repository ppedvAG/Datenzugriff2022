namespace ppedv.MegaShop5000.Model
{
    public class Bestellung : Entity
    {
        public DateTime Datum { get; set; }
        public virtual Kunde? RechnungsAdresse { get; set; }
        public virtual Kunde? Lieferadresse { get; set; }
        public virtual ICollection<BestellPosition> Positionen { get; set; } = new HashSet<BestellPosition>();
    }
}
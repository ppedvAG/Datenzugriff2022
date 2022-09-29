namespace ppedv.MegaShop5000.Model
{
    public class Produkt : Entity
    {
        public string? Name { get; set; }
        public string? Beschreibung { get; set; }
        public double Gewicht { get; set; }
        public virtual ICollection<BestellPosition> Positionen { get; set; } = new HashSet<BestellPosition>();
        public virtual ICollection<Kategorie> Kategorien { get; set; } = new HashSet<Kategorie>();
        public virtual ICollection<Preis> Preise { get; set; } = new HashSet<Preis>();
    }
}
namespace ppedv.MegaShop5000.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class Kunde : Entity
    {
        public string? Name { get; set; }
        public string? Anschrift { get; set; }
        public string? KdNummer { get; set; }
        public DateTime GebDatum { get; set; }

        public virtual ICollection<Bestellung> BestellungRechnung { get; set; } = new HashSet<Bestellung>();
        public virtual ICollection<Bestellung> BestellungLieferung { get; set; } = new HashSet<Bestellung>();
    }

    public class Bestellung : Entity
    {
        public DateTime Datum { get; set; }
        public virtual Kunde? RechnungsAdresse { get; set; }
        public virtual Kunde? Lieferadresse { get; set; }
        public virtual ICollection<BestellPosition> Positionen { get; set; } = new HashSet<BestellPosition>();
    }

    public class BestellPosition : Entity
    {
        public double Menge { get; set; }
        public decimal EinzelPreis { get; set; }
        public virtual Bestellung? Bestellung { get; set; }
        public virtual Produkt? Produkt { get; set; }
    }

    public class Produkt : Entity
    {
        public string? Name { get; set; }
        public string? Beschreibung { get; set; }
        public double Gewicht { get; set; }
        public virtual ICollection<BestellPosition> Positionen { get; set; } = new HashSet<BestellPosition>();
        public virtual ICollection<Kategorie> Kategorien { get; set; } = new HashSet<Kategorie>();
        public virtual ICollection<Preis> Preise { get; set; } = new HashSet<Preis>();
    }

    public class Kategorie : Entity
    {
        public string? Name { get; set; }
        public virtual ICollection<Produkt> Produkte { get; set; } = new HashSet<Produkt>();
    }

    public class Preis : Entity
    {
        public decimal Betrag { get; set; }
        public virtual Produkt? Produkt { get; set; }
        public virtual PreisListe? PreisListe { get; set; }
    }

    public class PreisListe : Entity
    {
        public string? Bezeichnung { get; set; }
        public DateTime GiltAb { get; set; }
        public DateTime? GiltBis { get; set; }
        public virtual ICollection<Preis> Preise { get; set; } = new HashSet<Preis>();
    }
}
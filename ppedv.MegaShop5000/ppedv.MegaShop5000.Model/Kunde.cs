namespace ppedv.MegaShop5000.Model
{
    public class Kunde : Entity
    {
        public string? Name { get; set; }
        public string? Anschrift { get; set; }
        public string? KdNummer { get; set; }
        public DateTime GebDatum { get; set; }

        public virtual ICollection<Bestellung> BestellungRechnung { get; set; } = new HashSet<Bestellung>();
        public virtual ICollection<Bestellung> BestellungLieferung { get; set; } = new HashSet<Bestellung>();
    }
}
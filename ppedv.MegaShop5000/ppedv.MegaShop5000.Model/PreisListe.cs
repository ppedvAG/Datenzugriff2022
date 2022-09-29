namespace ppedv.MegaShop5000.Model
{
    public class PreisListe : Entity
    {
        public string? Bezeichnung { get; set; }
        public DateTime GiltAb { get; set; }
        public DateTime? GiltBis { get; set; }
        public virtual ICollection<Preis> Preise { get; set; } = new HashSet<Preis>();
    }
}
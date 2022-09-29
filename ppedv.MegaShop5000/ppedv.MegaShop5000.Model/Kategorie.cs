namespace ppedv.MegaShop5000.Model
{
    public class Kategorie : Entity
    {
        public string? Name { get; set; }
        public virtual ICollection<Produkt> Produkte { get; set; } = new HashSet<Produkt>();
    }
}
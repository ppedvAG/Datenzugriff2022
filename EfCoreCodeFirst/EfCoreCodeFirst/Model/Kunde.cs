namespace EfCoreCodeFirst.Model
{
    public class Kunde : Person
    {
        public string KdNummer { get; set; } = string.Empty;
        public virtual Mitarbeiter? Mitarbeiter { get; set; }
    }
}

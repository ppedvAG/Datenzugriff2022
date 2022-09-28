namespace EfCoreCodeFirst.Model
{
    public class Kunde : Person
    {
        public string KdNummer { get; set; } = string.Empty;
        public Mitarbeiter? Mitarbeiter { get; set; }
    }
}

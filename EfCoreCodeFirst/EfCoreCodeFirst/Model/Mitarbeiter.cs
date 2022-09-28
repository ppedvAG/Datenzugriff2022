namespace EfCoreCodeFirst.Model
{
    public class Mitarbeiter : Person
    {
        public string Beruf { get; set; } = string.Empty;
        public ICollection<Kunde> Kunden { get; set; } = new HashSet<Kunde>();
        public ICollection<Abteilung> Abteilungen { get; set; } = new HashSet<Abteilung>();
    }
}

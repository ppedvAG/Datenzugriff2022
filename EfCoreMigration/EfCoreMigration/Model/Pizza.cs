﻿namespace EfCoreMigration.Model
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Preis { get; set; }
        public int KCal { get; set; }
        public bool Vegetarisch { get; set; }
    }
}

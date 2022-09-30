using ppedv.MegaShop5000.Model;

namespace ppedv.MegaShop5000.Data.EfCore.Tests
{
    public class EfContextTests
    {
        private void PrepareDB()
        {
            using var con = new EfContext();
            con.Database.EnsureCreated();
        }

        [Fact]
        public void Can_create_database()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();

            var wasCreated = con.Database.EnsureCreated();

            Assert.True(wasCreated);
        }

        [Fact]
        public void Can_add_Produkt()
        {
            PrepareDB();
            var meinProd = new Produkt() { Gewicht = 3.4, Name = "Dings", Beschreibung = "Ein tolles Dings" };
            var con = new EfContext();

            con.Produkte.Add(meinProd);
            var rows = con.SaveChanges();
            Assert.Equal(1, rows);
        }

        [Fact]
        public void Can_add_and_read_Produkt()
        {
            PrepareDB();
            var meinProd = new Produkt() { Gewicht = 3.4, Name = "Dings", Beschreibung = "Ein tolles Dings" };

            using (var con = new EfContext())
            {
                con.Produkte.Add(meinProd);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Produkte.Find(meinProd.Id);
                Assert.NotNull(loaded);
                Assert.Equal(meinProd.Name, loaded.Name);
            }
        }

        [Fact]
        public void Can_add_and_delete_Produkt()
        {
            PrepareDB();
            var meinProd = new Produkt() { Gewicht = 3.4, Name = "Dings", Beschreibung = "Ein tolles Dings" };

            using (var con = new EfContext())
            {
                con.Produkte.Add(meinProd);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Produkte.Find(meinProd.Id);
                con.Produkte.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Produkte.Find(meinProd.Id);
                Assert.Null(loaded);
            }
        }

        [Fact]
        public void Can_update_Produkt()
        {
            PrepareDB();
            var meinProd = new Produkt() { Gewicht = 3.4, Name = "Dings", Beschreibung = "Ein tolles Dings" };
            var newName = "Teil";

            using (var con = new EfContext())
            {
                con.Produkte.Add(meinProd);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Produkte.Find(meinProd.Id);
                loaded.Name = newName;
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Produkte.Find(meinProd.Id);
                Assert.Equal(newName, loaded.Name);
            }
        }

        [Fact]
        public void Delete_Preisliste_should_delete_all_Preise()
        {
            PrepareDB();
            var pl = new PreisListe() { Bezeichnung = "Killme" };
            var preis1 = new Preis() { Betrag = 2m };
            var preis2 = new Preis() { Betrag = 5m };
            pl.Preise.Add(preis1);
            pl.Preise.Add(preis2);

            using (var con = new EfContext())
            {
                con.Preislisten.Add(pl);
                var rows = con.SaveChanges();
                Assert.Equal(3, rows);
            }

            using (var con = new EfContext())
            {
                var loaded = con.Preislisten.Find(pl.Id);
                Assert.Equal(2, loaded.Preise.Count); //prüfen ob 2 Preis in der Liste sind (INSERT cascade)
                con.Preislisten.Remove(loaded);
                var rows = con.SaveChanges();
                Assert.Equal(3, rows);
            }

            using (var con = new EfContext())
            {
                Assert.Null(con.Preise.Find(preis1.Id));
                Assert.Null(con.Preise.Find(preis2.Id));
            }

        }
    }
}
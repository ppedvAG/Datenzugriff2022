using Moq;
using ppedv.MegaShop5000.Model;
using ppedv.MegaShop5000.Model.Contracts;

namespace ppedv.MegaShop5000.Logic.ProduktService.Tests
{
    public class ProduktManagerTests
    {
        [Fact]
        public void GetMostSoldProdukt_3_produkte_p2_moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.Query<Produkt>()).Returns(() =>
            {
                var p1 = new Produkt() { Name = "P1" };
                p1.Positionen.Add(new BestellPosition() { Menge = 1 });
                var p2 = new Produkt() { Name = "P2" };
                p2.Positionen.Add(new BestellPosition() { Menge = 2 });
                p2.Positionen.Add(new BestellPosition() { Menge = 2 });
                var p3 = new Produkt() { Name = "P3" };
                p3.Positionen.Add(new BestellPosition() { Menge = 3 });

                return new[] { p1, p2, p3 }.AsQueryable();
            });
            var pm = new ProduktManager(mock.Object);

            var result = pm.GetMostSoldProdukt();

            Assert.Equal("P2", result.Name);
        }


        [Fact]
        public void GetMostSoldProdukt_3_produkte_p2()
        {
            var pm = new ProduktManager(new TestRepo());

            var result = pm.GetMostSoldProdukt();

            Assert.Equal("P2", result.Name);
        }


        [Fact]
        public void CalculateBestellung_Bestellung_results_14()
        {
            var pm = new ProduktManager(null);
            var p1 = new Produkt() { Name = "P1" };
            var p2 = new Produkt() { Name = "P2" };
            var best = new Bestellung();
            best.Positionen.Add(new BestellPosition() { Produkt = p1, Menge = 2 });
            best.Positionen.Add(new BestellPosition() { Produkt = p2, Menge = 1 });
            var pl = new PreisListe();
            pl.Preise.Add(new Preis() { Produkt = p1, Betrag = 5m });
            pl.Preise.Add(new Preis() { Produkt = p2, Betrag = 4m });

            var result = pm.CalculateBestellung(best, pl);

            Assert.Equal(14m, result);
        }
    }

    class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            if (typeof(Produkt) == typeof(T))
            {
                var p1 = new Produkt() { Name = "P1" };
                p1.Positionen.Add(new BestellPosition() { Menge = 1 });
                var p2 = new Produkt() { Name = "P2" };
                p2.Positionen.Add(new BestellPosition() { Menge = 2 });
                p2.Positionen.Add(new BestellPosition() { Menge = 2 });
                var p3 = new Produkt() { Name = "P3" };
                p3.Positionen.Add(new BestellPosition() { Menge = 3 });

                return new[] { p1, p2, p3 }.Cast<T>().AsQueryable();
            }
            throw new NotImplementedException();
        }

        public int SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
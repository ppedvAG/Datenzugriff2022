namespace ppedv.MegaShop5000.Data.EfCore.Tests
{
    public class EfContextTests
    {
        [Fact]
        public void Can_create_database()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();

            var wasCreated = con.Database.EnsureCreated();

            Assert.True(wasCreated);
        }
    }
}
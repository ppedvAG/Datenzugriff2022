namespace ppedv.MegaShop5000.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
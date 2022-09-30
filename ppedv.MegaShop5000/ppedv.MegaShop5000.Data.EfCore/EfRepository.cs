using ppedv.MegaShop5000.Model;
using ppedv.MegaShop5000.Model.Contracts;

namespace ppedv.MegaShop5000.Data.EfCore
{
    public class EfRepository : IRepository
    {
        EfContext _context = new EfContext();

        public void Add<T>(T entity) where T : Entity
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _context.Set<T>();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _context.Find<T>(id);
        }

        public int SaveAll()
        {
            return _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Update(entity);
        }
    }
}

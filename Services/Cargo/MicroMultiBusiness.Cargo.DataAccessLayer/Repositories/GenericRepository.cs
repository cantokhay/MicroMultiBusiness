using MicroMultiBusiness.Cargo.DataAccessLayer.Abstract;
using MicroMultiBusiness.Cargo.DataAccessLayer.Concrete;

namespace MicroMultiBusiness.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            var entityList = _context.Set<T>().ToList();
            return entityList;
        }

        public T GetById(int id)
        {
            var entity = _context.Set<T>().Find(id);
            return entity;
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}

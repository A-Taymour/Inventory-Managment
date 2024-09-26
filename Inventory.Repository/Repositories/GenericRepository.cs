using Inventory.Data;
using Microsoft.EntityFrameworkCore;

namespace Task.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDBcontext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDBcontext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}

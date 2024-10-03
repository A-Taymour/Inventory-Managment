using System.Linq.Expressions;

namespace Task.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        public IQueryable<TEntity> GetAllQueryable();   
    }
}

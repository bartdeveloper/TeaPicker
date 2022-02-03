using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeaPicker.DataAccess.Data;

namespace TeaPicker.DataAccess.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TeaPickerDbContext _context;

        public Repository(TeaPickerDbContext context)
        {
            _context = context;
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public T Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}

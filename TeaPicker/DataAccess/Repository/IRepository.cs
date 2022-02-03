using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TeaPicker.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        T Create(T entity); 
        T GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        public T Update(T entity);
        void Delete(T entity);
    }
}

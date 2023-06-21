using System.Linq.Expressions;

namespace ToDoProject.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        // aq iwyeba 
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        void Add(T entity);
        //void Update(T entity);
        void Delete(T entity);
    }
}

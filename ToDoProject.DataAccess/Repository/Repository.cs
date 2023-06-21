using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoProject.DataAccess.Data;
using ToDoProject.Domain.Interfaces;

namespace ToDoProject.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            query = query.Where(filter);

            return query.FirstOrDefault(filter);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _context.Set<T>();

            return query.ToList();
        }
    }
}

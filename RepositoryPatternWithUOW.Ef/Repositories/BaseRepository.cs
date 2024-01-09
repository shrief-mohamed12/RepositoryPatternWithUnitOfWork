using RepositoryPatternWithUOW.Core.Constants;
using RepositoryPatternWithUOW.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Ef.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Add(T Entity)
        {
            _context.Add(Entity);
            return Entity;
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> match, int? take, int? skip, 
            Expression<Func<T, object>> orderBy = null, string orderBydirection = "ASC")
        {
            IQueryable<T> query= _context.Set<T>().Where(match);
            if(take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);
            if (orderBy != null)
            { 
                if (orderBydirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else 
                    query = query.OrderByDescending(orderBy);

            }
            return query.ToList();
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }
       
        public  T Update(T Entity)
        {
            _context.Update(Entity);
            return Entity;
        }
        public void Delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);
        }
         public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities); 
        }
        public void Attach(T Entity)
        {
            _context.Attach(Entity);
        }
        public int Count()
        {
           return _context.Set<T>().Count();
        }
        public int Count(Expression<Func<T, bool>> criteria)
        {
           return _context.Set<T>().Count(criteria);
        }
    }
}

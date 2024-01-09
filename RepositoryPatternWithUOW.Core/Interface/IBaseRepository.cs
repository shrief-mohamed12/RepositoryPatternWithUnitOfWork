using RepositoryPatternWithUOW.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Interface
{
    public  interface IBaseRepository<T> where T : class
    {
        T GetByID(int id);
        T Find(Expression<Func<T,bool>> match);
        IEnumerable<T> Find( Expression<Func<T,bool>> match ,int? take ,int? skip,
            Expression<Func<T,object>> orderBy = null,string orderBydirection= OrderBy.Ascending);
        T Add(T Entity);
        T Update(T Entity);
        void Delete(T Entity);
        void DeleteRange(IEnumerable<T> entities);
        void Attach (T Entity);
        int Count ();
        int Count(Expression<Func<T, bool>> criteria);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepositoryBaseIdentity<T>
    {
        void Update(T entity);
        IQueryable<T> FindByConditionIdentity(Expression<Func<T, bool>> expression, bool trackChanges);
        IQueryable FindByUsername(string userName, bool trackChanges);
    }
}

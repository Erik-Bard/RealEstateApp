using Entities;
using IdentityLibrary;
using IdentityLibrary.Authentication;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBaseIdentity<T> : IRepositoryBaseIdentity<T> where T : class
    {
        private RepositoryContext _identityContext;

        public RepositoryBaseIdentity(RepositoryContext identityContext)
        {
            this._identityContext = identityContext;
        }

        public void Update(T entity) => _identityContext.Set<T>().Update(entity);
        public void Create(T entity) => _identityContext.Set<T>().Add(entity);

        public IQueryable<T> FindByConditionIdentity(Expression<Func<T, bool>> expression, bool trackChanges) =>
           !trackChanges ?
            _identityContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
            _identityContext.Set<T>()
                .Where(expression);

        public IQueryable FindByUsername(string userName, bool trackChanges) =>
            !trackChanges ?
            _identityContext.Users
                .Where(x => x.UserName == userName)
                .AsNoTracking() :
            _identityContext.Users
                .Where(x => x.Email == userName)
                .AsNoTracking();

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            _identityContext.Set<T>()
                .AsNoTracking() :
            _identityContext.Set<T>();
    }
}

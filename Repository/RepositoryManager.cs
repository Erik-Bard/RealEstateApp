using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private PropertyRepository _propertyRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }

        public IPropertyRepository Property {
            get
            {
                if(_propertyRepository == null)
                {
                    _propertyRepository = new PropertyRepository(_repositoryContext);
                }
                return _propertyRepository;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}

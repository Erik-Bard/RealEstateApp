using Entities;
using IdentityLibrary;
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
        private AdvertismentRepository _advertismentRepository;

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

        public IAdvertismentRepository Advertisment
        {
            get
            {
                if (_advertismentRepository == null)
                {
                    _advertismentRepository = new AdvertismentRepository(_repositoryContext);
                }
                return _advertismentRepository;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}

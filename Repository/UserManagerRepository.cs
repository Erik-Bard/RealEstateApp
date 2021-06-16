using Entities;
using Entities.Models;
using IdentityLibrary;
using IdentityLibrary.Authentication;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserManagerRepository : RepositoryBaseIdentity<User>, IUserManagerRepository
    {
        private UserRepository _userRepository;
        private RepositoryContext _dbContext;

        public UserManagerRepository(RepositoryContext dbContext) : base (dbContext)
        {
            this._dbContext = dbContext;
        }


        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }
                return _userRepository;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

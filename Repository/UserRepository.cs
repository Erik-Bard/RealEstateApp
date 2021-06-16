using Entities;
using Entities.Models;
using IdentityLibrary.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBaseIdentity<User>, IUserRepository
    {
        private readonly RepositoryContext _dbContext;

        public UserRepository(RepositoryContext dbContext) : base (dbContext)
        {
            this._dbContext = dbContext;
        }

        public User GetUser(string userName, bool trackChanges) =>
            FindByConditionIdentity(x => x.UserName.Equals(userName), trackChanges)
                .FirstOrDefault();

        public User GetUserByGuid(Guid id, bool trackChanges) =>
            FindByConditionIdentity(x => x.UserId.Equals(id.ToString()), trackChanges)
                .FirstOrDefault();

        public void UpdateUser(User user)
        {
            Update(user);
        }

        public ICollection<Rating> GetRatingsByUserIdAsync(Guid id, bool trackChanges)
        {
            FindAll(false);
            var user = GetUserByGuid(id, trackChanges: false);
            var search = _dbContext.Ratings.Where(x => x.WrittenByUserId == user.UserId).ToList();
            return search;
        }

        public ICollection<User> FindAllUsersGeneric() =>
            FindAll(false).ToList();

        public User PopulateRatingsLists(User user)
        {
            var query = (from e in _dbContext.Ratings
                         select e).ToList();
            if (user == null)
            {
                return null;
            }
            if (user.MyRatings.Count() == 0)
            {
                foreach (var rating in query)
                {
                    user.MyRatings.Add(rating);
                }
            }
            if (user.RatingsDoneByMe.Count() == 0)
            {
                foreach (var rating in query)
                {
                    user.RatingsDoneByMe.Add(rating);
                }
            }
            return user;
        }

        public void CreateUser(User user)
        {
            Create(user);
        }
    }
}

using Entities.Models;
using IdentityLibrary.Authentication;
using IdentityLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string userName, bool trackChanges);
        User GetUserByGuid(Guid id, bool trackChanges);
        //Task<ICollection<Rating>> GetRatingsByUserIdAsync(string id, bool trackChanges);
        ICollection<Rating> GetRatingsByUserIdAsync(Guid id, bool trackChanges);
        void UpdateUser(User user);
        void CreateUser(User user);
        User PopulateRatingsLists(User user);
        ICollection<User> FindAllUsersGeneric();
    }
}

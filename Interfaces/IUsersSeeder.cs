using IdentityLibrary.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUsersSeeder
    {
        void SeedFromSqlScript();
        void StandardUserSeeder();
        void AdminUserSeeder();
        //void GenericRoleMethod(ApplicationUser user);
    }
}

using Entities.Models;
using IdentityLibrary;
using IdentityLibrary.Authentication;
using IdentityLibrary.Models;
using IdentityLibrary.Roles;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.API.Extensions
{
    public class UsersSeeder : IUsersSeeder
    {
        private readonly IUserManagerRepository _userRepository;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _db;

        public UsersSeeder(
            IUserManagerRepository userRepository,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db)
        {
            this._userRepository = userRepository;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this._db = db;
        }

        public void SeedFromSqlScript()
        {
            using (_db)
            using (var command = _db.Database.GetDbConnection().CreateCommand())
            {
                string path = Directory.GetCurrentDirectory();
                FileInfo file = new FileInfo($"..\\SeedUsersScript.sql");
                string script = file.OpenText().ReadToEnd();
                command.CommandText = script;
                _db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {

                }
            }
        }

        public void StandardUserSeeder()
        {
            User user1 = new User()
            {
                Email = "test@mail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "TestUser",
                Password = "Password@123",
                UserId = "e1f482f7-4b7e-4197-acfc-d57cd8e3920e"
            };

            User user2 = new User()
            {
                Email = "hans.svyger@mail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Hans Svyger",
                Password = "Password@123",
                UserId = "82240c53-29a9-4e5b-882d-580d25febd5e"
            };

            _userRepository.UserRepository.CreateUser(user1);
            _userRepository.UserRepository.CreateUser(user2);
            _userRepository.Save();

            //GenericRoleMethod(user1);
        }

        public void AdminUserSeeder()
        {
            User user = new User()
            {
                Email = "admin@mail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Admin-TestUser",
                Password = "Password@123",
                UserId = "16540c53-29a9-4e5b-882d-580d25febd5e"
            };

            _userRepository.UserRepository.CreateUser(user);
            _userRepository.Save();

            //GenericRoleMethod(user);
        }

        //public async void GenericRoleMethod(ApplicationUser user)
        //{
        //    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //    if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //    if (await roleManager.RoleExistsAsync(UserRoles.Admin))
        //    {
        //        await userManager.AddToRoleAsync(user, UserRoles.Admin);
        //    }
        //}
    }
}

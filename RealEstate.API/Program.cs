using Entities;
using IdentityLibrary;
using IdentityLibrary.Authentication;
using Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RealEstate.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var services = scope.ServiceProvider;
                    ApplicationDbContext UserContext = services.GetRequiredService<ApplicationDbContext>();
                    RepositoryContext dbContext = scope.ServiceProvider.GetService<RepositoryContext>();
                    //If database doesent exist, run the seeder
                    bool DatabaseDoesNotExist = dbContext.Database.EnsureCreated();
                    if (!UserContext.Database.EnsureCreated())
                    {
                        UserContext.Database.Migrate();
                        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                        var repository = services.GetRequiredService<IUserManagerRepository>();
                        UsersSeeder seeder = new UsersSeeder(repository, roleManager, userManager, UserContext);
                        seeder.AdminUserSeeder();
                        seeder.StandardUserSeeder();
                        seeder.SeedFromSqlScript();
                        CommentSeeder commentSeeder = new CommentSeeder(dbContext);
                        commentSeeder.CommentsSeeder();
                    }
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            } 
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

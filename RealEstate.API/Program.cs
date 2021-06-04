using Entities;
using IdentityLibrary;
using IdentityLibrary.Authentication;
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
        //public static void Main(string[] args)
        //{
        //    CreateHostBuilder(args).Build().Run();
        //}
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // migrate the database.  Best practice = in Main, using service scope
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    //var context = scope.ServiceProvider.GetService<RepositoryContext>();
                    //var identityContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
                    //context.Database.EnsureDeleted();
                    //context.Database.Migrate();
                    //identityContext.Database.EnsureDeleted();
                    //identityContext.Database.Migrate();

                    var services = scope.ServiceProvider;
                    var UserContext = services.GetRequiredService<ApplicationDbContext>();
                    RepositoryContext hotelContext = scope.ServiceProvider.GetService<RepositoryContext>();
                    //If database doesent exist, run the seeder from movieservice
                    bool DatabaseDoesNotExist = hotelContext.Database.EnsureCreated();

                    if (!UserContext.Database.EnsureCreated())
                    {
                        UserContext.Database.Migrate();
                        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    }


                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }

            // run the web app
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

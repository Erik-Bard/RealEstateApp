using Entities.Helpers;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using RealEstate.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Advertisment> Advertisments { get; set; }
        
    }
}

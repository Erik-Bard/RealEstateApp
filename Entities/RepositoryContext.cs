using Entities.Models;
using IdentityLibrary.Models;
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
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

            modelBuilder.Entity<Rating>()
                .HasOne(x => x.WrittenByUser)
                .WithMany(x => x.RatingsDoneByMe)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rating>()
                .HasOne(c => c.UserToWriteAbout)
                .WithMany(c => c.MyRatings)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

using Entities;
using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.API.Extensions
{
    public class CommentSeeder : ICommentSeeder
    {
        private readonly RepositoryContext dbContext;

        public CommentSeeder(
            RepositoryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CommentsSeeder()
        {
            var comment1 = new Comment
            {
                Id = new Guid("c30141ec-acfa-4a5f-8869-c1fedcc410be"),
                CreatedOn = DateTime.Now,
                AdvertismentId = new Guid("bb9935ca-5f28-4db1-96a0-4c5a1e3cc692"),
                Content = "Dålig utsikt!!",
                UserId = dbContext.Users.First(x => x.UserName.Contains("Admin-TestUser")).UserId
            };

            var comment2 = new Comment
            {
                Id = new Guid("b2aa2881-9021-4d91-88ff-8f452dccc105"),
                CreatedOn = DateTime.Now,
                AdvertismentId = new Guid("bb628a76-25b3-451d-9998-d2406ef6e4b7"),
                Content = "Väldigt fint läge.",
                UserId = dbContext.Users.First(x => x.UserName.Contains("Hans Svyger")).UserId
            };

            var comment3 = new Comment
            {
                Id = new Guid("acbcb3d5-64e2-420b-93c7-99d3435377f9"),
                CreatedOn = DateTime.Now,
                AdvertismentId = new Guid("eff86b15-4872-4c8d-ac32-bf351fb71a2c"),
                Content = "Bra pris.",
                UserId = dbContext.Users.First(x => x.UserName.Contains("TestUser")).UserId
            };

            dbContext.Comments.AddRange(comment1, comment2, comment3);
            dbContext.SaveChanges();
        }
    }
}

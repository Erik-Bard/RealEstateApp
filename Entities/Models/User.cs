using IdentityLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string SecurityStamp { get; set; }
        public string Password { get; set; }
        public double AverageRating { get; set; }
        public int TotalComments { get; set; }
        public int TotalRealEstates { get; set; }

        public List<Advertisment> RealEstates { get; set; } = new List<Advertisment>();
        public List<Rating> MyRatings { get; set; } = new List<Rating>();
        public List<Rating> RatingsDoneByMe { get; set; } = new List<Rating>();
        public List<Comment> Comments { get; set; }
    }
}

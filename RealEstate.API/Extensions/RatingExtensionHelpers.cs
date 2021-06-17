using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using IdentityLibrary.Authentication;
using IdentityLibrary.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.API.Extensions
{
    public static class RatingExtensionHelpers
    {
        private static IUserManagerRepository _userRepository;

        public static double AverageRating(IEnumerable<Rating> ratings)
        {
            if (ratings.Count() > 0)
            {
                double average = ((GetAllRatedValues(ratings)).Sum()) / ratings.Count();
                return average;
            }
            return 0;
        }

        public static List<double> GetAllRatedValues(IEnumerable<Rating> rating)
        {
            List<double> ratings = new();
            foreach (var item in rating)
            {
                ratings.Add(item.Value);
            }
            return ratings;
        }

        public static bool CheckMultipleRatingsFromUserAsync(User user, UserRatingDto userRatingDto)
        {
            // [Note] True if there is spam detected. False if not spam.
            bool checkSpam = false;
            string userIdAsString = userRatingDto.UserId.ToString();

            if (user.RatingsDoneByMe == null)
            {
                return checkSpam;
            }
            foreach (var rating in user.MyRatings)
            {
                if (rating.WrittenByUserId == userRatingDto.AboutId
                    && rating.UserToWriteAboutId == userIdAsString)
                {
                    checkSpam = true;
                    return checkSpam;
                }
            }
            return checkSpam;
        }
    }
}

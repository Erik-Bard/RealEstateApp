using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class UserRatingDto
    {
        public Guid UserId { get; set; }
        public string Value { get; set; }

        // Navigation Properties. Keep as strings.
        public string GetUserById { get; set; }
        public string AboutId { get; set; }
    }
}

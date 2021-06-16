using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class RatingDto
    {
        public Guid UserId { get; set; }
        public string Value { get; set; }
    }
}

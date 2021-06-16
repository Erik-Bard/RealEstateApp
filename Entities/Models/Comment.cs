using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class Comment
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid AdvertismentId { get; set; }
        public Advertisment Advertisment { get; set; }
        public string Content { get; set; }

    }
}

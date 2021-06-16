using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class CommentCreationDto
    {
        public Guid AdvertismentId { get; set; }
        public string Content { get; set; }
    }
}

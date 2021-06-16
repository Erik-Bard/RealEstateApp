using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Rating
    {
        public Guid Id { get; set; }
        public int Value { get; set; }

        public string WrittenByUserId { get; set; }
        public string UserToWriteAboutId { get; set; }

        [ForeignKey(nameof(WrittenByUserId))]
        public User WrittenByUser { get; set; }

        [ForeignKey(nameof(UserToWriteAboutId))]
        public User UserToWriteAbout { get; set; }
    }
}

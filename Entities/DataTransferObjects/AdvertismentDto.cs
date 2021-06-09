using Entities.EnumHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class AdvertismentDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ConstructionYear { get; set; }
        public string Description { get; set; }
        public PropertyType PropertyType { get; set; }
        public string Title { get; set; }
        public int SellingPrice { get; set; }
        public int RentingPrice { get; set; }
        public bool CanBeSold { get; set; }
        public bool CanBeRented { get; set; }
    }
}

using Entities.EnumHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class AdvertismentCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int SellingPrice { get; set; }
        public int RentingPrice { get; set; }
        public string Contact { get; set; }
        public PropertyType PropertyType { get; set; }
        public AdvertismentType AdvertismentType { get; set; }
        public int PropertyId { get; set; }
    }
}

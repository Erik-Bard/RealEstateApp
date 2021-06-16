using Entities.EnumHelpers;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class AdvertisementPrivateDto
    {
        [Required(ErrorMessage = "A phone number for the contact person is required for this advertisment.")]
        public string Contact { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ConstructionYear { get; set; }
        public string Address { get; set; }
        public PropertyType PropertyType { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int SellingPrice { get; set; }
        public int RentingPrice { get; set; }
        public bool CanBeSold { get; set; }
        public bool CanBeRented { get; set; }
    }
}

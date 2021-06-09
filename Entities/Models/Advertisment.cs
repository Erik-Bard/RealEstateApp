using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.EnumHelpers;
using Entities.Models;

namespace Entities.Models
{
    public class Advertisment
    {
        public Guid Id { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        [Required(ErrorMessage = "Titel is required for this advertisment.")]
        public string Title { get; set; }
        [MinLength(10)]
        [MaxLength(1000)]
        [Required(ErrorMessage = "Description is required for this advertisment.")]
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
        public int SellingPrice { get; set; }
        public int RentingPrice { get; set; }
        [Required(ErrorMessage = "A phone number for the contact person is required for this advertisment.")]
        public string Contact { get; set; }
        [Required(ErrorMessage = ("Please enter a valid property type for this advertisment."))]
        public PropertyType PropertyType { get; set; }
        [Required(ErrorMessage = ("Please enter a valid advertisment type for this advertisment."))]
        public bool CanBeSold { get; set; }
        public bool CanBeRented { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}

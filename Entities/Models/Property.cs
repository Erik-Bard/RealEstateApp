using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities.Models
{
    public class Property
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "A year of construction is required for this property.")]
        [Range(1650, 2050)]
        public int YearOfConstruction { get; set; }
        [Required(ErrorMessage = "An address is required for this property.")]
        public string Address { get; set; }
        public Advertisment Advertisment { get; set; }       
    }
}

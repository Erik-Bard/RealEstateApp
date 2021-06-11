using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class PropertyCreationDto
    {
        [Required(ErrorMessage = "A construction year is required for this field.")]
        public int YearOfConstruction { get; set; }
        [Required(ErrorMessage = "An address is required for this field.")]
        public string Address { get; set; }
    }
}

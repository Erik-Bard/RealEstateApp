using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Helpers
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
        public string Description { get; set; }
    }
}

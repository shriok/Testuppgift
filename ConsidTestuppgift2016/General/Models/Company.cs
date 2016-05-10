using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models
{
    public class Company
    {
        [Required]
        public Guid id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30,ErrorMessage = "Name may not be longer then 30 chars")]
        public string name { get; set; }
        [Required(ErrorMessage = "organizationnumber is required")]
        [StringLength(9, ErrorMessage = "organizationnumber may not be longer then 9 didgits")]
        public string organizationNumber { get; set; }
        public string notes { get; set; }
    }
}

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
        [Required]
        [StringLength(30)]
        public string name { get; set; }
        [Required]
        [StringLength(10)]
        public string organizationNumber { get; set; }
        public string notes { get; set; }
    }
}

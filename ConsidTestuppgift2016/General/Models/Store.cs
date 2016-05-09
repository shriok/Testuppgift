using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models
{
    public class Store
    {

        public Guid id { get; set; }

        public Guid companyId { get; set; }
        [Required]
        [StringLength(30)]
        public string name { get; set; }
        [Required]
        [StringLength(30)]
        public string address { get; set; }
        [Required]
        [StringLength(30)]
        public string city { get; set; }
        [Required]
        [StringLength(10)]
        public string zip { get; set; }
        [Required]
        [StringLength(30)]
        public string country { get; set; }

        public string longitude { get; set; }
        public string latitude { get; set; }
        public Guid selectedCompany { get; set; }
    }
}

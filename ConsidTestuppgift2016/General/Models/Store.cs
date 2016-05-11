using System;
using System.ComponentModel.DataAnnotations;

namespace General.Models
{
    public class Store
    {

        public Guid id { get; set; }
        public Guid companyId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name may not be longer then 30 letters")]
        public string name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(30, ErrorMessage = "Address may not be longer then 30 letters")]
        public string address { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(30, ErrorMessage = "City may not be longer then 30 letters")]
        public string city { get; set; }
        [Required(ErrorMessage = "Zip code is required")]
        [StringLength(10, ErrorMessage = "Zip code may not be longer then 10 letters")]
        public string zip { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [StringLength(30, ErrorMessage = "Country may not be longer then 30 letters")]
        public string country { get; set; }

        public string longitude { get; set; }
        public string latitude { get; set; }
        public Guid selectedCompany { get; set; }
    }
}

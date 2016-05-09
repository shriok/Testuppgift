using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models
{
    public class Store
    {
        public Guid id { get; set; }
        public Guid companyId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }
}

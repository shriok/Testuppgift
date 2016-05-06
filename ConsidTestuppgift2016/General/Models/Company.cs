using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models
{
    public class Company
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public int organizationNumber { get; set; }
        public string notes { get; set; }

        public List<StoreViewModel> lStore { get; set; }
    }
}

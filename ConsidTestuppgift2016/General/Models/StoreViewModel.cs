using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models
{
    public class StoreViewModel
    {
        public List<Company> lCompany { get; set; }
        public Store store { get; set; }
        public Company selectetCompany { get; set; }
    }
}

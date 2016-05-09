using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models
{
    public class StoreViewModel
    {
        public StoreViewModel(List<Store> ls)
        {
            lStore = ls;
        }
        List<Store> lStore { get; set; }
    }
}

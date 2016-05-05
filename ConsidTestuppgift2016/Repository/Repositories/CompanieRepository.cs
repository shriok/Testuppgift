using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CompanieRepository
    {
        public static List<Repository.Companies> List()
        {
            List <Repository.Companies> comp = new List<Repository.Companies>();
            using (var db = new CompaniesDBEntities())
            {
                comp.AddRange(db.Companies.ToList());
            }
            return comp;
        }
    }
}

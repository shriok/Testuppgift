using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CompanyRepository
    {
        public static List<Repository.Companies> List()
        {
            List<Repository.Companies> comp = new List<Repository.Companies>();
            using (var db = new CompaniesDBEntities())
            {
                comp.AddRange(db.Companies.ToList());
            }
            return comp;
        }

        public static void Delete(Guid companyId)
        {
            try
            {           
                using (var db = new CompaniesDBEntities())
                {
                    Repository.Companies compToDelete = new Repository.Companies {Id = companyId };
                    db.Companies.Attach(compToDelete);
                    db.Companies.Remove(compToDelete);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}

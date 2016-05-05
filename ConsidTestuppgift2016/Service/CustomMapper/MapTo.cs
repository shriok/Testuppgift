using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Models;

namespace Service.CustomMapper
{
    public class MapTo
    {
        public static Company Company(Repository.Companies c)
        {
            Company comp = new Company
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                Notes = c.Notes,
                OrganizationNumber = c.OrganizationNumber
            };
            return comp;
        }

        public static List<Company> companies (List<Repository.Companies> compToMap)
        {
            List<Company> LComp = new List<Company>();

            foreach (Repository.Companies c in compToMap)
            {
                LComp.Add(Company(c));
            }
            return LComp;
        }
    }
}

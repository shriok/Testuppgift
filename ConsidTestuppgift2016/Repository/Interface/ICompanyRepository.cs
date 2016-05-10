using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ICompanyRepository
    {
        /// <summary>
        /// Gets ALL rows in table Companies
        /// </summary>
        /// <returns>Returns a list of ALL Repository.Companies</returns>
        List<Repository.Companies> List();

        /// <summary>
        /// Gets Repository.company with Id = CompanyID (Guid)
        /// </summary>
        /// <param name="companyId">Id of Repository.Company to get (Guid)</param>
        /// <returns>Returns Repository.Company with id = CompanyID (Guid)</returns>
        Repository.Companies Get(Guid companyId);

        /// <summary>
        /// Deletes Company with id = companyId
        /// </summary>
        /// <param name="companyId">Id of the Company to delete (Guid)</param>
        void Delete(Guid companyId);

        /// <summary>
        /// Adds a new Company to database
        /// </summary>
        /// <param name="newComp">Company object to add</param>
        void Add(Repository.Companies newComp);

        /// <summary>
        /// Updates Company with id = newComp.Id
        /// </summary>
        /// <param name="updatedComp">Company to update</param>
        void Update(Repository.Companies updatedComp);
    }
}

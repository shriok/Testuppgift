using General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICompanyServices
    {
        /// <summary>
        /// Returns a List of All Companys
        /// </summary>
        /// <returns>Returns a List of All Companys</returns>
        List<Company> List();

        /// <summary>
        /// Returns Company with id = companyId
        /// </summary>
        /// <param name="companyId">Id of company to Get (Guid)</param>
        /// <returns>Returns Company with id = companyId</returns>
        Company Get(Guid companyId);

        /// <summary>
        /// Deletes the Company and connected stories
        /// </summary>
        /// <param name="companyId">Id of Company to delete (Guid)</param>
        void Delete(Guid companyId);

        /// <summary>
        /// Adds a new company to database
        /// </summary>
        /// <param name="company">Company to add</param>
        bool Add(Company company);

        /// <summary>
        /// Uppdates a company
        /// </summary>
        /// <param name="company">The updated Company</param>
        bool Update(Company company);
    }
}

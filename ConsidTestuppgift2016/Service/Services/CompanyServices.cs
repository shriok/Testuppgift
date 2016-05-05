using General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CompanyServices
    {
        /// <summary>
        /// Returns a List of All Companys
        /// </summary>
        /// <returns>Returns a List of All Companys</returns>
        public static List<Company> List()
        {
            List<Company> LComp = new List<Company>();
            LComp.AddRange(CustomMapper.MapTo.Companies(Repository.Repositories.CompanyRepository.List()));
            return LComp;
        }

        /// <summary>
        /// Returns Company with id = companyId
        /// </summary>
        /// <param name="companyId">Id of company to Get (Guid)</param>
        /// <returns>Returns Company with id = companyId</returns>
        public static Company Get(Guid companyId)
        {
            try
            {
                Company company = CustomMapper.MapTo.Company(Repository.Repositories.CompanyRepository.Get(companyId));
                return company;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Deletes the Company and connected stories
        /// </summary>
        /// <param name="companyId">Id of Company to delete (Guid)</param>
        public static void Delete(Guid companyId)
        {
            try
            {
                Repository.Repositories.CompanyRepository.Delete(companyId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Adds a new company to database
        /// </summary>
        /// <param name="company">Company to add</param>
        public static void Add(Company company)
        {
            try
            {
                Repository.Repositories.CompanyRepository.Add(CustomMapper.MapTo.Company(company));
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        /// <summary>
        /// Uppdates a company
        /// </summary>
        /// <param name="company">The updated Company</param>
        public static void Update(Company company)
        {
            try
            {
                Repository.Repositories.CompanyRepository.Update(CustomMapper.MapTo.Company(company));
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}

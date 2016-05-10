using General.Models;
using Repository.Repositories;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace Service.Services
{
    public class CompanyServices: ICompanyServices
    {
        private IValidationDictionary _validatonDictionary;
        private ICompanyRepository _companyRepository;

        public CompanyServices(IValidationDictionary validationDictionary , ICompanyRepository companyRepository)
        {
            _validatonDictionary = validationDictionary;
            _companyRepository = companyRepository;
        }

        public bool ValidateCompany(Company companyToValidate)
        {
            int n;

            if (companyToValidate.name == null || companyToValidate.name.Trim().Length == 0)                
            {
                _validatonDictionary.AddError("Name", "Name is required.");
            }

            if (companyToValidate.organizationNumber == null || companyToValidate.organizationNumber.Trim().Length == 0)
            {
                _validatonDictionary.AddError("organizationNumber", "organizationNumber is required.");
            }
                
            if (companyToValidate.organizationNumber != null && companyToValidate.organizationNumber.Trim().Length > 9)
            {
                _validatonDictionary.AddError("organizationNumber", "organizationNumber may not be longer the 9 digits");
            }

            if (companyToValidate.organizationNumber != null && int.TryParse(companyToValidate.organizationNumber, out n))
            {
                _validatonDictionary.AddError("organizationNumber", "May only contain digits");
            }

            return _validatonDictionary.IsValid;
        }

        /// <summary>
        /// Returns a List of All Companys
        /// </summary>
        /// <returns>Returns a List of All Companys</returns>
        public List<Company> List()
        {
            List<Company> LComp = new List<Company>();
            LComp.AddRange(CustomMapper.MapTo.Companies(_companyRepository.List()));
            return LComp;
        }

        /// <summary>
        /// Returns Company with id = companyId
        /// </summary>
        /// <param name="companyId">Id of company to Get (Guid)</param>
        /// <returns>Returns Company with id = companyId</returns>
        public Company Get(Guid companyId)
        {
            try
            {
                Company company = CustomMapper.MapTo.Company(_companyRepository.Get(companyId));
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
        public void Delete(Guid companyId)
        {
            try
            {
                _companyRepository.Delete(companyId);
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
        public bool Add(Company company)
        {
            if (!ValidateCompany(company))
            {
                return false;
            }
            try
            {
                _companyRepository.Add(CustomMapper.MapTo.Company(company));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Uppdates a company
        /// </summary>
        /// <param name="company">The updated Company</param>
        public bool Update(Company company)
        {
            if (!ValidateCompany(company))
            {
                return false;
            }
            try
            {
                _companyRepository.Update(CustomMapper.MapTo.Company(company));
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }
    }
}

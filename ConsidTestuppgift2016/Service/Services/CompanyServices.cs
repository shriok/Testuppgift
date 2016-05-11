using General.Models;
using Repository.Interface;
using Repository.Repositories;
using Service.Interface;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class CompanyServices: ICompanyServices
    {
        private ICompanyRepository _companyRepository;

        public CompanyServices()
        {
            _companyRepository = new CompanyRepository();
        }
        
        /// <summary>
        /// Returns a List of All Companys
        /// </summary>
        /// <returns>Returns a List of All Companys</returns>
        public List<Company> List()
        {
            try
            {
                List<Company> LComp = new List<Company>();
                LComp.AddRange(CustomMapper.MapTo.Companies(_companyRepository.List()));
                return LComp;
            }
            catch (Exception)
            {

                throw;
            }            
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds a new company to database
        /// </summary>
        /// <param name="company">Company to add</param>
        public void Add(Company company)
        {
            try
            {
                _companyRepository.Add(CustomMapper.MapTo.Company(company));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Uppdates a company
        /// </summary>
        /// <param name="company">The updated Company</param>
        public void Update(Company company)
        {            
            try
            {
                _companyRepository.Update(CustomMapper.MapTo.Company(company));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

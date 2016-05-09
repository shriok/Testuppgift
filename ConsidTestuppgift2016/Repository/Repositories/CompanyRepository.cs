﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CompanyRepository
    {
        /// <summary>
        /// Gets ALL rows in table Companies
        /// </summary>
        /// <returns>Returns a list of ALL Repository.Companies</returns>
        public static List<Repository.Companies> List()
        {
            List<Repository.Companies> LCompany = new List<Repository.Companies>();
            using (var db = new CompaniesDBEntities())
            {
                LCompany.AddRange(db.Companies.ToList());
            }
            return LCompany;
        }

        /// <summary>
        /// Gets Repository.company with Id = CompanyID (Guid)
        /// </summary>
        /// <param name="companyId">Id of Repository.Company to get (Guid)</param>
        /// <returns>Returns Repository.Company with id = CompanyID (Guid)</returns>
        public static Repository.Companies Get(Guid companyId)
        {
            try
            {
                Repository.Companies company = new Repository.Companies();
                using (var db = new CompaniesDBEntities())
                {
                    company = db.Companies.Find(companyId);
                }
                return company;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Deletes Company with id = companyId
        /// </summary>
        /// <param name="companyId">Id of the Company to delete (Guid)</param>
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

        /// <summary>
        /// Adds a new Company to database
        /// </summary>
        /// <param name="newComp">Company object to add</param>
        public static void Add(Repository.Companies newComp)
        {
            try
            {
                using (var db = new CompaniesDBEntities())
                {
                    db.Companies.Add(newComp);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Updates Company with id = newComp.Id
        /// </summary>
        /// <param name="updatedComp">Company to update</param>
        public static void Update(Repository.Companies updatedComp)
        {
            try
            {
                using (var db = new CompaniesDBEntities())
                {
                    Companies compToUpdate = db.Companies.Where(x => x.Id == updatedComp.Id).First();
                    compToUpdate.Name = updatedComp.Name;
                    compToUpdate.Notes = updatedComp.Notes;
                    compToUpdate.OrganizationNumber = updatedComp.OrganizationNumber;
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

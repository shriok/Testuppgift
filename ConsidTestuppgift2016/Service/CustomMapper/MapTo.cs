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
        /// <summary>
        /// Maps a repository company entity object to a General.Model company object
        /// </summary>
        /// <param name="repCompany">repository company entity object</param>
        /// <returns>General.Model Company object</returns>
        public static Company Company(Repository.Companies repCompany)
        {
            try
            {
                Company comp = new Company
                {
                    Id = repCompany.Id,
                    Name = repCompany.Name,
                    Notes = repCompany.Notes,
                    OrganizationNumber = repCompany.OrganizationNumber
                };
                return comp;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Maps a General.Model company object to a repository company entity object
        /// </summary>
        /// <param name="modelCompany">General.Model Company</param>
        /// <returns>repository company entity object</returns>
        public static Repository.Companies Company(Company modelCompany)
        {
            try
            {
                Repository.Companies comp = new Repository.Companies
                {
                    Id = modelCompany.Id,
                    Name = modelCompany.Name,
                    Notes = modelCompany.Notes,
                    OrganizationNumber = modelCompany.OrganizationNumber
                };
                return comp;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Maps a List of repository company entity object to a list of general.model company objects
        /// </summary>
        /// <param name="compToMap">List of repository company entity object</param>
        /// <returns>List of General.Model company object</returns>
        public static List<Company> Companies(List<Repository.Companies> compToMap)
        {
            try
            {
                List<Company> LComp = new List<Company>();

                foreach (Repository.Companies c in compToMap)
                {
                    LComp.Add(Company(c));
                }
                return LComp;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Maps a List of repository stores entity objects to a list of general.model storeviewmodel objects
        /// </summary>
        /// <param name="LResosStore">List of repository stores entity objects</param>
        /// <returns>List of general.model storeviewmodel objects</returns>
        public static List<StoreViewModel> Stores(List<Repository.Stores> LResosStore)
        {
            try
            {
                List<StoreViewModel> LStore = new List<StoreViewModel>();
                foreach (Repository.Stores reposStore in LResosStore)
                {
                    LStore.Add(Store(reposStore));
                }
                return LStore;
            }
            catch (Exception e)
            {
                throw e;
            }           
        }

        /// <summary>
        /// Mapps a StoreViewModel object to a repository store entity object
        /// </summary>
        /// <param name="store">StoreViewModel object</param>
        /// <returns>repository store entity object</returns>
        public static Repository.Stores Store(StoreViewModel store)
        {
            try
            {
                Repository.Stores reposStore = new Repository.Stores();
                reposStore.Id = store.Id;
                reposStore.CompanyId = store.CompanyId;
                reposStore.Name = store.Name;
                reposStore.Address = store.Address;
                reposStore.City = store.City;
                reposStore.Zip = store.Zip;
                reposStore.Country = store.Country;
                reposStore.Longitude = store.Longitude;
                reposStore.Latitude = store.Latitude;
                return reposStore;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Mapps a repository store entity object to a StoreViewModel object
        /// </summary>
        /// <param name="reposStore">repository store entity object</param>
        /// <returns>StoreViewModel object</returns>
        public static StoreViewModel Store(Repository.Stores reposStore)
        {
            try
            {
                StoreViewModel store = new StoreViewModel();
                store.Id = reposStore.Id;
                store.CompanyId = reposStore.CompanyId;
                store.Name = reposStore.Name;
                store.Address = reposStore.Address;
                store.City = reposStore.City;
                store.Zip = reposStore.Zip;
                store.Country = reposStore.Country;
                store.Longitude = reposStore.Longitude;
                store.Latitude = reposStore.Latitude;
                return store;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}

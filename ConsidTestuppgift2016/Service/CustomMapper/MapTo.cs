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
                    id = repCompany.Id,
                    name = repCompany.Name,
                    notes = repCompany.Notes,
                    organizationNumber = repCompany.OrganizationNumber.ToString()
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
                    Id = modelCompany.id,
                    Name = modelCompany.name,
                    Notes = modelCompany.notes,
                    OrganizationNumber = Convert.ToInt32(modelCompany.organizationNumber)
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
        public static List<Store> Stores(List<Repository.Stores> LResosStore)
        {
            try
            {
                List<Store> LStore = new List<Store>();
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
        public static Repository.Stores Store(Store store)
        {
            try
            {
                Repository.Stores reposStore = new Repository.Stores();
                reposStore.Id = store.id;
                reposStore.CompanyId = store.companyId;
                reposStore.Name = store.name;
                reposStore.Address = store.address;
                reposStore.City = store.city;
                reposStore.Zip = store.zip;
                reposStore.Country = store.country;
                reposStore.Longitude = store.longitude;
                reposStore.Latitude = store.latitude;
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
        public static Store Store(Repository.Stores reposStore)
        {
            try
            {
                Store store = new Store();
                store.id = reposStore.Id;
                store.companyId = reposStore.CompanyId;
                store.name = reposStore.Name;
                store.address = reposStore.Address;
                store.city = reposStore.City;
                store.zip = reposStore.Zip;
                store.country = reposStore.Country;
                store.longitude = reposStore.Longitude;
                store.latitude = reposStore.Latitude;
                return store;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}

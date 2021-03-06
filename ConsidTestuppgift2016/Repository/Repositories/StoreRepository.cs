﻿using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class StoreRepository: IStoreRepository
    {

        private IGoogleMapsRepository _iGoogleMapsRepository;

        public StoreRepository()
        {
            _iGoogleMapsRepository = new GoogleMapsRepository(this);
        }

        /// <summary>
        /// Returns a list of all stores with foreingKeyId companyId
        /// </summary>
        /// <param name="companyId">id of the company whos stores to return</param>
        /// <returns>A List of Repository.Stores</returns>
        public List<Repository.Stores> List(Guid companyId)
        {
            try
            {            
                List<Repository.Stores> LStore = new List<Stores>();
                using (var db = new CompaniesDBEntities())
                {
                    LStore.AddRange(db.Stores.Where(x => x.CompanyId == companyId).ToList());
                }
                return LStore;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns Repository.Stores entity object
        /// </summary>
        /// <param name="companyId">CompanyId of Repository.Stores entity object to return</param>
        /// <returns>Returns Repository.Stores entity object</returns>
        public Repository.Stores Get(Guid storeId)
        {
            try
            {
                Repository.Stores store = new Repository.Stores();
                using (var db = new CompaniesDBEntities())
                {
                    store = db.Stores.Where(x => x.Id == storeId).First();
                }
                    return store;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Adds a new Store to database
        /// </summary>
        /// <param name="NewStore">Store object to add</param>
        public void Add(Stores NewStore)
        {
            try
            {
                using (var db = new CompaniesDBEntities())
                {
                    db.Stores.Add(NewStore);
                    db.SaveChanges();
                }
                Task.Run(() => {
                    _iGoogleMapsRepository.Post(NewStore);
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Deletes Store with id storeId
        /// </summary>
        /// <param name="storeId">Id of the store to deltet (Guid)</param>
        public void Delete(Guid storeId)
        {
            try
            {
                using (var db = new CompaniesDBEntities())
                {
                    Repository.Stores storeToDelete = db.Stores.Find(storeId);
                    db.Stores.Attach(storeToDelete);
                    db.Stores.Remove(storeToDelete);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates Store with id = updatedStore.Id 
        /// </summary>
        /// <param name="updatedStore">Store to update</param>
        public void Update(Stores updatedStore)
        {
            try
            {
                Repository.Stores storeToUpdate;
                using (var db = new CompaniesDBEntities())
                {
                    storeToUpdate = db.Stores.Find(updatedStore.Id);
                    storeToUpdate.CompanyId = updatedStore.CompanyId;
                    storeToUpdate.Name = updatedStore.Name;
                    storeToUpdate.Address = updatedStore.Address;
                    storeToUpdate.City = updatedStore.City;
                    storeToUpdate.Zip = updatedStore.Zip;
                    storeToUpdate.Country = updatedStore.Country;
                    storeToUpdate.Longitude = updatedStore.Longitude;
                    storeToUpdate.Latitude = updatedStore.Latitude;
                    db.SaveChanges();
                                       
                }
                Task.Run(() => {
                    _iGoogleMapsRepository.Post(storeToUpdate);
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

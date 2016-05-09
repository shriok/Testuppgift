using General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StoreServices
    {
        /// <summary>
        /// Adds a new Store to database
        /// </summary>
        /// <param name="store">New storeViewModel to add</param>
        public static void Add(Store store)
        {
            try
            {
                Repository.Repositories.StoreRepository.Add(CustomMapper.MapTo.Store(store));
            }
            catch (Exception e)
            {
                throw e;
            }               
        }

        /// <summary>
        /// Returns store with id = storeId
        /// </summary>
        /// <param name="storeId">id of store to return</param>
        /// <returns>Returns store with id = storeId</returns>
        public static Store Get(Guid companyId)
        {
            try
            {
                Store store = CustomMapper.MapTo.Store(Repository.Repositories.StoreRepository.Get(companyId));
                return store;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Updates a view model with id store.id
        /// </summary>
        /// <param name="store">The updated Store</param>
        public static void update(Store store)
        {
            try
            {
                Repository.Repositories.StoreRepository.Update(CustomMapper.MapTo.Store(store));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Deletes store with Id storeId (Guid)
        /// </summary>
        /// <param name="storeId">Id of store to delete (Guid)</param>
        public static void Delete(Guid storeId)
        {
            try
            {
                Repository.Repositories.StoreRepository.Delete(storeId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static List<Store> List(Guid companyId)
        {
            try
            {
                List<Store> LStore = CustomMapper.MapTo.Stores(Repository.Repositories.StoreRepository.List(companyId));
                return LStore;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}

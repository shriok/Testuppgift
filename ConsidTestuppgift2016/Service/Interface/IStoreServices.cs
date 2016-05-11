using General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IStoreServices
    {
        /// <summary>
        /// Adds a new Store to database 
        /// and Async gets location from GoogleMaps API
        /// </summary>
        /// <param name="store">New storeViewModel to add</param>
        void Add(Store store);

        /// <summary>
        /// Returns store with id = storeId
        /// </summary>
        /// <param name="storeId">id of store to return</param>
        /// <returns>Returns store with id = storeId</returns>
        Store Get(Guid companyId);

        /// <summary>
        /// Updates a view model with id store.id
        /// and Async gets location from GoogleMaps API
        /// </summary>
        /// <param name="store">The updated Store</param>
        void update(Store store);

        /// <summary>
        /// Deletes store with Id storeId (Guid)
        /// </summary>
        /// <param name="storeId">Id of store to delete (Guid)</param>
        void Delete(Guid storeId);

        /// <summary>
        /// returns a list of a companys stores
        /// </summary>
        /// <param name="companyId">Id of Company (Guid)</param>
        /// <returns>returns a list of a companys stores</returns>
        List<Store> List(Guid companyId);
    }
}

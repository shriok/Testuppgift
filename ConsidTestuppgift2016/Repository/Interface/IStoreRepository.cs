using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IStoreRepository
    {
        /// <summary>
        /// Returns a list of all stores with foreingKeyId companyId
        /// </summary>
        /// <param name="companyId">id of the company whos stores to return</param>
        /// <returns>A List of Repository.Stores</returns>
        List<Repository.Stores> List(Guid companyId);

        /// <summary>
        /// Returns Repository.Stores entity object
        /// </summary>
        /// <param name="companyId">CompanyId of Repository.Stores entity object to return</param>
        /// <returns>Returns Repository.Stores entity object</returns>
        Repository.Stores Get(Guid storeId);
        
        /// <summary>
        /// Adds a new Store to database
        /// </summary>
        /// <param name="NewStore">Store object to add</param>
        void Add(Stores NewStore);

        /// <summary>
        /// Deletes Store with id storeId
        /// </summary>
        /// <param name="storeId">Id of the store to deltet (Guid)</param>
        void Delete(Guid storeId);

        /// <summary>
        /// Updates Store with id = updatedStore.Id 
        /// </summary>
        /// <param name="updatedStore">Store to update</param>
        void Update(Stores updatedStore);
    }
}

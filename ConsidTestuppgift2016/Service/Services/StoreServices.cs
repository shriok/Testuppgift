using General.Models;
using Repository.Interface;
using Repository.Repositories;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StoreServices: IStoreServices
    {
        private IValidationDictionary _validatonDictionary;
        private IStoreRepository _iStoreRepository;

        public StoreServices(IValidationDictionary validationDictionary, IStoreRepository iStoreRepository)
        {
            _validatonDictionary = validationDictionary;
            _iStoreRepository = iStoreRepository;
        }

        public bool ValidateStore(Store storeToValidate)
        {
            if (storeToValidate.name == null || storeToValidate.name.Trim().Length == 0)
            {
                _validatonDictionary.AddError("Name", "Name is required.");
            }

           

            return _validatonDictionary.IsValid;
        }

        /// <summary>
        /// Adds a new Store to database
        /// </summary>
        /// <param name="store">New storeViewModel to add</param>
        public void Add(Store store)
        {
            try
            {
                _iStoreRepository.Add(CustomMapper.MapTo.Store(store));
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
        public Store Get(Guid companyId)
        {
            try
            {
                Store store = CustomMapper.MapTo.Store(_iStoreRepository.Get(companyId));
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
        public void update(Store store)
        {
            try
            {
                _iStoreRepository.Update(CustomMapper.MapTo.Store(store));
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
        public void Delete(Guid storeId)
        {
            try
            {
                _iStoreRepository.Delete(storeId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Store> List(Guid companyId)
        {
            try
            {
                List<Store> LStore = CustomMapper.MapTo.Stores(_iStoreRepository.List(companyId));
                return LStore;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}

using General.Models;
using Service.Interface;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsidTestuppgift2016.Controllers
{
    public class StoreController : Controller
    {
        private System.Web.ModelBinding.ModelStateDictionary _modelState;
        private IStoreServices _iStoreServices;
        private ICompanyServices _iCompanyServices;
        

        public StoreController()
        {
            _modelState = new System.Web.ModelBinding.ModelStateDictionary();
            //_iStoreServices = new StoreServices(new ModelStateWrapper(_modelState), new Repository.Repositories.IStoreRepository());
            _iCompanyServices = new CompanyServices(new ModelStateWrapper(_modelState), new Repository.Repositories.ICompanyRepository());
        }

        public StoreController(IStoreServices iStoreServices, ICompanyServices iCompanyServices)
        {
            _iStoreServices = iStoreServices;
            _iCompanyServices = iCompanyServices;
        }

        public ActionResult Home()
        {
            string companyId = RouteData.Values["id"].ToString();
            StoreHomeViewModel stores = new StoreHomeViewModel();
            stores.company = _iCompanyServices.Get(new Guid(companyId));
            stores.lStore = _iStoreServices.List(new Guid(companyId));
            return View(stores);
        }

        // GET: Store/AddStore
        public ActionResult AddStore()
        {
            StoreViewModel store = new StoreViewModel();
            store.lCompany = _iCompanyServices.List();
            return View(store);
        }        

        // POST: Store/AddStore
        [HttpPost]
        public ActionResult AddStore(Store store)
        {
            try
            {
                store.id = Guid.NewGuid();
                _iStoreServices.Add(store);
                return RedirectToAction("Home", "Company");
            }
            catch (Exception)
            {
                return RedirectToAction("Home", "Company");
            }
            
        }

        // GET: Store/EditStore
        public ActionResult EditStore()
        {
            try
            {
                string storeId = RouteData.Values["id"].ToString();
                StoreViewModel store = new StoreViewModel();
                store.store = _iStoreServices.Get(new Guid(storeId));
                store.lCompany = _iCompanyServices.List();
                store.selectetCompany = _iCompanyServices.Get(store.store.companyId);
                return View(store);
            }
            catch (Exception)
            {
                return RedirectToAction("Home", "Company");
            }            
        }

        // POST: Store/EditStore
        [HttpPost]
        public ActionResult EditStore(Store store)
        {
            try
            {
                _iStoreServices.update(store);
                return RedirectToAction("Home/" + store.companyId);
            }
            catch (Exception)
            {
                return RedirectToAction("Home" + store.companyId);
            }
            
        }

        // DELETE: Store/DeleteStore
        public ActionResult DeleteStore(Store store)
        {
            _iStoreServices.Delete(store.id);
            return RedirectToAction("Home/"+ store.companyId);
        }
    }
}
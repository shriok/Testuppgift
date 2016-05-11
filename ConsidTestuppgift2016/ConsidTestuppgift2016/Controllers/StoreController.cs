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
        private IStoreServices _iStoreServices;
        private ICompanyServices _iCompanyServices;
        

        public StoreController()
        {
            _iStoreServices = new StoreServices();
            _iCompanyServices = new CompanyServices();
        }

        // Get: /Store/Home
        // Shows a list of a Companys Stories
        public ActionResult Home()
        {
            try
            {
                string companyId = RouteData.Values["id"].ToString();
                StoreHomeViewModel stores = new StoreHomeViewModel();
                stores.company = _iCompanyServices.Get(new Guid(companyId));
                stores.lStore = _iStoreServices.List(new Guid(companyId));
                return View(stores);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // GET: Store/AddStore
        // Allows user to edit a Store
        public ActionResult AddStore()
        {
            try
            {
                StoreViewModel store = new StoreViewModel();
                store.lCompany = _iCompanyServices.List();
                return View(store);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }        

        // POST: Store/AddStore
        // Adds a new store
        [HttpPost]
        public ActionResult AddStore(Store store)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    StoreViewModel storeViewModel = new StoreViewModel();
                    storeViewModel.store = store;
                    storeViewModel.lCompany = _iCompanyServices.List();
                    return View(storeViewModel);
                }

                store.id = Guid.NewGuid();
                _iStoreServices.Add(store);
                return RedirectToAction("Home/" + store.companyId);
            }
            catch (Exception)
            {
                return View("Error");
            }
            
        }

        // GET: Store/EditStore
        // Allows user to edit a store
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
                return View("Error");
            }            
        }

        // POST: Store/EditStore
        // Updates the edited store
        [HttpPost]
        public ActionResult EditStore(Store store)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    StoreViewModel storeViewModel = new StoreViewModel();
                    storeViewModel.store = store;
                    storeViewModel.lCompany = _iCompanyServices.List();
                    storeViewModel.selectetCompany = _iCompanyServices.Get(storeViewModel.store.companyId);
                    return View(storeViewModel);
                }
                _iStoreServices.update(store);
                return RedirectToAction("Home/" + store.companyId);
            }
            catch (Exception)
            {
                return View("Error");
            }
            
        }

        // DELETE: Store/DeleteStore
        // Deletes the selected store
        public ActionResult DeleteStore(Store store)
        {
            try
            {
                _iStoreServices.Delete(store.id);
                return RedirectToAction("Home/" + store.companyId);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
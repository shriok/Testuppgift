using General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsidTestuppgift2016.Controllers
{
    public class StoreController : Controller
    {
        

        public ActionResult Home()
        {
            string companyId = RouteData.Values["id"].ToString();
            StoreHomeViewModel stores = new StoreHomeViewModel();
            stores.company = Service.Services.CompanyServices.Get(new Guid(companyId));
            stores.lStore = Service.Services.StoreServices.List(new Guid(companyId));
            return View(stores);
        }

        // GET: Store/AddStore
        public ActionResult AddStore()
        {
            StoreViewModel store = new StoreViewModel();
            store.lCompany = Service.Services.CompanyServices.List();
            return View(store);
        }        

        // POST: Store/AddStore
        [HttpPost]
        public ActionResult AddStore(Store store)
        {
            try
            {
                store.id = Guid.NewGuid();
                Service.Services.StoreServices.Add(store);
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
                store.store = Service.Services.StoreServices.Get(new Guid(storeId));
                store.lCompany = Service.Services.CompanyServices.List();
                store.selectetCompany = Service.Services.CompanyServices.Get(store.store.companyId);
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
                Service.Services.StoreServices.update(store);
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
            Service.Services.StoreServices.Delete(store.id);
            return RedirectToAction("Home/"+ store.companyId);
        }
    }
}
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
        // GET: Store/AddStore
        public ActionResult AddStore()
        {
            return View(new Store());
        }

        public ActionResult Home()
        {
            string companyId = RouteData.Values["id"].ToString();
            StoreViewModel stores = new StoreViewModel(Service.Services.StoreServices.List(new Guid(companyId)));
            return View();
        }

        // POST: Store/AddStore
        [HttpPost]
        public ActionResult AddStore(Store store)
        {
            try
            {
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
                Store store = Service.Services.StoreServices.Get(new Guid(storeId));
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
                return RedirectToAction("Home", "Company");
            }
            catch (Exception)
            {
                return RedirectToAction("Home", "Company");
            }
            
        }

        // DELETE: Store/DeleteStore
        [HttpDelete]
        public ActionResult DeleteStore()
        {
            return RedirectToAction("Home", "Company");
        }
    }
}
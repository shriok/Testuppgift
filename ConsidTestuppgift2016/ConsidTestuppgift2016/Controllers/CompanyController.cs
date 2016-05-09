using General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsidTestuppgift2016.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company/Home
        //TODO
        public ActionResult Home()
        {            
            CompanyHomeViewModel companyHomeViewModel = new CompanyHomeViewModel();
            companyHomeViewModel.lCompany = Service.Services.CompanyServices.List().OrderBy(o=>o.name).ToList();            
            return View(companyHomeViewModel);            
        }

        // DELETE: Company/DeleteCompany
        public ActionResult DeleteCompany()
        {            
            try
            {
                string companyId = RouteData.Values["id"].ToString();
                Service.Services.CompanyServices.Delete(new Guid(companyId));
            }
            catch (Exception)
            {
                ViewBag.result = "Error Could not delete Company";
            }
            return RedirectToAction("Home");
        }

        // GET: Company/EditCompany
        public ActionResult EditCompany()
        {
            try
            {
                Company company = Service.Services.CompanyServices.Get(Guid.Parse(RouteData.Values["id"].ToString()));
                return View(company);
            }
            catch (Exception)
            {
                return RedirectToAction("Home");
            }
            
        }

        // POST: Company/EditCompany
        [HttpPost]
        public ActionResult EditCompany(Company updatedComp)
        {
            try
            {
                Service.Services.CompanyServices.Update(updatedComp);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Home");
        }

        // GET: Company/AddCompany
        public ActionResult AddCompany()
        {
            return View(new Company());
        }

        // POST: Company/AddCompany
        [HttpPost]
        public ActionResult AddCompany(Company company)
        {
            try
            {
                if (string.IsNullOrEmpty(company.name))
                {
                    ModelState.AddModelError("Name is Required", "");
                }
                if (string.IsNullOrEmpty(company.organizationNumber))
                {
                    ModelState.AddModelError("", "Name is Required");
                }
                if (ModelState.IsValid)
                {
                    company.id = Guid.NewGuid();
                    Service.Services.CompanyServices.Add(company);
                    return RedirectToAction("Home");
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Home");
            }
            
        }
    }
}
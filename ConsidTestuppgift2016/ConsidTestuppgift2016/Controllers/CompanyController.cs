using General.Models;
using Repository.Interface;
using Repository.Repositories;
using Service.Interface;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace ConsidTestuppgift2016.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyServices _iCompanyServices;

        public CompanyController()
        {
            _iCompanyServices = new CompanyServices();
        }

        // GET: Company/Home
        // Returns View that shows all Companys
        public ActionResult Home()
        {
            try
            {
                CompanyHomeViewModel companyHomeViewModel = new CompanyHomeViewModel();
                companyHomeViewModel.lCompany = _iCompanyServices.List().OrderBy(o => o.name).ToList();
                return View(companyHomeViewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }                       
        }

        // DELETE: Company/DeleteCompany
        // Deletes chosen company with connected storys
        public ActionResult DeleteCompany()
        {
            try
            {
                string companyId = RouteData.Values["id"].ToString();
                _iCompanyServices.Delete(new Guid(companyId));
            }
            catch (Exception)
            {
                return View("Error");
            }
            return RedirectToAction("Home");
        }

        // GET: Company/EditCompany
        // Allows user to edit a Company
        public ActionResult EditCompany()
        {
            try
            {
                Company company = _iCompanyServices.Get(Guid.Parse(RouteData.Values["id"].ToString()));
                return View(company);
            }
            catch (Exception)
            {
                return View("Error");
            }
            
        }

        // POST: Company/EditCompany
        // Saves updated Company
        [HttpPost]
        public ActionResult EditCompany(Company updatedComp)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(updatedComp);
                }

                _iCompanyServices.Update(updatedComp);
                return RedirectToAction("Home");
            }
            catch (Exception)
            {
                return View("Error");
            }
            
        }

        // GET: Company/AddCompany
        // Allows user to add a new Company
        public ActionResult AddCompany()
        {
            return View(new Company());
        }

        // POST: Company/AddCompany
        // Saves new Company
        [HttpPost]
        public ActionResult AddCompany(Company company)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                company.id = Guid.NewGuid();
                _iCompanyServices.Add(company);
                return RedirectToAction("Home");
                
            }
            catch (Exception)
            {
                return View("Error");
            }
            
        }
    }
}
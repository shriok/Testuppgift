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
        private System.Web.ModelBinding.ModelStateDictionary _modelState;
        private ICompanyServices _iCompanyServices;

        public CompanyController()
        {
            _modelState = new System.Web.ModelBinding.ModelStateDictionary();
            _iCompanyServices = new CompanyServices(new ModelStateWrapper(_modelState), new Repository.Repositories.ICompanyRepository());
        }

        public CompanyController(ICompanyServices iCompanyServices)
        {
            _iCompanyServices = iCompanyServices;
        }

        // GET: Company/Home
        public ActionResult Home()
        {            
            CompanyHomeViewModel companyHomeViewModel = new CompanyHomeViewModel();
            companyHomeViewModel.lCompany = _iCompanyServices.List().OrderBy(o=>o.name).ToList();            
            return View(companyHomeViewModel);            
        }

        // DELETE: Company/DeleteCompany
        public ActionResult DeleteCompany()
        {            
            try
            {
                string companyId = RouteData.Values["id"].ToString();
                _iCompanyServices.Delete(new Guid(companyId));
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
                Company company = _iCompanyServices.Get(Guid.Parse(RouteData.Values["id"].ToString()));
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
                if (!_iCompanyServices.Update(updatedComp))
                {
                    return View();
                }
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
                company.id = Guid.NewGuid();
                if (!_iCompanyServices.Add(company))
                {
                    return View();
                }               
                
                return RedirectToAction("Home");
                
            }
            catch (Exception)
            {
                return RedirectToAction("Home");
            }
            
        }
    }
}
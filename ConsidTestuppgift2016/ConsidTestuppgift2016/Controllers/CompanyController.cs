﻿using General.Models;
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
            CompanyHomeViewModel company = new CompanyHomeViewModel();
            company.company = Service.Services.CompanyServices.List();
            return View(company);
        }

        // GET: Company/DeleteCompany
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
                string companyId = RouteData.Values["id"].ToString();
                Company company = Service.Services.CompanyServices.Get(new Guid(companyId));
                return View(company);
            }
            catch (Exception)
            {
                return RedirectToAction("Home");
            }
            
        }

        // Post: Company/EditCompany
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

        // Post: Company/AddCompany
        [HttpPost]
        public ActionResult AddCompany(Company company)
        {
            try
            {
                Service.Services.CompanyServices.Add(company);
                return RedirectToAction("Home");
            }
            catch (Exception)
            {
                return RedirectToAction("Home");
            }
            
        }
    }
}
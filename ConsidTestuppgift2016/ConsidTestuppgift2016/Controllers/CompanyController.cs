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
        // GET: Company
        public ActionResult Home()
        {            
            CompanyHomeViewModel company = new CompanyHomeViewModel();
            company.company = Service.Services.CompanyServices.List();
            return View(company);
        }

        public ActionResult DeleteCompany()
        {
            string companyId = RouteData.Values["id"].ToString();
            try
            {
                Service.Services.CompanyServices.Delete(companyId);
            }
            catch (Exception)
            {
                ViewBag.result = "Error Could not delete Company";
            }
            return RedirectToAction("Home");
        }

        public ActionResult EditCompany()
        {
            string compId;
            Service.Services.CompanyServices.Edit(compId);
            return View();
        }

        public ActionResult AddCompany()
        {
            Company company = new Company();
            Service.Services.CompanyServices.Add(company);
            return View();
        }
    }
}
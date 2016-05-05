using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using General.Models;
namespace ConsidTestuppgift2016.Controllers
{
    public class CompanieController : Controller
    {
        // GET: Companie
        public ActionResult Home()
        {
            CompanieHomeViewModel companie = new CompanieHomeViewModel();
            companie.companie = Service.Services.CompanieServices.List();
            return View(companie);
        }
    }
}
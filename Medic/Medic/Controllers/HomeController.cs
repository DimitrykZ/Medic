using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Medic.Models;
using System.Web.Security;

namespace Medic.Controllers
{
    public class HomeController : Controller
    {
        MedicContext db = new MedicContext();
        MedicContext db2 = new MedicContext();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult OrganizationAdd() //Добавление организации
        {
            SelectList list = new SelectList(db.Territories, "TerritoryId", "Name");
            ViewBag.List = list;
            return View();
        }

        [Authorize]
        [HttpPost]
        public RedirectResult OrganizationAdd(Organization org) //Добавление организации
        {
            db.Organizations.Add(org);
            db.SaveChanges();
            return Redirect("OrganizationView");
        }

        public ActionResult OrganizationView() //Просмотр организаций
        {
            ViewBag.Org = db.Organizations;
            ViewBag.Territories = db2.Territories;
            return View();
        }
    

    }
}
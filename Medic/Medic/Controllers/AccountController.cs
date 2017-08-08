using Medic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Medic.Controllers
{
    public class AccountController : Controller
    {
        MedicContext db = new MedicContext();
        MedicContext db2 = new MedicContext();
        MedicContext db3 = new MedicContext();

        [HttpGet]
        public ActionResult Login() //Метод отвечает за авторизацию
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginModel model) //Метод отвечает за авторизацию
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                User user = null;
                using (MedicContext db = new MedicContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Name && u.Password == model.Password);

                }
                if (user.PermissionId == 3)
                {
                    return RedirectToAction("BlockUser", "Account", user);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("OrganizationView", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }


       


        [Authorize]
        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("OrganizationView", "Home");
        }

        [Authorize(Roles="Manager")]
        [HttpGet]
        public ActionResult CreateUser() //Создание пользователя
        {
            SelectList listOrg = new SelectList(db.Organizations,"OrganizationId","Name");
            ViewBag.Organizations = listOrg;
            SelectList listPer = new SelectList(db.Permissions, "PermissionId", "PerName");
            ViewBag.Permissions = listPer;
            return View();
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public RedirectResult CreateUser(User user) //Создание пользователя
        {
            db.Users.Add(user);
            db.SaveChanges();
            return Redirect("ViewUser");
        }

        [Authorize(Roles = "Manager")]
        public ActionResult ViewUser() //Просмотр пользователей
        {
            ViewBag.Organization = db.Organizations;
            ViewBag.Permission = db2.Permissions;
            var users = db3.Users;
            return View(users);
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult Change(int UserId) //Измнение права доступа
        {
            SelectList list = new SelectList(db.Permissions, "PermissionId", "PerName");
            ViewBag.List = list;
            ViewBag.User = db.Users.Find(UserId);
            return View();
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public RedirectResult Change(int PermissionId, int UserId) //Измнение права доступа
        {
            db.Users.Find(UserId).PermissionId = PermissionId;
            db.SaveChanges();
            return Redirect("/Account/ViewUser");
        }


        public ActionResult BlockUser(User user) //Отвчает за сообщение, что пользователь заблокирован
        {
            ViewBag.User = user;
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Michèle.Controllers
{
    public class HomeController : DefaultController
    {
        #region Account

        public ActionResult GoOn()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Michèle.Models.GoOnModel model, string returnUrl)
        {
            if (ModelState.IsValid && Membership.ValidateUser(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, true);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Неверный пароль или логин");
            return View("~/Views/Account/Login.cshtml", model);
        }

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}
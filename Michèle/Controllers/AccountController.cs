using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Michèle.Models;

namespace Michèle.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
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
            return View(model);
        }

    }
}
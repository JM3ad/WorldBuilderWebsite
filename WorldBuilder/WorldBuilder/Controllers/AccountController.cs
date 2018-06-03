using DataAccess.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WorldBuilder.Helpers;
using WorldBuilder.Models;

namespace WorldBuilder.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginViewModel model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            User user = userManager.Find(model.Username, model.Password);
            if (user == null)
            {
                return Redirect(Url.Action("Index", "Account"));
            }
            var ident = userManager.CreateIdentity(user,
                DefaultAuthenticationTypes.ApplicationCookie);
            authManager.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
            return Redirect(Url.Action("Index", "Home"));
        }

        public async Task<ActionResult> Register(LoginViewModel model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var result = await userManager.CreateAsync(new User {UserName = model.Username}, model.Password);
            if (result.Succeeded)
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            return Redirect(Url.Action("Index", "Account"));
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect(Url.Action("About", "Home"));
        }
    }
}
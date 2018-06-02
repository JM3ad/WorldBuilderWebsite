using DataAccess.Access;
using DataAccess.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WorldBuilder.Helpers;

namespace WorldBuilder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to world builder";

            return View();
        }

        public ActionResult DummyLogin()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            User user = userManager.Find("a.User", "password");
            var ident = userManager.CreateIdentity(user,
                DefaultAuthenticationTypes.ApplicationCookie);
            authManager.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
            return Redirect(Url.Action("Index", "Home"));
        }

        public async Task<ActionResult> DummyRegister()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var result = await userManager.CreateAsync(new User { UserName = "a.User" }, "password");
            if (result.Succeeded)
            {
                return Redirect(Url.Action("DummyLogin", "Home"));
            }
            return Redirect(Url.Action("About", "Home"));
        }

        public ActionResult DummyLogout()
        {

            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect(Url.Action("About", "Home"));
        }
    }
}
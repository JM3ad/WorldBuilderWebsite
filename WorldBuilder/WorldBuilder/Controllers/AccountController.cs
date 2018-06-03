using DataAccess.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
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

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminPage()
        {
            return View();
        }

        [HttpPost]
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

        [HttpPost]
        public async Task<ActionResult> Register(LoginViewModel model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var user = new User { UserName = model.Username };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Login(model);
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
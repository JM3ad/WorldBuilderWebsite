using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorldBuilder.Controllers
{
    [Authorize]
    public class PeoplesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
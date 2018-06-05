using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorldBuilder.Controllers
{
    public class WorldController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
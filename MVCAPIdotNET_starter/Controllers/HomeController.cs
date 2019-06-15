using MVCAPIdotNET_starter.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAPIdotNET_starter.Controllers
{
    public class HomeController : BaseAppController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            ViewBag.obj = ContextualOrganization;

            return View();
        }
    }
}

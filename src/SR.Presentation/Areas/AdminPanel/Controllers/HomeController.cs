
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SR.Presentation.Areas.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
       
       // [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}


using SR.Application;
using SR.Application.Contract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SR.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserApplication _userApplication;
        public HomeController()
        {
            _userApplication = new UserApplication();

        }
        public ActionResult Index()
        {
            return RedirectToAction("Logout","Account");
        }

     
        
        public ActionResult Test()
        {
            return Content("Success enter to test action....");
        }

       

    }
}
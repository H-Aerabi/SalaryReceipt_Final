<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
=======
﻿using SR.Application;
using SR.Application.Contract.User;
using SR.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
>>>>>>> 9bcbc77864788fe59e4466b492a52298ee846da4
using System.Web;
using System.Web.Mvc;

namespace SR.Presentation.Areas.UserPanel.Controllers
{
<<<<<<< HEAD
    public class HomeController : Controller
    {
        // GET: UserPanel/Home
        public ActionResult Index()
        {
            return View();
        }
=======
    [Authorize]
    public class HomeController : Controller
    {
        //[Authorize]


        private readonly IUserApplication _userApplication;
        public HomeController()
        {

            _userApplication = new UserApplication();
        }
        public ActionResult Index()
        {
           
            var user = User.Identity.Name.Split('|');
            var userId = int.Parse(user[0]);
            EditUser userInfo = _userApplication.GetDetails(userId).Result;
            return View(userInfo);
        }

        [HttpGet]
        public ActionResult EditUserInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditUserInfo(string name)
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string pass)
        {
            return View();
        }


>>>>>>> 9bcbc77864788fe59e4466b492a52298ee846da4
    }
}
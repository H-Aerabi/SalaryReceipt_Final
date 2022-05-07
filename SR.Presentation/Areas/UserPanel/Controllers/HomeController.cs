
﻿using System;
using System.Collections.Generic;
using System.Linq;

﻿using SR.Application;
using SR.Application.Contract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using System.Web;
using System.Web.Mvc;

namespace SR.Presentation.Areas.UserPanel.Controllers
{

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



    }
}
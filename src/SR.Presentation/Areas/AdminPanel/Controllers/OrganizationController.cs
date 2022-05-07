using SR.Application;
using SR.Application.Contract.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SR.Presentation.Areas.AdminPanel.Controllers
{
    //[Authorize]
    public class OrganizationController : Controller
    {
        private readonly IOrganizationApplication _organizationApplication;
        public OrganizationController()
        {
            _organizationApplication = new OrganizationApplication();
        }
        public ActionResult Index()
        {

            return View(_organizationApplication.GetAll()) ;
        }

        public ActionResult CreateOrganization()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrganization(CreateOrganization command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            var result = _organizationApplication.Create(command);
            if (result.IsSuccess != true)
            {
                ModelState.AddModelError("", result.Message);
                return View(command);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditOrganization(int id)
        {
            var result = _organizationApplication.GetDetails(id);
            if (result.IsSuccess == false)
            {
                return Content("سازمانی با این مشخصه یافت نشد");
            }

            return View(result.Result);
        }
        [HttpPost]
        public ActionResult EditOrganization(EditOrganization command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);

            }

            var result = _organizationApplication.Edit(command);
            if (result.IsSuccess == false)
            {
                ModelState.AddModelError("", result.Message);
                return View(command);
            }

            return RedirectToAction("Index");
          
        }

        [HttpPost]
        public ActionResult RemoveOrganization(int id)
        {
            var result = _organizationApplication.Remove(id);

            return Json(result);
            
         
        }
    }
}
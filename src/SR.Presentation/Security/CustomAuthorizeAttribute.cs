//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using SR.Application;
//using SR.Application.Contract.Role;
//namespace SR.Presentation.Security
//{
//    public class CustomAuthorizeAttribute : AuthorizeAttribute
//    {
//        private readonly IRoleApplication _roleApplication;
//        private readonly int _permissionId;
//        public CustomAuthorizeAttribute(int permissionId)
//        {
//            _permissionId = permissionId;
//            _roleApplication = new RoleApplication();
//        }
//        protected override bool AuthorizeCore(HttpContextBase httpContext)
//        {

//            bool authorize = false;
//            if (httpContext.User.Identity.IsAuthenticated)
//            {
//                string nationalCode = httpContext.User.Identity.Name;


//                bool isChecked;

//                isChecked = _roleApplication.PermissionChecker(nationalCode, _permissionId);
          

//                if (isChecked)
//                {

//                    authorize = true;

//                }

//            }
//            else
//            {
//                authorize = false;
//            }



//            return authorize;
//        }

//        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
//        {
//            base.HandleUnauthorizedRequest(filterContext);

//        }
//    }
//}
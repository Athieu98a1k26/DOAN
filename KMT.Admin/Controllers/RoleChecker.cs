using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    public class RoleChecker : ActionFilterAttribute
    {
        public RoleChecker()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            base.OnActionExecuting(filterContext);
        }
    }
}
using KMT.DATA_MODEL.MenuQuanTri;
using KMT.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PermissionChecker: ActionFilterAttribute
    {
        public PermissionChecker()
        {
            
        }



        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            
            

            base.OnActionExecuting(filterContext);
        }
    }
}
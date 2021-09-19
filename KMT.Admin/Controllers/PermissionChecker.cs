using KMT.DATA_MODEL.MenuQuanTri;
using KMT.DATA_MODEL.Users;
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
        public PermissionChecker(string Permission)
        {
            this.Permission = Permission;
        }
        public string Permission { get; set; }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UserIdentity userIdentity = (UserIdentity)filterContext.HttpContext.Session["userIdentity"];
            bool isPermission = false;
            foreach (var item in userIdentity.lstPermission)
            {
                if (item.MAQUYEN.Equals(Permission))
                {
                    isPermission = true;
                    break;
                }
            }

            if (!isPermission)
            {
                filterContext.Result =
                        new RedirectResult($"/Account");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
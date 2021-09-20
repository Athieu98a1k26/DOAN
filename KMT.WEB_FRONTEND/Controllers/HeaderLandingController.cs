using KMT.DATA_MODEL.MenuQuanTri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.WEB_FRONTEND.Controllers
{

    public class HeaderLandingController : BaseController
    {
        public PartialViewResult Index()
        {
            //UserIdentity  userIdentity = (UserIdentity)Session["userIdentity"];
            List<MenuQuanTriInfo> data = Task.Run(async ()=> await ApiService.menuQuanTriService.GetListMenuByType(1)).Result;


            //if (string.IsNullOrEmpty(Request.QueryString["IDMENU"]))
            //{
            //    data[0].IsActive = true;
            //}
            //else
            //{
            //    string strIdMenu = Request.QueryString["IDMENU"];
            //    decimal Id=Convert.ToDecimal(strIdMenu);
            //    foreach (var item in data)
            //    {
            //        if (item.Id== Id)
            //        {
            //            item.IsActive = true;
            //        }
            //        else
            //        {
            //            item.IsActive = false;
            //        }
            //    }
            //}
            return PartialView(data);
        }
    }
}
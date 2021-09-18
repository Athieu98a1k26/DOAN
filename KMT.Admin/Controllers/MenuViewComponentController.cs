using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KMT.DATA_MODEL.MenuQuanTri;
namespace KMT.Admin.Controllers
{
    public class MenuViewComponentController : BaseController
    {
        // GET: MenuViewComponent
        public PartialViewResult Index()
        {
            List<MenuQuanTriInfo> data = Task.Run(()=> ApiService.menuQuanTriService.GetAll()).Result;
            
            if (string.IsNullOrEmpty(Request.QueryString["IDMENU"]))
            {
                data[0].IsActive = true;
            }
            else
            {
                string strIdMenu = Request.QueryString["IDMENU"];
                decimal Id=Convert.ToDecimal(strIdMenu);
                foreach (var item in data)
                {
                    if (item.Id== Id)
                    {
                        item.IsActive = true;
                        break;
                    }
                }
            }
            return PartialView(data);
        }
    }
}
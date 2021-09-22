using KMT.DATA_MODEL.SanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.WEB_FRONTEND.Controllers
{
    public class SanPhamController : BaseController
    {
        // GET: SanPham
        public ActionResult Index()
        {
            if (CurrentUser == null)
            {
                Response.Redirect("/Login");
                Response.End();
            }    
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> search(SanPhamRequest model)
        {
            var resutl = await ApiService.sanPhamService.search(model);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }

    }
}
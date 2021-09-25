using KMT.DATA_MODEL.SanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.WEB_FRONTEND.Controllers
{
    public class ProductController : BaseController
    {
        // GET: SanPham
        public ActionResult Index(string Keyword="")
        {
            if (CurrentUser == null)
            {
                Response.Redirect("/Login");
                Response.End();
            }
            ViewBag.Keyword = Keyword;
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
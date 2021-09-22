using KMT.DATA_MODEL.SanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.WEB_FRONTEND.Controllers
{
    public class ChiTietSanPhamController : BaseController
    {
        // GET: ChiTietSanPham
        public async Task<ActionResult> Index(int? Id)
        {
            if (!Id.HasValue)
            {
                Response.Redirect("/");
                Response.End();
            }
            SanPhamInfo data = await ApiService.sanPhamService.GetById(Id.Value);
            return View(data);
        }
    }
}
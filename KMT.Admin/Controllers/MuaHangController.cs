using KMT.DATA_MODEL.MuaHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    public class MuaHangController : BaseController
    {
        // GET: MuaHang
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> search(MuaHangRequest model)
        {
            var resutl = await ApiService.muaHangService.search(model);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }

    }
}
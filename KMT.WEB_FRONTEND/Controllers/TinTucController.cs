using KMT.DATA_MODEL.ThongTinDuLich;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.WEB_FRONTEND.Controllers
{
    public class TinTucController : BaseController
    {
        // GET: GioiThieu
        public ActionResult Index()
        {
            //ThongTinDuLichRequest thongTinDuLichRequest = new ThongTinDuLichRequest();
            //thongTinDuLichRequest.page = 1;
            //thongTinDuLichRequest.take = 10;
            //ThongTinDuLichResponse lstTinTucDuLich = await ApiService.thongTinDuLichService.search(thongTinDuLichRequest);
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> search(ThongTinDuLichRequest model)
        {
            var resutl = await ApiService.thongTinDuLichService.search(model);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }
    }
}
using KMT.DATA_MODEL.ThongTinDuLich;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.WEB_FRONTEND.Controllers
{
    public class ChiTietTinTucController : BaseController
    {
        // GET: ChiTietTinTuc
        public async Task<ActionResult> Index(int? Id)
        {
            if (!Id.HasValue)
            {
                Response.Redirect("/");
                Response.End();
            }
            ThongTinDuLichInfo data = await ApiService.thongTinDuLichService.GetById(Id.Value);
            return View(data);
        }
    }
}
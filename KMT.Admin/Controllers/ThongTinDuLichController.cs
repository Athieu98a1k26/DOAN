using KMT.Admin.Models;
using KMT.DATA_MODEL;
using KMT.DATA_MODEL.ThongTinDuLich;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    public class ThongTinDuLichController : BaseController
    {
        // GET: ThongTinDuLich
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AddOrUpdate(ThongTinDuLichInfo model)
        {
            if (string.IsNullOrEmpty(model.TIEUDE))
            {
                return Json(new MessageResponse(500, "Vui lòng nhập tiêu đề"), JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrEmpty(model.HINHANH))
            {
                return Json(new MessageResponse(500, "Vui lòng chọn hình ảnh"), JsonRequestBehavior.AllowGet);
            }
            int count = await ApiService.thongTinDuLichService.AddOrUpdate(model);
            if (count == 0)
            {
                return Json(new MessageResponse(500, "Cập nhật không thành công"), JsonRequestBehavior.AllowGet);
            }
            return Json(new MessageResponse(200, "Cập nhật thành công"), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> search(ThongTinDuLichRequest model)
        {
            var resutl = await ApiService.thongTinDuLichService.search(model);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> Delete(int Id)
        {
            var count = await ApiService.thongTinDuLichService.Delete(Id);
            if (count == 0)
            {
                return Json(new MessageResponse(500, "Xóa không thành công"), JsonRequestBehavior.AllowGet);
            }
            return Json(new MessageResponse(200, "Xóa thành công"), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> GetById(int Id)
        {
            var resutl = await ApiService.thongTinDuLichService.GetById(Id);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }
    }
}
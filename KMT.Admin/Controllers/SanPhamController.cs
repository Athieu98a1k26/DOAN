using KMT.Admin.Models;
using KMT.DATA_MODEL;
using KMT.DATA_MODEL.SanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    public class SanPhamController : BaseController
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AddOrUpdate(SanPhamInfo model)
        {
            int count = await ApiService.sanPhamService.AddOrUpdate(model);
            if (count == 0)
            {
                return Json(new MessageResponse(500, "Cập nhật không thành công"), JsonRequestBehavior.AllowGet);
            }
            return Json(new MessageResponse(200, "Cập nhật thành công"), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> search(SanPhamRequest model)
        {
            var resutl = await ApiService.sanPhamService.search(model);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> Delete(int Id)
        {
            var count = await ApiService.sanPhamService.Delete(Id);
            if (count == 0)
            {
                return Json(new MessageResponse(500, "Xóa không thành công"), JsonRequestBehavior.AllowGet);
            }
            return Json(new MessageResponse(200, "Xóa thành công"), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> GetById(int Id)
        {
            var resutl = await ApiService.sanPhamService.GetById(Id);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }
    }
}
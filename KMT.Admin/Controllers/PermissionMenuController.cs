using KMT.Admin.Models;
using KMT.DATA_MODEL.PermissionMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    public class PermissionMenuController : BaseController
    {
        // GET: PermissionMenu
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AddOrUpdate(PermissionMenuRequest model)
        {
            int count = await ApiService.permissonMenuService.AddOrUpdate(model);
            if (count == 0)
            {
                return Json(new MessageResponse(500, "Cập nhật không thành công"), JsonRequestBehavior.AllowGet);
            }
            return Json(new MessageResponse(200, "Cập nhật thành công"), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> search(PermissionMenuRequest model)
        {
            var resutl = await ApiService.permissonMenuService.search(model);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> Delete(int Id)
        {
            var count = await ApiService.permissonMenuService.Delete(Id);
            if (count == 0)
            {
                return Json(new MessageResponse(500, "Xóa không thành công"), JsonRequestBehavior.AllowGet);
            }
            return Json(new MessageResponse(200, "Xóa thành công"), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> GetById(int Id)
        {
            var resutl = await ApiService.permissonMenuService.GetById(Id);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }
    }
}
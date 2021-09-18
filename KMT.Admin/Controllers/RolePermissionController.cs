using KMT.Admin.Models;
using KMT.DATA_MODEL.Permisson;
using KMT.DATA_MODEL.Role;
using KMT.DATA_MODEL.RolePermisson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    public class RolePermissionController : BaseController
    {
        // GET: RolePermission
        public async Task<ActionResult> Index()
        {
            RoleResponse lstRoleData = await ApiService.roleService.search(new RoleRequest() { page = 1, take = int.MaxValue });
            PermissonResponse lstPermissonData = await ApiService.permissonService.search(new PermissonRequest() { page = 1, take = int.MaxValue });
            ViewBag.lstRoleData = lstRoleData.data;
            ViewBag.lstPermissonData = lstPermissonData.data;
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AddOrUpdate(RolePermissonRequest model)
        {
            
            int count = await ApiService.rolePermissonService.AddOrUpdate(model);
            if (count == 0)
            {
                return Json(new MessageResponse(500, "Cập nhật không thành công"), JsonRequestBehavior.AllowGet);
            }
            return Json(new MessageResponse(200, "Cập nhật thành công"), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> search(RolePermissonRequest model)
        {
            var resutl = await ApiService.rolePermissonService.search(model);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> Delete(int Id)
        {
            var count = await ApiService.rolePermissonService.Delete(Id);
            if (count == 0)
            {
                return Json(new MessageResponse(500, "Cập nhật không thành công"), JsonRequestBehavior.AllowGet);
            }
            return Json(new MessageResponse(200, "Cập nhật thành công"), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> GetById(int Id)
        {
            var resutl = await ApiService.rolePermissonService.GetById(Id);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }

    }
}
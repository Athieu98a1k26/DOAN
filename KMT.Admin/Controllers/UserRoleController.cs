using KMT.Admin.Models;
using KMT.DATA_MODEL.Role;
using KMT.DATA_MODEL.UserRole;
using KMT.DATA_MODEL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    public class UserRoleController : BaseController
    {
        // GET: UserRole
        public async Task<ActionResult> Index()
        {
            RoleResponse lstRoleData = await ApiService.roleService.search(new RoleRequest() { page = 1, take = int.MaxValue });
            UserResponse lstUserData = await ApiService.UserService.search(new  UserRequest { page = 1, take = int.MaxValue });
            ViewBag.lstRoleData = lstRoleData.data;
            ViewBag.lstUserData = lstUserData.data;
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AddOrUpdate(UserRoleRequest model)
        {

            int count = await ApiService.userRoleService.AddOrUpdate(model);
            if (count == 0)
            {
                return Json(new MessageResponse(500, "Cập nhật không thành công"), JsonRequestBehavior.AllowGet);
            }
            return Json(new MessageResponse(200, "Cập nhật thành công"), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> search(UserRoleRequest model)
        {
            var resutl = await ApiService.userRoleService.search(model);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> Delete(int Id)
        {
            var count = await ApiService.userRoleService.Delete(Id);
            if (count == 0)
            {
                return Json(new MessageResponse(500, "Xóa không thành công"), JsonRequestBehavior.AllowGet);
            }
            return Json(new MessageResponse(200, "Xóa thành công"), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> GetById(int Id)
        {
            var resutl = await ApiService.userRoleService.GetById(Id);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }
    }
}
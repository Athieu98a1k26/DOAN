using KMT.Admin.Models;
using KMT.DATA_MODEL;
using KMT.DATA_MODEL.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    public class RoleController : BaseController
    {
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AddOrUpdate(RoleRequest model)
        {
            if (string.IsNullOrEmpty(model.MA))
            {
                return Json(new MessageResponse(500, "Vui lòng nhập mã"), JsonRequestBehavior.AllowGet);
            }
            int count = await ApiService.roleService.AddOrUpdate(model);
            if (count==0)
            {
                return Json(new MessageResponse(500, "Cập nhật không thành công"), JsonRequestBehavior.AllowGet);
            }
            return Json(new MessageResponse(200, "Cập nhật thành công"), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> search(RoleRequest model)
        {
            var resutl= await ApiService.roleService.search(model);
            return Json(resutl,JsonRequestBehavior.AllowGet);
        }
    }
}
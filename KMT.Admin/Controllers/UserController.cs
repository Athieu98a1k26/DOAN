using KMT.Admin.Models;
using KMT.DATA_MODEL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> AddOrUpdate(UserRequest model)
        {
            if (string.IsNullOrEmpty(model.UserName))
            {
                return Json(new MessageResponse(500, "Vui lòng nhập tên tài khoản"), JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrEmpty(model.PassWord))
            {
                return Json(new MessageResponse(500, "Vui lòng nhập mật khẩu"), JsonRequestBehavior.AllowGet);
            }
            if (model.PassWord!=model.RePassWord)
            {
                return Json(new MessageResponse(500, "Mật khẩu không trùng nhau"), JsonRequestBehavior.AllowGet);
            }
            int count = await ApiService.UserService.AddOrUpdate(model);
            if (count == 0)
            {
                return Json(new MessageResponse(500, "Cập nhật không thành công"), JsonRequestBehavior.AllowGet);
            }
            return Json(new MessageResponse(200, "Cập nhật thành công"), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> search(UserRequest model)
        {
            var resutl = await ApiService.UserService.search(model);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> Delete(int Id)
        {
            var resutl = await ApiService.UserService.Delete(Id);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> GetById(int Id)
        {
            var resutl = await ApiService.UserService.GetById(Id);
            return Json(resutl, JsonRequestBehavior.AllowGet);
        }
    }
}
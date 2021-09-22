using KMT.API_DATA.Models.Users;
using KMT.DATA_MODEL.Users;
using KMT.Libraly.Helper;
using KMT.WEB_FRONTEND.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.WEB_FRONTEND.Controllers
{
    public class RegisterController : BaseController
    {
        private IAuthenticationManager AuthenticationManager()
        {
            return HttpContext.GetOwinContext().Authentication;
        }
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Register(UserRequest model)
        {

            if (string.IsNullOrEmpty(model.UserName))
            {
                return Json(new MessageResponse(500, "Vui lòng điền tên tài khoản", null));
            }
            if (string.IsNullOrEmpty(model.PassWord))
            {
                return Json(new MessageResponse(500, "Vui lòng điền mật khẩu", null));
            }
            if (model.PassWord != model.RePassWord)
            {
                return Json(new MessageResponse(500, "2 mật khẩu không giống nhau", null));
            }
            int count = await ApiService.UserService.GetCountByUserName(model.UserName);
            if (count > 0)
            {
                return Json(new MessageResponse(500, "Tài khoản đã tồn tại", null));
            }


            count = await ApiService.UserService.AddOrUpdate(model);
            UserInfo userInfo = await ApiService.UserService.GetByUserName(model.UserName);
            if (userInfo == null)
            {
                return Json(new MessageResponse(500, "Đăng nhập thất bại", null));
            }

            //xác thực thông tin, lấy list role và list quyền, list Menu
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userInfo.Name?? ""),
                new Claim("UserId", userInfo.Id.ToString()),
                new Claim("UserName", userInfo.UserName ?? ""),
            }, DefaultAuthenticationTypes.ApplicationCookie);



            AuthenticationManager().SignIn(new AuthenticationProperties
            {
                IsPersistent = true
            }, identity);

            // reset incremental delay on successful login
            if (HttpContext.Application[Request.UserHostAddress] != null)
            {
                HttpContext.Application.Remove(Request.UserHostAddress);
            }

            // Getting New Guid
            string guid = Convert.ToString(Guid.NewGuid());
            //Storing new Guid in Session
            Session["AuthenticationToken"] = guid;

            UserIdentity userIdentity = await ApiService.UserService.getUserIdentity(userInfo.Id);
            Session["userIdentity"] = userIdentity;

            //Adding Cookie in Browser
            Response.Cookies.Add(new HttpCookie("AuthenticationToken", guid));
            return Json(new MessageResponse(200, "Đăng ký thành công", null));
        }

    }
}
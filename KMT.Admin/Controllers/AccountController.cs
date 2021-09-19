using KMT.Admin.Models;
using KMT.API_DATA.Models.Users;
using KMT.DATA_MODEL.Users;
using KMT.Libraly.Helper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    public class AccountController : BaseController
    {
        private IAuthenticationManager AuthenticationManager()
        {
            return HttpContext.GetOwinContext().Authentication;
        }
        // GET: Account
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<MessageResponse> Register(UserRegisterRequest model)
        {

            if (string.IsNullOrEmpty(model.userName))
            {
                return new MessageResponse(500, "Vui lòng điền tên tài khoản", null);
            }
            if (string.IsNullOrEmpty(model.passWord))
            {
                return new MessageResponse(500, "Vui lòng điền mật khẩu", null);
            }
            if (model.passWord!=model.rePassWord)
            {
                return new MessageResponse(500, "2 mật khẩu không giống nhau", null);
            }
            int count = await ApiService.UserService.GetCountByUserName(model.userName);
            if (count>0)
            {
                return new MessageResponse(500, "Tài khoản đã tồn tại", null);
            }

            return new MessageResponse(200, "Đăng ký thành công",null);
        }

        [HttpPost]
        public async Task<JsonResult> Login(UserRequest model)
        {

            if (string.IsNullOrEmpty(model.UserName))
            {
                return Json(new MessageResponse(500, "Vui lòng điền tên tài khoản", null));
            }
            if (string.IsNullOrEmpty(model.PassWord))
            {
                return Json(new MessageResponse(500, "Vui lòng điền mật khẩu", null));
            }
            UserInfo userInfo = await ApiService.UserService.GetByUserName(model.UserName);

            if (userInfo ==null)
            {
                return Json(new MessageResponse(500, "Đăng nhập thất bại", null));
            }

            if (!Encryption.CheckPassword(model.PassWord,userInfo.PassWord))
            {
                return Json(new MessageResponse(500, "Tài khoản mật khẩu không đúng", null));

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
            }, identity) ;

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
            return Json(new MessageResponse(200, model.ReturnUrl, null)); ;
        }
        private bool IsLocalUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;
            return url[0] == '/' && (url.Length == 1 ||
                                     url[1] != '/' && url[1] != '\\') || // "/" or "/foo" but not "//" or "/\"
                   url.Length > 1 &&
                   url[0] == '~' && url[1] == '/'; // "~/" or "~/foo"
        }
        [HttpPost]
        public ActionResult Logout()
        {
            AuthenticationManager().SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            //Removing Session
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            System.Web.HttpContext.Current.Session.Clear();
            System.Web.HttpContext.Current.Session.Abandon();
            System.Web.HttpContext.Current.Session.RemoveAll();
            //Removing ASP.NET_SessionId Cookie
            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-10);
            }

            if (Request.Cookies["AuthenticationToken"] != null)
            {
                Response.Cookies["AuthenticationToken"].Value = string.Empty;
                Response.Cookies["AuthenticationToken"].Expires = DateTime.Now.AddMonths(-10);
            }

            return RedirectToAction("Index", "Account");
        }
    }
}
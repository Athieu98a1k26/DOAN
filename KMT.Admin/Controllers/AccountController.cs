using KMT.Admin.Models;
using KMT.API_DATA.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
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
    }
}
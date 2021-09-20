
using KMT.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.WEB_FRONTEND.Controllers
{
    public class BaseController : Controller
    {
        //private UserInfo _currentUser;
        public BaseController()
        {
            
        }

        //public UserInfo CurrentUser
        //{
        //    get
        //    {
        //        if (!User.Identity.IsAuthenticated)
        //        {
        //            _currentUser = null;
        //            return _currentUser;
        //        }

        //        if (_currentUser != null)
        //            return _currentUser;

        //        var identity = User.Identity as ClaimsIdentity;

        //        var Name = identity.FindFirstValue("Name");
        //        var UserId = identity.FindFirstValue("UserId");
        //        var UserName = identity.FindFirstValue("UserName");

        //        _currentUser = new UserInfo
        //        {
        //            Name = Name,
        //            Id = int.Parse(UserId),
        //            UserName= UserName
        //        };
        //        return _currentUser;
        //    }
        //    set => _currentUser = value;
        //}

        private ApiServiceFactory _apiServiceFactory;
        public ApiServiceFactory ApiService
        {
            get
            {
                if (_apiServiceFactory != null)
                    return _apiServiceFactory;
                _apiServiceFactory = new ApiServiceFactory(ConfigurationManager.AppSettings["ApiGateWay"]);

                return _apiServiceFactory;
            }
        }
    }
}
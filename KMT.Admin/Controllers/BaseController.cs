using KMT.DATA_MODEL.MenuQuanTri;
using KMT.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            
        }
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
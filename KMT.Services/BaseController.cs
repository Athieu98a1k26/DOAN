using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KMT.Services
{
    public class BaseController : Controller
    {
        public BaseController()
        {

            
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {

            if (filterContext.Exception == null)
            {
                base.OnException(filterContext);
                return;
            }

            if (filterContext.Exception is HttpException httpException && httpException.GetHttpCode() == 404)
            {
                base.OnException(filterContext);
                return;
            }
            base.OnException(filterContext);
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            

            return base.BeginExecuteCore(callback, state);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {

            base.OnResultExecuted(filterContext);
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
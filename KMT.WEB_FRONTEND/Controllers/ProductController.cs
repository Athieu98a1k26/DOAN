using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMT.WEB_FRONTEND.Controllers
{
    public class ProductController : BaseController
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
    }
}
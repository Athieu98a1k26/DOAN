using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin.Controllers
{
    [Authorize]
    [AuthenticateUser]
    public class QuanTriController : BaseController
    {
        // GET: QuanTri
        public ActionResult Index()
        {
            return View();
        }
    }
}
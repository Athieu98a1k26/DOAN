using KMT.Admin.Models;
using KMT.DATA_MODEL.Role;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public MessageResponse AddOrUpdate(RoleRequest model)
        {
            if (string.IsNullOrEmpty(model.MA))
            {
                return new MessageResponse(500, "Vui lòng nhập mã");
            }

        }
    }
}
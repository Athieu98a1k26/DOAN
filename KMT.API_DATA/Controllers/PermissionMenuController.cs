using KMT.API_DATA.Data.Repository;
using KMT.DATA_MODEL.PermissionMenu;
using KMT.DATA_MODEL.RolePermisson;
using KMT.DATA_MODEL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KMT.API_DATA.Controllers
{
    [RoutePrefix("api/permissonMenu")]
    public class PermissionMenuController : ApiController
    {
        PermissionMenuRepository permissionMenuRepository = new PermissionMenuRepository();


        [Route("AddOrUpdate")]
        [HttpPost]
        public int AddOrUpdate(PermissionMenuRequest model)
        {
            int count = permissionMenuRepository.AddOrUpdate(model);
            return count;
        }

        [Route("search")]
        [HttpPost]
        public PermissionMenuResponse search(PermissionMenuRequest model)
        {
            var dt = permissionMenuRepository.search(model);
            return dt;
        }
        [Route("Delete")]
        [HttpGet]
        public int Delete(int Id)
        {
            var dt = permissionMenuRepository.Delete(Id);
            return dt;
        }

        [Route("GetById")]
        [HttpGet]
        public PermissionMenuInfo GetById(int Id)
        {
            var dt = permissionMenuRepository.GetById(Id);
            return dt;
        }
    }
}
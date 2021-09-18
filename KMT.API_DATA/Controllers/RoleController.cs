using KMT.API_DATA.Data.Repository;
using KMT.DATA_MODEL;
using KMT.DATA_MODEL.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KMT.API_DATA.Controllers
{
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        // GET: Role
        //AddOrUpdate
        RoleRepository roleRepository = new RoleRepository();
        // GET: UserAPI
        [Route("AddOrUpdate")]
        [HttpPost]
        public int AddOrUpdate(RoleRequest model)
        {
            int count = roleRepository.AddOrUpdate(model);
            return count;
        }

        [Route("search")]
        [HttpPost]
        public RoleResponse search(RoleRequest model)
        {
            var dt = roleRepository.search(model);
            return dt;
        }
    }
}
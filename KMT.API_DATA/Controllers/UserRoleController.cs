using KMT.API_DATA.Data.Repository;
using KMT.DATA_MODEL.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KMT.API_DATA.Controllers
{
    //userRole
    [RoutePrefix("api/userRole")]
    public class UserRoleController : ApiController
    {
        UserRoleRepository  userRoleRepository = new UserRoleRepository();


        [Route("AddOrUpdate")]
        [HttpPost]
        public int AddOrUpdate(UserRoleRequest model)
        {
            int count = userRoleRepository.AddOrUpdate(model);
            return count;
        }

        [Route("search")]
        [HttpPost]
        public UserRoleResponse search(UserRoleRequest model)
        {
            var dt = userRoleRepository.search(model);
            return dt;
        }
        [Route("Delete")]
        [HttpGet]
        public int Delete(int Id)
        {
            var dt = userRoleRepository.Delete(Id);
            return dt;
        }

        [Route("GetById")]
        [HttpGet]
        public UserRoleInfo GetById(int Id)
        {
            var dt = userRoleRepository.GetById(Id);
            return dt;
        }
    }
}
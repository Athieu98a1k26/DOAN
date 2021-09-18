using KMT.API_DATA.Data.Repository;
using KMT.DATA_MODEL.RolePermisson;
using KMT.DATA_MODEL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KMT.API_DATA.Controllers
{
    [RoutePrefix("api/rolepermisson")]
    public class MuaHangController : ApiController
    {
        RolePermissonRepository rolePermissonRepository = new RolePermissonRepository();


        [Route("AddOrUpdate")]
        [HttpPost]
        public int AddOrUpdate(RolePermissonRequest model)
        {
            int count = rolePermissonRepository.AddOrUpdate(model);
            return count;
        }

        [Route("search")]
        [HttpPost]
        public RolePermissonResponse search(RolePermissonRequest model)
        {
            var dt = rolePermissonRepository.search(model);
            return dt;
        }
        [Route("Delete")]
        [HttpGet]
        public int Delete(int Id)
        {
            var dt = rolePermissonRepository.Delete(Id);
            return dt;
        }

        [Route("GetById")]
        [HttpGet]
        public RolePermissonInfo GetById(int Id)
        {
            var dt = rolePermissonRepository.GetById(Id);
            return dt;
        }
    }
}
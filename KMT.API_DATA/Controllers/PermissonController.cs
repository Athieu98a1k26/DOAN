using KMT.API_DATA.Data.Repository;
using KMT.DATA_MODEL;
using KMT.DATA_MODEL.Permisson;
using KMT.DATA_MODEL.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KMT.API_DATA.Controllers
{
    [RoutePrefix("api/permisson")]
    public class PermissonController : ApiController
    {
        // GET: Role
        //AddOrUpdate
        PermissonRepository permissonRepository = new PermissonRepository();
        // GET: UserAPI
        [Route("AddOrUpdate")]
        [HttpPost]
        public int AddOrUpdate(PermissonRequest model)
        {
            int count = permissonRepository.AddOrUpdate(model);
            return count;
        }

        [Route("search")]
        [HttpPost]
        public PermissonResponse search(PermissonRequest model)
        {
            var dt = permissonRepository.search(model);
            return dt;
        }

        [Route("Delete")]
        [HttpGet]
        public int Delete(int Id)
        {
            var dt = permissonRepository.Delete(Id);
            return dt;
        }

        [Route("GetById")]
        [HttpGet]
        public PermissonInfo GetById(int Id)
        {
            var dt = permissonRepository.GetById(Id);
            return dt;
        }
    }
}
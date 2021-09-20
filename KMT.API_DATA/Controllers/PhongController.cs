using KMT.API_DATA.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace KMT.API_DATA.Controllers
{
    [RoutePrefix("api/Phong")]
    public class PhongController : ApiController
    {
        PhongRepository phongRepository = new PhongRepository();


        [Route("AddOrUpdate")]
        [HttpPost]
        public int AddOrUpdate(PhongInfo model)
        {
            int count = phongRepository.AddOrUpdate(model);
            return count;
        }

        [Route("search")]
        [HttpPost]
        public PhongResponse search(PhongRequest model)
        {
            var dt = phongRepository.search(model);
            return dt;
        }
        [Route("Delete")]
        [HttpGet]
        public int Delete(int Id)
        {
            var dt = phongRepository.Delete(Id);
            return dt;
        }

        [Route("GetById")]
        [HttpGet]
        public PhongInfo GetById(int Id)
        {
            var dt = phongRepository.GetById(Id);
            return dt;
        }
    }
}
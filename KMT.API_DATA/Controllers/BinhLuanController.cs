using KMT.API_DATA.Data.Repository;
using KMT.DATA_MODEL.BinhLuan;
using KMT.DATA_MODEL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KMT.API_DATA.Controllers
{
    [RoutePrefix("api/rolepermisson")]
    public class BinhLuanController : ApiController
    {
        BinhLuanRepository BinhLuanRepository = new BinhLuanRepository();


        [Route("AddOrUpdate")]
        [HttpPost]
        public int AddOrUpdate(BinhLuanInfo model)
        {
            int count = BinhLuanRepository.AddOrUpdate(model);
            return count;
        }

        [Route("search")]
        [HttpPost]
        public BinhLuanResponse search(BinhLuanRequest model)
        {
            var dt = BinhLuanRepository.search(model);
            return dt;
        }
        [Route("Delete")]
        [HttpGet]
        public int Delete(int Id)
        {
            var dt = BinhLuanRepository.Delete(Id);
            return dt;
        }

        [Route("GetById")]
        [HttpGet]
        public BinhLuanInfo GetById(int Id)
        {
            var dt = BinhLuanRepository.GetById(Id);
            return dt;
        }
    }
}
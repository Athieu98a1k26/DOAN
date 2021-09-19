using KMT.API_DATA.Data.Repository;
using KMT.DATA_MODEL.MuaHang;
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
        MuaHangRepository MuaHangRepository = new MuaHangRepository();


        [Route("AddOrUpdate")]
        [HttpPost]
        public int AddOrUpdate(MuaHangInfo model)
        {
            int count = MuaHangRepository.AddOrUpdate(model);
            return count;
        }

        [Route("search")]
        [HttpPost]
        public MuaHangResponse search(MuaHangRequest model)
        {
            var dt = MuaHangRepository.search(model);
            return dt;
        }
        [Route("Delete")]
        [HttpGet]
        public int Delete(int Id)
        {
            var dt = MuaHangRepository.Delete(Id);
            return dt;
        }

        [Route("GetById")]
        [HttpGet]
        public MuaHangInfo GetById(int Id)
        {
            var dt = MuaHangRepository.GetById(Id);
            return dt;
        }
    }
}
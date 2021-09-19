using KMT.API_DATA.Data.Repository;
using KMT.DATA_MODEL.ThongTinDuLich;
using KMT.DATA_MODEL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KMT.API_DATA.Controllers
{
    [RoutePrefix("api/ThongTinDuLich")]
    public class ThongTinDuLichController : ApiController
    {
        ThongTinDuLichRepository ThongTinDuLichRepository = new ThongTinDuLichRepository();


        [Route("AddOrUpdate")]
        [HttpPost]
        public int AddOrUpdate(ThongTinDuLichInfo model)
        {
            int count = ThongTinDuLichRepository.AddOrUpdate(model);
            return count;
        }

        [Route("search")]
        [HttpPost]
        public ThongTinDuLichResponse search(ThongTinDuLichRequest model)
        {
            var dt = ThongTinDuLichRepository.search(model);
            return dt;
        }
        [Route("Delete")]
        [HttpGet]
        public int Delete(int Id)
        {
            var dt = ThongTinDuLichRepository.Delete(Id);
            return dt;
        }

        [Route("GetById")]
        [HttpGet]
        public ThongTinDuLichInfo GetById(int Id)
        {
            var dt = ThongTinDuLichRepository.GetById(Id);
            return dt;
        }
    }
}
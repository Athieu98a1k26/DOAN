using KMT.API_DATA.Data.Repository;
using KMT.DATA_MODEL.SanPham;
using KMT.DATA_MODEL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KMT.API_DATA.Controllers
{
    [RoutePrefix("api/dfsd")]
    public class SanPhamController : ApiController
    {
        SanPhamRepositoryBaseRepository sanPhamRepository = new SanPhamRepositoryBaseRepository();


        [Route("AddOrUpdate")]
        [HttpPost]
        public int AddOrUpdate(SanPhamInfo model)
        {
            int count = sanPhamRepository.AddOrUpdate(model);
            return count;
        }

        [Route("search")]
        [HttpPost]
        public SanPhamResponse search(SanPhamRequest model)
        {
            var dt = sanPhamRepository.search(model);
            return dt;
        }
        [Route("Delete")]
        [HttpGet]
        public int Delete(int Id)
        {
            var dt = sanPhamRepository.Delete(Id);
            return dt;
        }

        [Route("GetById")]
        [HttpGet]
        public SanPhamInfo GetById(int Id)
        {
            var dt = sanPhamRepository.GetById(Id);
            return dt;
        }
    }
}
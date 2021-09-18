using KMT.API_DATA.Data.Repository;
using KMT.DATA_MODEL.MenuQuanTri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KMT.API_DATA.Controllers
{
    [RoutePrefix("api/menuQuanTri")]
    public class MenuQuanTriAPIController : ApiController
    {
        MenuQuanTriRepository menuQuanTriRepository = new MenuQuanTriRepository();
        // GET: UserAPI
        [Route("GetAll")]
        [HttpGet]
        public List<MenuQuanTriInfo> GetAll()
        {
           
            return menuQuanTriRepository.GetAll();
        }
    }
}
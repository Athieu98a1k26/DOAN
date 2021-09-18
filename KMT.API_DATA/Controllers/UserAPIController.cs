using KMT.API_DATA.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KMT.API_DATA.Controllers
{
    [RoutePrefix("api/user")]
    public class UserAPIController : ApiController
    {
        UserRepository userRepository = new UserRepository();
        // GET: UserAPI
        [Route("GetCountByUserName")]
        [HttpGet]
        public int GetCountByUserName(string UserName)
        {
            
            int count = userRepository.GetCountByUserName(UserName);
            return count;
        }
    }
}
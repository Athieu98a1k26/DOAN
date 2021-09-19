using KMT.API_DATA.Data.Repository;
using KMT.DATA_MODEL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KMT.API_DATA.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
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

        [Route("GetByUserName")]
        [HttpGet]
        public UserInfo GetByUserName(string UserName)
        {

            UserInfo userInfo = userRepository.GetByUserName(UserName);
            return userInfo;
        }

        [Route("AddOrUpdate")]
        [HttpPost]
        public int AddOrUpdate(UserRequest model)
        {
            int count = userRepository.AddOrUpdate(model);
            return count;
        }

        [Route("search")]
        [HttpPost]
        public UserResponse search(UserRequest model)
        {
            var dt = userRepository.search(model);
            return dt;
        }
        [Route("Delete")]
        [HttpGet]
        public int Delete(int Id)
        {
            var dt = userRepository.Delete(Id);
            return dt;
        }
        //getUserIdentity
        [Route("getUserIdentity")]
        [HttpGet]
        public UserIdentity getUserIdentity(int Id)
        {
            var dt = userRepository.getUserIdentity(Id);
            return dt;
        }

        [Route("GetById")]
        [HttpGet]
        public UserInfo GetById(int Id)
        {
            var dt = userRepository.GetById(Id);
            return dt;
        }
    }
}
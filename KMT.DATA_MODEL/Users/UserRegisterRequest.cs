using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.API_DATA.Models.Users
{
    public class UserRegisterRequest
    {
        public string userName { get; set; }
        public string passWord { get; set; }
        public string rePassWord { get; set; }
    }
}
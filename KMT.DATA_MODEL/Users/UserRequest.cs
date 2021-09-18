
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.Users
{
    public class UserRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string RePassWord { get; set; }
        public int page { get; set; }
        public int take { get; set; }
    }
}
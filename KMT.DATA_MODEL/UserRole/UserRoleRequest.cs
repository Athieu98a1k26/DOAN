using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.UserRole
{
    public class UserRoleRequest
    {
        public int Id { get; set; }
        public string ROLE { get; set; }
        public int USERID { get; set; }
        public int page { get; set; }
        public int take { get; set; }
    }
}
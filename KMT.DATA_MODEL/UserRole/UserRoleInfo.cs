using KMT.DATA_MODEL.Permisson;
using KMT.DATA_MODEL.Role;
using KMT.DATA_MODEL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.UserRole
{
    public class UserRoleInfo
    {
        public int Id { get; set; }
        public string ROLE { get; set; }
        public int USERID { get; set; }
        public List<RoleInfo> lstRoleInfo { get; set; }
        public UserInfo UserInfo { get; set; }
        public UserRoleInfo()
        {
            lstRoleInfo = new List<RoleInfo>();
            UserInfo = new UserInfo();
        }
    }
}
using KMT.DATA_MODEL.MenuQuanTri;
using KMT.DATA_MODEL.Permisson;
using KMT.DATA_MODEL.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.Users
{
    public class UserIdentity
    {
        public UserInfo userInfo { get; set; }
        public List<RoleInfo> lstRole { get; set; }
        public List<PermissonInfo> lstPermission { get; set; }

        public List<MenuQuanTriInfo> lstMenuQuanTri { get; set; }
    }
}
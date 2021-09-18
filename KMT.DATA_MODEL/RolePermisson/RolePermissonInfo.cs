using KMT.DATA_MODEL.Permisson;
using KMT.DATA_MODEL.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.RolePermisson
{
    public class RolePermissonInfo
    {
        public int Id { get; set; }
        public int ROLEID { get; set; }
        public string PERMISSON { get; set; }

        public List<PermissonInfo> lstPermissonInfo { get; set; }
        public RoleInfo roleInfo { get; set; }
        public RolePermissonInfo()
        {
            lstPermissonInfo = new List<PermissonInfo>();
            roleInfo = new RoleInfo();
        }
    }
}
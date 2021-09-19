using KMT.DATA_MODEL.MenuQuanTri;
using KMT.DATA_MODEL.Permisson;
using KMT.DATA_MODEL.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.PermissionMenu
{
    public class PermissionMenuInfo
    {
        public int Id { get; set; }
        public int PERMISSIONID { get; set; }
        public string MENU { get; set; }

        public List<MenuQuanTriInfo> lstMenuQuanTriInfo { get; set; }
        public PermissonInfo PermissionInfo { get; set; }
        public PermissionMenuInfo()
        {
            lstMenuQuanTriInfo = new List<MenuQuanTriInfo>();
            PermissionInfo = new PermissonInfo();
        }
    }
}
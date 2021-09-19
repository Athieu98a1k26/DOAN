using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.PermissionMenu
{
    public class PermissionMenuRequest
    {
        public int Id { get; set; }
        public int PERMISSIONID { get; set; }
        public string MENU { get; set; }
        public int page { get; set; }
        public int take { get; set; }
    }
}
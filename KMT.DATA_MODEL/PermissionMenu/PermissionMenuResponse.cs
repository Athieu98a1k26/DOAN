using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.PermissionMenu
{
    public class PermissionMenuResponse
    {
        public int page { get; set; }
        public int take { get; set; }
        public int total { get; set; }
        public List<PermissionMenuInfo> data { get; set; }
    }
}
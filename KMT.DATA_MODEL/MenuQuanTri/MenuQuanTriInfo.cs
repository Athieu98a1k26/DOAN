using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.MenuQuanTri
{
    public class MenuQuanTriInfo
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string NAME { get; set; }
        public bool IsActive { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.RolePermisson
{
    public class RolePermissonRequest
    {
        public int Id { get; set; }
        public int ROLEID { get; set; }
        public string PERMISSON { get; set; }
        public int page { get; set; }
        public int take { get; set; }
    }
}
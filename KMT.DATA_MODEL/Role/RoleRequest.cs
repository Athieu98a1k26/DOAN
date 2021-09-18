using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.Role
{
    public class RoleRequest
    {
        public int Id { get; set; }
        public string TEN { get; set; }
        public string MA { get; set; }
        public int page { get; set; }
        public int take { get; set; }
        
    }
}
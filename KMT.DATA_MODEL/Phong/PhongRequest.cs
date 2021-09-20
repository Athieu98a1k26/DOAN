using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.Phong
{
    public class PhongRequest
    {
        public int Id { get; set; }
        public int? LOAIPHONG { get; set; }
        public int page { get; set; }
        public int take { get; set; }
    }
}
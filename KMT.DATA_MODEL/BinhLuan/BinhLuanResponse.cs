using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.BinhLuan
{
    public class BinhLuanResponse
    {
        public int page { get; set; }
        public int take { get; set; }
        public int total { get; set; }
        public List<BinhLuanInfo> data { get; set; }
    }
}
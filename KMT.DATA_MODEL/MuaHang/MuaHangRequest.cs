using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.MuaHang
{
    public class MuaHangRequest
    {
        public int Id { get; set; }
        public int? IDUSER { get; set; }
        public int? IDSanPham { get; set; }
        public int page { get; set; }
        public int take { get; set; }
    }
}
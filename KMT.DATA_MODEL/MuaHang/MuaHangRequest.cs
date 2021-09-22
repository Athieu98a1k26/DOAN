using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.MuaHang
{
    public class MuaHangRequest
    {
        public int Id { get; set; }
        public Nullable<int> IDSANPHAM { get; set; }
        public Nullable<int> IDUSER { get; set; }
        public string NGUOITAO { get; set; }
        public System.DateTime NGAYTAO { get; set; }
        public int page { get; set; }
        public int take { get; set; }
    }
}
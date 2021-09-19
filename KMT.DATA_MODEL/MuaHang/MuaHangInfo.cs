using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.MuaHang
{
    public class MuaHangInfo
    {
        public int Id { get; set; }
        public int IDSANPHAM { get; set; }
        public int IDUSER { get; set; }
        public string NGUOITAO { get; set; }
        public DateTime NGAYTAO { get; set; }
        public string NGUOISUA { get; set; }
        public DateTime NGAYSUA { get; set; }
    }
}
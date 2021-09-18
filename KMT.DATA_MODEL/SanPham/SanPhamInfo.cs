using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.SanPham
{
    public class SanPhamInfo
    {
        public int Id { get; set; }
        public string TENMATHANG { get; set; }
        public int GIA { get; set; }
        public string MOTA { get; set; }
        public string HINHANH { get; set; }
        public string NGUOITAO { get; set; }
        public DateTime NGAYTAO { get; set; }
        public string NGUOISUA { get; set; }
        public DateTime NGAYSUA { get; set; }
        public bool IsDelete { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.SanPham
{
    public class SanPhamRequest
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public string TENMATHANG { get; set; }
        public int? GIA { get; set; }
        public int? GIAMIN { get; set; }
        public int? GIAMAX { get; set; }
        public string Keyword { get; set; }
        public int page { get; set; }
        public int take { get; set; }
    }
}
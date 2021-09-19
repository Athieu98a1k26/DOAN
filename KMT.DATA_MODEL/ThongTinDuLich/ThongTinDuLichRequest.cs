using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.ThongTinDuLich
{
    public class ThongTinDuLichRequest
    {
        public int Id { get; set; }
        public string TIEUDE { get; set; }
        public int? TRANGTHAI { get; set; }
        public int page { get; set; }
        public int take { get; set; }
    }
}
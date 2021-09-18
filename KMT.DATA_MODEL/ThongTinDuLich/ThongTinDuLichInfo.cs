using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.ThongTinDuLich
{
    public class ThongTinDuLichInfo
    {
        public int Id { get; set; }
        public string TIEUDE { get; set; }
        public string NOIDUNG { get; set; }
        public string MOTA { get; set; }
        public string HINHANH { get; set; }
        public string NGUOITAO { get; set; }
        public DateTime NGAYTAO { get; set; }
        public string NGUOISUA { get; set; }
        public  DateTime NGAYSUA { get; set; }
        public int TRANGTHAI { get; set; }
    }
}
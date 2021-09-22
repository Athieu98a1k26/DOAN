using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.BinhLuan
{
    public class BinhLuanInfo
    {
        public int Id { get; set; }
        public int IDSANPHAM { get; set; }
        public string NOIDUNG { get; set; }
        public int IDUSER { get; set; }
        public string NGUOITAO { get; set; }
        public DateTime NGAYTAO { get; set; }
        public string NGUOISUA { get; set; }
        public DateTime NGAYSUA { get; set; }
        public string strNGAYTAO {  get{ return NGAYTAO.ToString("dd/MM/yyyy"); } set => NGAYTAO = DateTime.ParseExact(value, "dd/MM/yyyy", null); }
        public bool IsDelete { get; set; }
    }
}
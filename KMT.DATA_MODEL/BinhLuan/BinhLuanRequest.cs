using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.BinhLuan
{
    public class BinhLuanRequest
    {
        public int Id { get; set; }
        public string NOIDUNG { get; set; }
        public bool? IsDelete { get; set; }
        public int? IDUSER { get; set; }
        public int page { get; set; }
        public int take { get; set; }
    }
}
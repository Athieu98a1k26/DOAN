using System;
using  Collections.Generic;
using  Linq;
using  Web;

namespace KMT.DATA_MODEL.Phong
{
    public class PhongInfo
    {
        public int Id { get; set; }
        public string HOTEN { get; set; }
        public string EMAIL { get; set; }
        public string DIACHI { get; set; }
        public string SODIENTHOAI { get; set; }
        public string CHUNGMINHTHUNHANDAN { get; set; }
        public int  LOAIPHONG { get; set; }
        public int  SOKHACH { get; set; }
        public  DateTime  NGAYDEN { get; set; }
        public  DateTime  NGAYDI { get; set; }
        public string QUOCTICH { get; set; }
        public string GIOITINH { get; set; }
        public int  BOPHANGUIDEN { get; set; }
        public string NOIDUNG { get; set; }
    }
}
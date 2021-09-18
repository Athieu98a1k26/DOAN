using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.Users
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string NguoiTao { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public string NguoiSua { get; set; }
        public Nullable<System.DateTime> NgaySua { get; set; }
        public string Name { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.DATA_MODEL.Permisson
{
    public class PermissonRequest
    {
        public int Id { get; set; }
        public string MAQUYEN { get; set; }
        public string TENQUYEN { get; set; }
        public int page { get; set; }
        public int take { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.API_DATA.Data
{
    public class BaseRepository
    {
        public KTM_Entities DbContext { get; set; }
        public BaseRepository()
        {
            if (DbContext==null)
            {
                DbContext = new KTM_Entities();
            }
        }
    }
}
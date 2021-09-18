using KMT.DATA_MODEL.MenuQuanTri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.API_DATA.Data.Repository
{
    public class MenuQuanTriRepository: BaseRepository
    {
        public List<MenuQuanTriInfo> GetAll()
        {
            var dataReturn = (from a in DbContext.MENUQUANTRIs
                        select new MenuQuanTriInfo
                        {
                            Id = a.Id,
                            URL = a.URL,
                            IsActive=false,
                            NAME= a.NAME
                        }).ToList() ?? new List<MenuQuanTriInfo>();
            return dataReturn;
        }
    }
}
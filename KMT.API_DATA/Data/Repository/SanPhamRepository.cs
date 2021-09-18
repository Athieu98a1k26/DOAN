using KMT.DATA_MODEL.SanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.API_DATA.Data.Repository
{
    public class SanPhamRepositoryBaseRepository : BaseRepository
    {
        public List<SanPhamInfo> GetAll()
        {
            var dataReturn = (from a in DbContext.SANPHAMs
                              select new SanPhamInfo
                              {
                                  Id = a.Id,
                                  TENMATHANG = a.TENMATHANG,
                                  GIA = (int)a.GIA,
                                  MOTA = a.MOTA,
                                  HINHANH = a.HINHANH,
                                  NGUOITAO = a.NGUOITAO,
                                  NGAYTAO = (DateTime)a.NGAYTAO,
                                  NGUOISUA = a.NGUOISUA,
                                  NGAYSUA = (DateTime)a.NGAYSUA,
                                  IsDelete = false
                              }).ToList() ?? new List<SanPhamInfo>();
            return dataReturn;
        }
    }
}
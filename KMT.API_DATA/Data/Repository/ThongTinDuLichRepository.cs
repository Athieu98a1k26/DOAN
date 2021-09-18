using KMT.DATA_MODEL.SanPham;
using KMT.DATA_MODEL.ThongTinDuLich;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace KMT.API_DATA.Data.Repository
{
    public class ThongTinDuLichRepository : BaseRepository
    {
        public List<ThongTinDuLichInfo> GetAll()
        {
            var dataReturn = (from a in DbContext.THONGTINDULICHes
                              select new ThongTinDuLichInfo
                              {
                                  Id = a.Id,
                                  TIEUDE = a.TIEUDE,
                                  NOIDUNG = a.NOIDUNG,
                                  MOTA = a.MOTA,
                                  HINHANH = a.HINHANH,
                                  NGUOITAO = a.NGUOITAO,
                                  NGAYTAO = (DateTime) a.NGAYTAO,
                                  NGUOISUA = a.NGUOISUA,
                                  NGAYSUA = (DateTime)a.NGAYSUA,
                                  TRANGTHAI = (int)a.TRANGTHAI
                              }).ToList() ?? new List<ThongTinDuLichInfo>();
            return dataReturn;
        }
    }
}
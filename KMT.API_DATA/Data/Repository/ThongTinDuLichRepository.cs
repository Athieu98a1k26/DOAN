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
            List<ThongTinDuLichInfo> dataReturn = (from a in DbContext.THONGTINDULICHes
                              select new ThongTinDuLichInfo
                              {
                                  Id = a.Id,
                                  TIEUDE = a.TIEUDE,
                                  NOIDUNG = a.NOIDUNG,
                                  MOTA = a.MOTA,
                                  HINHANH = a.HINHANH,
                                  NGUOITAO = a.NGUOITAO,
                                  NGUOISUA = a.NGUOISUA,
                                  TRANGTHAI = a.TRANGTHAI.Value
                              }).ToList() ?? new List<ThongTinDuLichInfo>();
            return dataReturn;
        }

        public int AddOrUpdate(ThongTinDuLichInfo model)
        {

            if (model.Id == 0)
            {
                //them mới
                THONGTINDULICH oTHONGTINDULICHes = new THONGTINDULICH();
                oTHONGTINDULICHes.MOTA = model.MOTA;
                oTHONGTINDULICHes.TIEUDE = model.TIEUDE;
                oTHONGTINDULICHes.NOIDUNG = model.NOIDUNG;
                oTHONGTINDULICHes.MOTA = model.MOTA;
                oTHONGTINDULICHes.HINHANH = model.HINHANH;
                oTHONGTINDULICHes.NGUOITAO = "test";
                oTHONGTINDULICHes.NGAYTAO = DateTime.Now;
                oTHONGTINDULICHes.NGUOISUA = string.Empty;
                oTHONGTINDULICHes.TRANGTHAI = 0;
                DbContext.THONGTINDULICHes.Add(oTHONGTINDULICHes);
                return DbContext.SaveChanges();
            }
            else
            {
                //cập nhật
                var data = DbContext.THONGTINDULICHes.FirstOrDefault(s => s.Id == model.Id);
                data.MOTA = model.MOTA;
                data.TIEUDE = model.TIEUDE;
                data.NOIDUNG = model.NOIDUNG;
                data.MOTA = model.MOTA;
                data.HINHANH = model.HINHANH;
                data.NGAYSUA = DateTime.Now;
                data.TRANGTHAI = 0;
                return DbContext.SaveChanges();
            }
        }

        public ThongTinDuLichResponse search(ThongTinDuLichRequest model)
        {
            int skip = (model.page * model.take) - model.take;
            ThongTinDuLichResponse dt = new ThongTinDuLichResponse();
            List<ThongTinDuLichInfo> q = (from a in DbContext.THONGTINDULICHes.Where(s => s.TRANGTHAI == 0)
                                   where
                                   (string.IsNullOrEmpty(model.TIEUDE) || a.TIEUDE.Contains(model.TIEUDE))
                                   select new ThongTinDuLichInfo()
                                   {
                                       Id = a.Id,
                                       TIEUDE = a.TIEUDE,
                                       NOIDUNG = a.NOIDUNG,
                                       MOTA = a.MOTA,
                                       HINHANH = a.HINHANH,
                                       NGUOITAO = a.NGUOITAO,
                                       NGUOISUA = a.NGUOISUA,
                                       TRANGTHAI = a.TRANGTHAI.Value
                                   }).ToList() ?? new List<ThongTinDuLichInfo>();

            dt.total = q.Count();
            dt.data = q.Skip(skip).Take(model.take).ToList();
            dt.page = model.page;
            dt.take = model.take;
            return dt;
        }

        public int Delete(int Id)
        {
            var data = DbContext.THONGTINDULICHes.FirstOrDefault(s => s.Id == Id);
            data.TRANGTHAI = 1;
            return DbContext.SaveChanges();
        }

        public ThongTinDuLichInfo GetById(int Id)
        {
            ThongTinDuLichInfo data = (from a in DbContext.THONGTINDULICHes.Where(s => s.TRANGTHAI == 0)
                                where a.Id == Id
                                select new ThongTinDuLichInfo()
                                {
                                    Id = a.Id,
                                    TIEUDE = a.TIEUDE,
                                    NOIDUNG = a.NOIDUNG,
                                    MOTA = a.MOTA,
                                    HINHANH = a.HINHANH,
                                    NGUOITAO = a.NGUOITAO,
                                    NGUOISUA = a.NGUOISUA,
                                    TRANGTHAI = a.TRANGTHAI.Value
                                }
                        ).FirstOrDefault();
            return data;
        }
    }
}
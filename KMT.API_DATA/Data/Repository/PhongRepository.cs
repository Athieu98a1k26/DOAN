using KMT.DATA_MODEL.Phong;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KMT.API_DATA.Data.Repository
{
    public class PhongRepository : BaseRepository
    {
        public List<PhongInfo> GetAll()
        {
            var dataReturn = (from a in DbContext.PHONGs
                              select new PhongInfo
                              {
                                  Id = a.Id,
                                  BOPHANGUIDEN = a.BOPHANGUIDEN.Value,
                                  CHUNGMINHTHUNHANDAN = a.CHUNGMINHTHUNHANDAN,
                                  DIACHI = a.DIACHI,
                                  LOAIPHONG = a.LOAIPHONG.Value,
                                  EMAIL = a.EMAIL,
                                  GIOITINH = a.GIOITINH,
                                  HOTEN = a.HOTEN,
                                  NGAYDEN = a.NGAYDEN.Value,
                                  NGAYDI = a.NGAYDI.Value,
                                  NOIDUNG = a.NOIDUNG,
                                  QUOCTICH = a.QUOCTICH,
                                  SODIENTHOAI = a.SODIENTHOAI,
                                  SOKHACH = a.SOKHACH.Value

                              }).ToList() ?? new List<PhongInfo>();
            return dataReturn;
        }

        public int AddOrUpdate(PhongInfo model)
        {

            if (model.Id == 0)
            {
                //them mới
                PHONG oPHONGs = new PHONG();

                oPHONGs.BOPHANGUIDEN = model.BOPHANGUIDEN;
                oPHONGs.CHUNGMINHTHUNHANDAN = model.CHUNGMINHTHUNHANDAN;
                oPHONGs.DIACHI = model.DIACHI;
                oPHONGs.LOAIPHONG = model.LOAIPHONG;
                oPHONGs.EMAIL = model.EMAIL;
                oPHONGs.GIOITINH = model.GIOITINH;
                oPHONGs.HOTEN = model.HOTEN;
                oPHONGs.NGAYDEN = model.NGAYDEN;
                oPHONGs.NGAYDI = model.NGAYDI;
                oPHONGs.NOIDUNG = model.NOIDUNG;
                oPHONGs.QUOCTICH = model.QUOCTICH;
                oPHONGs.SODIENTHOAI = model.SODIENTHOAI;
                oPHONGs.SOKHACH = model.SOKHACH;
                DbContext.PHONGs.Add(oPHONGs);
                return DbContext.SaveChanges();
            }
            else
            {
                //cập nhật
                var data = DbContext.PHONGs.FirstOrDefault(s => s.Id == model.Id);
                data.LOAIPHONG = model.LOAIPHONG;
                return DbContext.SaveChanges();
            }
        }

        public PhongResponse search(PhongRequest model)
        {
            int skip = (model.page * model.take) - model.take;
            PhongResponse dt = new PhongResponse();
            List<PhongInfo> q = (from a in DbContext.PHONGs
                                 where
                                 (!model.LOAIPHONG.HasValue || a.LOAIPHONG == model.LOAIPHONG.Value)
                                 select new PhongInfo()
                                 {
                                     Id = a.Id,
                                     BOPHANGUIDEN = a.BOPHANGUIDEN.Value,
                                     CHUNGMINHTHUNHANDAN = a.CHUNGMINHTHUNHANDAN,
                                     DIACHI = a.DIACHI,
                                     LOAIPHONG = a.LOAIPHONG.Value,
                                     EMAIL = a.EMAIL,
                                     GIOITINH = a.GIOITINH,
                                     HOTEN = a.HOTEN,
                                     NGAYDEN = a.NGAYDEN.Value,
                                     NGAYDI = a.NGAYDI.Value,
                                     NOIDUNG = a.NOIDUNG,
                                     QUOCTICH = a.QUOCTICH,
                                     SODIENTHOAI = a.SODIENTHOAI,
                                     SOKHACH = a.SOKHACH.Value
                                 }).ToList() ?? new List<PhongInfo>();

            dt.total = q.Count();
            dt.data = q.Skip(skip).Take(model.take).ToList();
            dt.page = model.page;
            dt.take = model.take;
            return dt;
        }

        public int Delete(int Id)
        {
            var data = DbContext.PHONGs.FirstOrDefault(s => s.Id == Id);
            return DbContext.SaveChanges();
        }

        public PhongInfo GetById(int Id)
        {
            PhongInfo data = (from a in DbContext.PHONGs
                              where a.Id == Id
                              select new PhongInfo()
                              {
                                  Id = a.Id,
                                  BOPHANGUIDEN = a.BOPHANGUIDEN.Value,
                                  CHUNGMINHTHUNHANDAN = a.CHUNGMINHTHUNHANDAN,
                                  DIACHI = a.DIACHI,
                                  LOAIPHONG = a.LOAIPHONG.Value,
                                  EMAIL = a.EMAIL,
                                  GIOITINH = a.GIOITINH,
                                  HOTEN = a.HOTEN,
                                  NGAYDEN = a.NGAYDEN.Value,
                                  NGAYDI = a.NGAYDI.Value,
                                  NOIDUNG = a.NOIDUNG,
                                  QUOCTICH = a.QUOCTICH,
                                  SODIENTHOAI = a.SODIENTHOAI,
                                  SOKHACH = a.SOKHACH.Value
                              }
                        ).FirstOrDefault();
            return data;
        }
    }
}
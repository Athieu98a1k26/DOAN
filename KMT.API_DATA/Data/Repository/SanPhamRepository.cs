using KMT.DATA_MODEL.SanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.API_DATA.Data.Repository
{
    public class SanPhamRepository : BaseRepository
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

        public int AddOrUpdate(SanPhamInfo model)
        {

            if (model.Id == 0)
            {
                //them mới
                SANPHAM oSANPHAMs = new SANPHAM();
                oSANPHAMs.MOTA = model.MOTA;
                oSANPHAMs.GIA = model.GIA;
                oSANPHAMs.NGAYTAO = DateTime.Now;
                oSANPHAMs.IsDelete = false;
                DbContext.SANPHAMs.Add(oSANPHAMs);
                return DbContext.SaveChanges();
            }
            else
            {
                //cập nhật
                var data = DbContext.SANPHAMs.FirstOrDefault(s => s.Id == model.Id);
                data.MOTA = model.MOTA;
                data.GIA = model.GIA;
                data.NGAYSUA = DateTime.Now;
                data.IsDelete = false;
                return DbContext.SaveChanges();
            }
        }

        public SanPhamResponse search(SanPhamRequest model)
        {
            int skip = (model.page * model.take) - model.take;
            SanPhamResponse dt = new SanPhamResponse();
            List<SanPhamInfo> q = (from a in DbContext.SANPHAMs.Where(s => s.IsDelete == false)
                                   where
                                   (string.IsNullOrEmpty(model.TENMATHANG) || a.TENMATHANG.Contains(model.TENMATHANG))
                                   &&
                                   (!model.GIAMIN.HasValue || a.GIA >= model.GIAMIN.Value)
                                   &&
                                   (!model.GIAMAX.HasValue || a.GIA <= model.GIAMAX.Value)
                                   select new SanPhamInfo()
                                   {
                                       Id = a.Id,
                                       TENMATHANG = a.TENMATHANG,
                                       GIA = a.GIA.Value,
                                       HINHANH = a.HINHANH,
                                       MOTA = a.MOTA,
                                       NGAYSUA = (DateTime)a.NGAYSUA,
                                       NGAYTAO = (DateTime)a.NGAYTAO,
                                       IsDelete = (bool)a.IsDelete,
                                       NGUOISUA = a.NGUOISUA,
                                       NGUOITAO = a.NGUOITAO
                                   }).ToList() ?? new List<SanPhamInfo>();

            dt.total = q.Count();
            dt.data = q.Skip(skip).Take(model.take).ToList();
            dt.page = model.page;
            dt.take = model.take;
            return dt;
        }

        public int Delete(int Id)
        {
            var data = DbContext.SANPHAMs.FirstOrDefault(s => s.Id == Id);
            data.IsDelete = true;
            return DbContext.SaveChanges();
        }

        public SanPhamInfo GetById(int Id)
        {
            SanPhamInfo data = (from a in DbContext.SANPHAMs.Where(s => s.IsDelete == false)
                        where a.Id == Id
                        select new SanPhamInfo()
                        {
                            Id = a.Id,
                            TENMATHANG = a.TENMATHANG,
                            GIA = a.GIA.Value,
                            HINHANH = a.HINHANH,
                            MOTA = a.MOTA,
                            NGAYSUA = (DateTime)a.NGAYSUA,
                            NGAYTAO = (DateTime)a.NGAYTAO,
                            IsDelete = (bool)a.IsDelete,
                            NGUOISUA = a.NGUOISUA,
                            NGUOITAO = a.NGUOITAO
                        }
                        ).FirstOrDefault();
            return data;
        }
    }
}
using KMT.DATA_MODEL.BinhLuan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.API_DATA.Data.Repository
{
    public class BinhLuanRepository : BaseRepository
    {
        public List<BinhLuanInfo> GetAll()
        {
            List<BinhLuanInfo> dataReturn = (from a in DbContext.BINHLUANs
                                                   select new BinhLuanInfo
                                                   {
                                                       Id = a.Id,
                                                       IDSANPHAM = a.IDSANPHAM.Value,
                                                       NOIDUNG = a.NOIDUNG,
                                                       NGUOITAO = a.NGUOITAO,
                                                       NGAYTAO = a.NGAYTAO.Value,
                                                       NGUOISUA = a.NGUOISUA,
                                                       NGAYSUA = a.NGAYSUA.Value,
                                                       IDUSER = a.IDUSER.Value,
                                                       IsDelete = a.IsDelete.Value
                                                   }).ToList() ?? new List<BinhLuanInfo>();
            return dataReturn;
        }

        public int AddOrUpdate(BinhLuanInfo model)
        {

            if (model.Id == 0)
            {
                //them mới
                BINHLUAN oBINHLUANs = new BINHLUAN();
                oBINHLUANs.IDSANPHAM = model.IDSANPHAM;
                oBINHLUANs.NGUOITAO = model.NGUOITAO;
                oBINHLUANs.NOIDUNG = model.NOIDUNG;
                oBINHLUANs.IDUSER = model.IDUSER;
                oBINHLUANs.NGAYTAO = model.NGAYTAO;
                oBINHLUANs.IsDelete = false;
                DbContext.BINHLUANs.Add(oBINHLUANs);
                return DbContext.SaveChanges();
            }
            else
            {
                //cập nhật
                var data = DbContext.BINHLUANs.FirstOrDefault(s => s.Id == model.Id);
                data.IDSANPHAM = model.IDSANPHAM;
                data.NGUOISUA = model.NGUOISUA;
                data.NOIDUNG = model.NOIDUNG;
                data.IDUSER = model.IDUSER;
                data.NGAYSUA = model.NGAYSUA;
                data.IsDelete = false;
                return DbContext.SaveChanges();
            }
        }

        public BinhLuanResponse search(BinhLuanRequest model)
        {
            int skip = (model.page * model.take) - model.take;
            BinhLuanResponse dt = new BinhLuanResponse();
            List<BinhLuanInfo> q = (from a in DbContext.BINHLUANs.Where(s => s.IsDelete == false)
                                          where
                                          (string.IsNullOrEmpty(model.NOIDUNG) || a.NOIDUNG.Contains(model.NOIDUNG)) &&
                                          (!model.IsDelete.HasValue || a.IsDelete == model.IsDelete) &&
                                          (!model.IDUSER.HasValue || a.IDUSER == model.IDUSER)
                                          select new BinhLuanInfo()
                                          {
                                              Id = a.Id,
                                              IDSANPHAM = a.IDSANPHAM.Value,
                                              NOIDUNG = a.NOIDUNG,
                                              NGUOITAO = a.NGUOITAO,
                                              NGAYTAO = a.NGAYTAO.Value,
                                              NGUOISUA = a.NGUOISUA,
                                              NGAYSUA = a.NGAYSUA.Value,
                                              IDUSER = a.IDUSER.Value,
                                              IsDelete = a.IsDelete.Value
                                          }).ToList() ?? new List<BinhLuanInfo>();

            dt.total = q.Count();
            dt.data = q.Skip(skip).Take(model.take).ToList();
            dt.page = model.page;
            dt.take = model.take;
            return dt;
        }

        public int Delete(int Id)
        {
            var data = DbContext.BINHLUANs.FirstOrDefault(s => s.Id == Id);
            data.IsDelete = true;
            return DbContext.SaveChanges();
        }

        public BinhLuanInfo GetById(int Id)
        {
            BinhLuanInfo data = (from a in DbContext.BINHLUANs.Where(s => s.IsDelete == false)
                                       where a.Id == Id
                                       select new BinhLuanInfo()
                                       {
                                           Id = a.Id,
                                           IDSANPHAM = a.IDSANPHAM.Value,
                                           NOIDUNG = a.NOIDUNG,
                                           NGUOITAO = a.NGUOITAO,
                                           NGAYTAO = a.NGAYTAO.Value,
                                           NGUOISUA = a.NGUOISUA,
                                           NGAYSUA = a.NGAYSUA.Value,
                                           IDUSER = a.IDUSER.Value,
                                           IsDelete = a.IsDelete.Value
                                       }
                        ).FirstOrDefault();
            return data;
        }
    }
}
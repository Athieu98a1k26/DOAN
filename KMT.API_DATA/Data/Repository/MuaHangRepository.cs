using KMT.DATA_MODEL.MuaHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.API_DATA.Data.Repository
{
    public class MuaHangRepository : BaseRepository
    {
        public List<MuaHangInfo> GetAll()
        {
            List<MuaHangInfo> dataReturn = (from a in DbContext.BINHLUANs
                                             select new MuaHangInfo
                                             {
                                                 Id = a.Id,
                                                 IDSANPHAM = a.IDSANPHAM.Value,
                                                 IDUSER = a.IDUSER.Value,
                                                 NGUOITAO = a.NGUOITAO,
                                                 NGAYTAO = a.NGAYTAO.Value,
                                                 NGUOISUA = a.NGUOISUA,
                                                 NGAYSUA = a.NGAYSUA.Value
                                             }).ToList() ?? new List<MuaHangInfo>();
            return dataReturn;
        }

        public int AddOrUpdate(MuaHangInfo model)
        {

            if (model.Id == 0)
            {
                //them mới
                BINHLUAN oBINHLUANs = new BINHLUAN();
                oBINHLUANs.IDSANPHAM = model.IDSANPHAM;
                oBINHLUANs.NGUOITAO = model.NGUOITAO;
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
                data.IDUSER = model.IDUSER;
                data.NGAYSUA = model.NGAYSUA;
                data.IsDelete = false;
                return DbContext.SaveChanges();
            }
        }

        public MuaHangResponse search(MuaHangRequest model)
        {
            int skip = (model.page * model.take) - model.take;
            MuaHangResponse dt = new MuaHangResponse();
            List<MuaHangInfo> q = (from a in DbContext.BINHLUANs.Where(s => s.IsDelete == false)
                                    where
                                    (!model.IDSanPham.HasValue || a.IDSANPHAM == model.IDSanPham) &&
                                    (!model.IDUSER.HasValue || a.IDUSER == model.IDUSER)
                                    select new MuaHangInfo()
                                    {
                                        Id = a.Id,
                                        IDSANPHAM = a.IDSANPHAM.Value,
                                        NGUOITAO = a.NGUOITAO,
                                        NGAYTAO = a.NGAYTAO.Value,
                                        NGUOISUA = a.NGUOISUA,
                                        NGAYSUA = a.NGAYSUA.Value,
                                        IDUSER = a.IDUSER.Value
                                    }).ToList() ?? new List<MuaHangInfo>();

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

        public MuaHangInfo GetById(int Id)
        {
            MuaHangInfo data = (from a in DbContext.BINHLUANs.Where(s => s.IsDelete == false)
                                 where a.Id == Id
                                 select new MuaHangInfo()
                                 {
                                     Id = a.Id,
                                     IDSANPHAM = a.IDSANPHAM.Value,
                                     IDUSER = a.IDUSER.Value,
                                     NGUOITAO = a.NGUOITAO,
                                     NGAYTAO = a.NGAYTAO.Value,
                                     NGUOISUA = a.NGUOISUA,
                                     NGAYSUA = a.NGAYSUA.Value
                                 }
                        ).FirstOrDefault();
            return data;
        }
    }
}
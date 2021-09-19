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
            List<MuaHangInfo> dataReturn = (from a in DbContext.MUAHANGs
                                             select new MuaHangInfo
                                             {
                                                 Id = a.Id,
                                                 IDSANPHAM = a.IDSANPHAM.Value,
                                                 IDUSER = a.IDUSER.Value,
                                                 NGUOITAO = a.NGUOITAO,
                                                 NGAYTAO = a.NGAYTAO,
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
                MUAHANG oMUAHANGs = new MUAHANG();
                oMUAHANGs.IDSANPHAM = model.IDSANPHAM;
                oMUAHANGs.NGUOITAO = model.NGUOITAO;
                oMUAHANGs.IDUSER = model.IDUSER;
                oMUAHANGs.NGAYTAO = model.NGAYTAO;
                DbContext.MUAHANGs.Add(oMUAHANGs);
                return DbContext.SaveChanges();
            }
            else
            {
                //cập nhật
                var data = DbContext.MUAHANGs.FirstOrDefault(s => s.Id == model.Id);
                data.IDSANPHAM = model.IDSANPHAM;
                data.NGUOISUA = model.NGUOISUA;
                data.IDUSER = model.IDUSER;
                data.NGAYSUA = model.NGAYSUA;
                return DbContext.SaveChanges();
            }
        }

        public MuaHangResponse search(MuaHangRequest model)
        {
            int skip = (model.page * model.take) - model.take;
            MuaHangResponse dt = new MuaHangResponse();
            List<MuaHangInfo> q = (from a in DbContext.MUAHANGs
                                    where
                                    (!model.IDSanPham.HasValue || a.IDSANPHAM == model.IDSanPham) &&
                                    (!model.IDUSER.HasValue || a.IDUSER == model.IDUSER)
                                    select new MuaHangInfo()
                                    {
                                        Id = a.Id,
                                        IDSANPHAM = a.IDSANPHAM.Value,
                                        NGUOITAO = a.NGUOITAO,
                                        NGAYTAO = a.NGAYTAO,
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
            var data = DbContext.MUAHANGs.FirstOrDefault(s => s.Id == Id);
            return DbContext.SaveChanges();
        }

        public MuaHangInfo GetById(int Id)
        {
            MuaHangInfo data = (from a in DbContext.MUAHANGs
                                 where a.Id == Id
                                 select new MuaHangInfo()
                                 {
                                     Id = a.Id,
                                     IDSANPHAM = a.IDSANPHAM.Value,
                                     IDUSER = a.IDUSER.Value,
                                     NGUOITAO = a.NGUOITAO,
                                     NGAYTAO = a.NGAYTAO,
                                     NGUOISUA = a.NGUOISUA,
                                     NGAYSUA = a.NGAYSUA.Value
                                 }).FirstOrDefault();
            return data;
        }
    }
}
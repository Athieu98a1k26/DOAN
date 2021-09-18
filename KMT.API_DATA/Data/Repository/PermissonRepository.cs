using KMT.DATA_MODEL;
using KMT.DATA_MODEL.Permisson;
using KMT.DATA_MODEL.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.API_DATA.Data.Repository
{
    public class PermissonRepository : BaseRepository
    {
        public int AddOrUpdate(PermissonRequest model)
        {
            if (IsDuplicate(model.MAQUYEN))
            {
                return 0;
            }
            if (model.Id==0)
            {
                //them mới
                PERMISSION per = new PERMISSION();
                per.TENQUYEN = model.TENQUYEN;
                per.MAQUYEN = model.MAQUYEN;
                per.NGAYTAO = DateTime.Now;
                per.IsDelete = false;
                DbContext.PERMISSIONs.Add(per);
                return DbContext.SaveChanges();
            }
            else
            {
                //cập nhật
                var data = DbContext.Roles.FirstOrDefault(s => s.Id == model.Id);
                data.TEN = model.TENQUYEN;
                data.MA = model.MAQUYEN;
                data.IsDelete = false;
                data.NGAYSUA = DateTime.Now;
                return DbContext.SaveChanges();
            }
        }

        public bool IsDuplicate(string MAQUYEN)
        {
            int count = DbContext.PERMISSIONs.Count(s => s.MAQUYEN == MAQUYEN && s.IsDelete==false);
            if (count==0)
            {
                return false;
            }
            return true;
        }

        public PermissonResponse search(PermissonRequest model)
        {
            int skip = (model.page * model.take) - model.take;
            PermissonResponse dt = new PermissonResponse();
            var q = (from x in DbContext.PERMISSIONs
                     where x.IsDelete==false
                    select new PermissonInfo() { 
                        Id=x.Id,
                        TENQUYEN=x.TENQUYEN,
                        MAQUYEN=x.MAQUYEN
                    }).ToList()??new List<PermissonInfo>();

            dt.total = q.Count();
            dt.data = q.Skip(skip).Take(model.take).ToList();
            dt.page = model.page;
            dt.take = model.take;
            return dt;
        }
    }
}
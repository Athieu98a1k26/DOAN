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
            
            if (model.Id==0)
            {
                if (IsDuplicate(model.MAQUYEN))
                {
                    return 0;
                }
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
                var data = DbContext.PERMISSIONs.FirstOrDefault(s => s.Id == model.Id);
                data.TENQUYEN = model.TENQUYEN;
                if (data.MAQUYEN != model.MAQUYEN)
                {
                    if (IsDuplicate(model.MAQUYEN))
                    {
                        return 0;
                    }
                    int count = DbContext.ROLE_PERMISSON.Count(s => s.PERMISSON.Contains("," + model.Id + ",") && s.IsDelete == false);
                    if (count > 0)
                    {
                        return 0;
                    }
                }
                data.MAQUYEN = model.MAQUYEN;
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

        public int Delete(int Id)
        {
            //kiểm tra có quyền xóa
            int count = DbContext.ROLE_PERMISSON.Count(s => s.PERMISSON.Contains("," + Id + ",") && s.IsDelete==false);
            if (count > 0)
            {
                return 0;
            }
            var data = DbContext.PERMISSIONs.FirstOrDefault(s => s.Id == Id);

            data.IsDelete = true;
            return DbContext.SaveChanges();
        }

        public PermissonInfo GetById(int Id)
        {
            var data = DbContext.PERMISSIONs.Where(s => s.Id == Id).Select(s => new PermissonInfo()
            {
                Id = s.Id,
                TENQUYEN = s.TENQUYEN,
                MAQUYEN = s.MAQUYEN,

            }).FirstOrDefault();
            return data;
        }
    }
}

using KMT.DATA_MODEL.Permisson;
using KMT.DATA_MODEL.Role;
using KMT.DATA_MODEL.RolePermisson;
using KMT.Libraly.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.API_DATA.Data.Repository
{
    public class RolePermissonRepository : BaseRepository
    {
        public int AddOrUpdate(RolePermissonRequest model)
        {
            
            if (model.Id == 0)
            {
                if (IsDuplicate(model.ROLEID))
                {
                    return 0;
                }
                //them mới
                ROLE_PERMISSON rOLE_PERMISSON = new ROLE_PERMISSON();
                rOLE_PERMISSON.ROLEID = model.ROLEID;
                rOLE_PERMISSON.PERMISSON = model.PERMISSON;
                rOLE_PERMISSON.NGAYTAO = DateTime.Now;
                rOLE_PERMISSON.IsDelete = false;
                DbContext.ROLE_PERMISSON.Add(rOLE_PERMISSON);
                return DbContext.SaveChanges();
            }
            else
            {
                //cập nhật
                var data = DbContext.ROLE_PERMISSON.FirstOrDefault(s => s.Id == model.Id);
                if (data.ROLEID != model.ROLEID)
                {
                    if (IsDuplicate(model.ROLEID))
                    {
                        return 0;
                    }
                }
                data.ROLEID = model.ROLEID;
                data.PERMISSON = model.PERMISSON;
                data.NGAYSUA = DateTime.Now;
                data.IsDelete = false;
                return DbContext.SaveChanges();
            }
        }

        public bool IsDuplicate(int ROLEID)
        {
            int count = DbContext.ROLE_PERMISSON.Count(s => s.ROLEID == ROLEID && s.IsDelete == false);
            if (count == 0)
            {
                return false;
            }
            return true;
        }

        public RolePermissonResponse search(RolePermissonRequest model)
        {
            int skip = (model.page * model.take) - model.take;
            RolePermissonResponse dt = new RolePermissonResponse();
            var q = (from a in DbContext.ROLE_PERMISSON.Where(s => s.IsDelete == false)
                     join b in DbContext.Roles.Where(s => s.IsDelete == false) on a.ROLEID equals b.Id into bb
                     from bs in bb.DefaultIfEmpty()
                     select new RolePermissonInfo()
                     {
                         Id=a.Id,
                         ROLEID = a.ROLEID.Value,
                         PERMISSON = a.PERMISSON,
                         roleInfo = new RoleInfo() { Id = bs.Id, TEN = bs.TEN, MA = bs.MA },
                         lstPermissonInfo = (from c in DbContext.PERMISSIONs.Where(s => s.IsDelete == false && a.PERMISSON.Contains("," + s.Id + ",")) select new PermissonInfo()
                         {
                             Id = c.Id,
                             MAQUYEN = c.MAQUYEN,
                             TENQUYEN = c.TENQUYEN
                         }).ToList()


                     }
                        ).ToList()??new List<RolePermissonInfo>();

            dt.total = q.Count();
            dt.data = q.Skip(skip).Take(model.take).ToList();
            dt.page = model.page;
            dt.take = model.take;
            return dt;
        }

        public int Delete(int Id)
        {
            var data = DbContext.ROLE_PERMISSON.FirstOrDefault(s => s.Id == Id);
            data.IsDelete = true;
            return DbContext.SaveChanges();
        }

        public RolePermissonInfo GetById(int Id)
        {
            var data = (from a in DbContext.ROLE_PERMISSON.Where(s => s.IsDelete == false)
                        join b in DbContext.Roles.Where(s => s.IsDelete == false) on a.ROLEID equals b.Id into bb
                        from bs in bb.DefaultIfEmpty()
                        where a.Id==Id
                        select new RolePermissonInfo()
                        {
                            Id = a.Id,
                            ROLEID =a.ROLEID.Value,
                            PERMISSON=a.PERMISSON,
                            roleInfo=new RoleInfo() {Id=bs.Id,TEN=bs.TEN,MA=bs.MA },
                            lstPermissonInfo=DbContext.PERMISSIONs.Where(s=>s.IsDelete==false && a.PERMISSON.Contains("," + s.Id + ",")).Select(s=>new PermissonInfo() {
                                Id=s.Id,
                                MAQUYEN=s.MAQUYEN,
                                TENQUYEN=s.TENQUYEN
                            }).ToList()

                        }
                        ).FirstOrDefault();
            return data;
        }
    }
}
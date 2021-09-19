
using KMT.DATA_MODEL.MenuQuanTri;
using KMT.DATA_MODEL.PermissionMenu;
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
    public class PermissionMenuRepository : BaseRepository
    {
        public int AddOrUpdate(PermissionMenuRequest model)
        {
            
            if (model.Id == 0)
            {
                if (IsDuplicate(model.PERMISSIONID))
                {
                    return 0;
                }
                //them mới
                PERMISSION_MENUQUANTRI permissonMenu = new PERMISSION_MENUQUANTRI();
                permissonMenu.PERMISSIONID = model.PERMISSIONID;
                permissonMenu.MENU = model.MENU;
                permissonMenu.NGAYTAO = DateTime.Now;
                permissonMenu.IsDelete = false;
                DbContext.PERMISSION_MENUQUANTRI.Add(permissonMenu);
                return DbContext.SaveChanges();
            }
            else
            {
                //cập nhật
                var data = DbContext.PERMISSION_MENUQUANTRI.FirstOrDefault(s => s.Id == model.Id);
                if (data.PERMISSIONID != model.PERMISSIONID)
                {
                    if (IsDuplicate(model.PERMISSIONID))
                    {
                        return 0;
                    }
                }
                data.PERMISSIONID = model.PERMISSIONID;
                data.MENU = model.MENU;
                data.NGAYSUA = DateTime.Now;
                data.IsDelete = false;
                return DbContext.SaveChanges();
            }
        }

        public bool IsDuplicate(int PERMISSIONID)
        {
            int count = DbContext.PERMISSION_MENUQUANTRI.Count(s => s.PERMISSIONID == PERMISSIONID && s.IsDelete == false);
            if (count == 0)
            {
                return false;
            }
            return true;
        }

        public PermissionMenuResponse search(PermissionMenuRequest model)
        {
            int skip = (model.page * model.take) - model.take;
            PermissionMenuResponse dt = new PermissionMenuResponse();
            var q = (from a in DbContext.PERMISSION_MENUQUANTRI.Where(s => s.IsDelete == false)
                     join b in DbContext.PERMISSIONs.Where(s => s.IsDelete == false) on a.PERMISSIONID equals b.Id into bb
                     from bs in bb.DefaultIfEmpty()
                     select new PermissionMenuInfo()
                     {
                         Id=a.Id,
                         PERMISSIONID = a.PERMISSIONID.Value,
                         MENU = a.MENU,
                         PermissionInfo = new PermissonInfo() { Id = bs.Id,TENQUYEN  = bs.TENQUYEN, MAQUYEN = bs.MAQUYEN },
                         lstMenuQuanTriInfo = (from c in DbContext.MENUQUANTRIs.Where(s =>  a.MENU.Contains("," + s.Id + ",")) select new MenuQuanTriInfo()
                         {
                             Id = c.Id,
                             NAME = c.NAME,
                             URL = c.URL
                         }).ToList()


                     }
                        ).ToList()??new List<PermissionMenuInfo>();

            dt.total = q.Count();
            dt.data = q.Skip(skip).Take(model.take).ToList();
            dt.page = model.page;
            dt.take = model.take;
            return dt;
        }

        public int Delete(int Id)
        {
            var data = DbContext.PERMISSION_MENUQUANTRI.FirstOrDefault(s => s.Id == Id && s.IsDelete == false);
            data.IsDelete = true;
            return DbContext.SaveChanges();
        }

        public PermissionMenuInfo GetById(int Id)
        {
            var data = (from a in DbContext.PERMISSION_MENUQUANTRI.Where(s => s.IsDelete == false)
                        join b in DbContext.PERMISSIONs.Where(s => s.IsDelete == false) on a.PERMISSIONID equals b.Id into bb
                        from bs in bb.DefaultIfEmpty()
                        where a.Id == Id
                        select new PermissionMenuInfo()
                        {
                            Id = a.Id,
                            PERMISSIONID = a.PERMISSIONID.Value,
                            MENU = a.MENU,
                            PermissionInfo = new PermissonInfo() { Id = bs.Id, TENQUYEN = bs.TENQUYEN, MAQUYEN = bs.MAQUYEN },
                            lstMenuQuanTriInfo = (from c in DbContext.MENUQUANTRIs.Where(s => a.MENU.Contains("," + s.Id + ","))
                                                  select new MenuQuanTriInfo()
                                                  {
                                                      Id = c.Id,
                                                      NAME = c.NAME,
                                                      URL = c.URL
                                                  }).ToList()


                        }
                        ).FirstOrDefault();
            return data;
        }
    }
}
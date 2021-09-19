
using KMT.DATA_MODEL.Permisson;
using KMT.DATA_MODEL.Role;
using KMT.DATA_MODEL.RolePermisson;
using KMT.DATA_MODEL.UserRole;
using KMT.DATA_MODEL.Users;
using KMT.Libraly.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.API_DATA.Data.Repository
{
    public class UserRoleRepository : BaseRepository
    {
        public int AddOrUpdate(UserRoleRequest model)
        {
            
            if (model.Id == 0)
            {
                if (IsDuplicate(model.USERID))
                {
                    return 0;
                }
                //them mới
                USER_ROLE  u = new USER_ROLE();
                u.ROLE = model.ROLE;
                u.USERID = model.USERID;
                u.NGAYTAO = DateTime.Now;
                u.IsDelete = false;
                DbContext.USER_ROLE.Add(u);
                return DbContext.SaveChanges();
            }
            else
            {
                //cập nhật
                var data = DbContext.USER_ROLE.FirstOrDefault(s => s.Id == model.Id);
                if (data.USERID != model.USERID)
                {
                    if (IsDuplicate(model.USERID))
                    {
                        return 0;
                    }
                }
                data.ROLE = model.ROLE;
                data.USERID = model.USERID;
                data.NGAYSUA = DateTime.Now;
                data.IsDelete = false;
                return DbContext.SaveChanges();
            }
        }

        public bool IsDuplicate(int USERID)
        {
            int count = DbContext.USER_ROLE.Count(s => s.USERID == USERID && s.IsDelete == false);
            if (count == 0)
            {
                return false;
            }
            return true;
        }

        public UserRoleResponse search(UserRoleRequest model)
        {
            int skip = (model.page * model.take) - model.take;
            UserRoleResponse dt = new UserRoleResponse();
            var q = (from a in DbContext.USER_ROLE.Where(s => s.IsDelete == false)
                     join b in DbContext.Users.Where(s => s.IsDelete == false) on a.USERID equals b.Id into bb
                     from bs in bb.DefaultIfEmpty()
                     select new UserRoleInfo()
                     {
                         Id=a.Id,
                         USERID = a.USERID.Value,
                         ROLE = a.ROLE,
                         UserInfo = new UserInfo() { Id = bs.Id, Name = bs.Name, UserName = bs.UserName },
                         lstRoleInfo = (from c in DbContext.Roles.Where(s => s.IsDelete == false && a.ROLE.Contains("," + s.Id + ",")) select new RoleInfo()
                         {
                             Id = c.Id,
                             MA = c.MA,
                             TEN = c.TEN
                         }).ToList()


                     }
                        ).ToList()??new List<UserRoleInfo>();

            dt.total = q.Count();
            dt.data = q.Skip(skip).Take(model.take).ToList();
            dt.page = model.page;
            dt.take = model.take;
            return dt;
        }

        public int Delete(int Id)
        {
            var data = DbContext.USER_ROLE.FirstOrDefault(s => s.Id == Id && s.IsDelete == false);
            data.IsDelete = true;
            return DbContext.SaveChanges();
        }

        public UserRoleInfo GetById(int Id)
        {
            var data = (from a in DbContext.USER_ROLE.Where(s => s.IsDelete == false)
                        join b in DbContext.Users.Where(s => s.IsDelete == false) on a.USERID equals b.Id into bb
                        from bs in bb.DefaultIfEmpty()
                        where a.Id==Id
                        select new UserRoleInfo()
                        {
                            Id = a.Id,
                            USERID = a.USERID.Value,
                            ROLE = a.ROLE,
                            UserInfo = new UserInfo() { Id = bs.Id, Name = bs.Name, UserName = bs.UserName },
                            lstRoleInfo = (from c in DbContext.Roles.Where(s => s.IsDelete == false && a.ROLE.Contains("," + s.Id + ","))
                                           select new RoleInfo()
                                           {
                                               Id = c.Id,
                                               MA = c.MA,
                                               TEN = c.TEN
                                           }).ToList()


                        }
                        ).FirstOrDefault();
            return data;
        }
    }
}
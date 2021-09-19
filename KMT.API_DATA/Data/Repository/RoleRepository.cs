using KMT.DATA_MODEL;
using KMT.DATA_MODEL.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.API_DATA.Data.Repository
{
    public class RoleRepository: BaseRepository
    {
        public int AddOrUpdate(RoleRequest model)
        {
            
            if (model.Id==0)
            {
                if (IsDuplicate(model.MA))
                {
                    return 0;
                }
                //them mới
                Role role = new Role();
                role.TEN = model.TEN;
                role.MA = model.MA;
                role.NGAYTAO = DateTime.Now;
                role.IsDelete = false;
                DbContext.Roles.Add(role);
                return DbContext.SaveChanges();
            }
            else
            {
                //cập nhật
                var data = DbContext.Roles.FirstOrDefault(s => s.Id == model.Id);
                data.TEN = model.TEN;
                
                if (data.MA!= model.MA)
                {
                    if (IsDuplicate(model.MA))
                    {
                        return 0;
                    }
                    int count = DbContext.ROLE_PERMISSON.Count(s => s.ROLEID == model.Id && s.IsDelete == false);
                    if (count > 0)
                    {
                        return 0;
                    }
                    count = DbContext.USER_ROLE.Count(s => s.ROLE.Contains("," + model.Id + ",") && s.IsDelete == false);
                    if (count > 0)
                    {
                        return 0;
                    }
                }
                data.MA = model.MA;
                data.NGAYSUA = DateTime.Now;
                data.IsDelete = false;
                return DbContext.SaveChanges();
            }
        }

        public bool IsDuplicate(string MA)
        {
            int count = DbContext.Roles.Count(s => s.MA == MA && s.IsDelete==false);
            if (count==0)
            {
                return false;
            }
            return true;
        }

        public RoleResponse search(RoleRequest model)
        {
            int skip = (model.page * model.take) - model.take;
            RoleResponse dt = new RoleResponse();
            var q = (from x in DbContext.Roles
                     where x.IsDelete==false
                    select new RoleInfo() { 
                        Id=x.Id,
                        TEN=x.TEN,
                        MA=x.MA
                    }).ToList()??new List<RoleInfo>();

            dt.total = q.Count();
            dt.data = q.Skip(skip).Take(model.take).ToList();
            dt.page = model.page;
            dt.take = model.take;
            return dt;
        }

        public int Delete(int Id)
        {
            //kiểm tra có quyền xóa
            int count=DbContext.ROLE_PERMISSON.Count(s => s.ROLEID == Id && s.IsDelete == false);
            if (count > 0)
            {
                return 0;
            }
            count = DbContext.USER_ROLE.Count(s => s.ROLE.Contains(","+ Id+",") && s.IsDelete == false);
            if (count > 0)
            {
                return 0;
            }
            var data = DbContext.Roles.FirstOrDefault(s => s.Id == Id);

            data.IsDelete = true;
            return DbContext.SaveChanges();
        }

        public RoleInfo GetById(int Id)
        {
            var data = DbContext.Roles.Where(s => s.Id == Id).Select(s => new RoleInfo()
            {
                Id = s.Id,
                TEN = s.TEN,
                MA = s.MA,

            }).FirstOrDefault();
            return data;
        }

    }
}
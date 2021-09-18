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
                //them mới
                if (IsDuplicate(model.MA))
                {
                    return 0;
                }
                else
                {
                    Role role = new Role();
                    role.TEN = model.TEN;
                    role.MA = model.MA;
                    role.NGAYTAO = DateTime.Now;
                    DbContext.Roles.Add(role);
                    return DbContext.SaveChanges();
                }
            }
            else
            {
                //cập nhật
                var data = DbContext.Roles.FirstOrDefault(s => s.Id == model.Id);
                data.TEN = model.TEN;
                data.MA = model.MA;
                data.NGAYSUA = DateTime.Now;
                return DbContext.SaveChanges();
            }
        }

        public bool IsDuplicate(string MA)
        {
            int count = DbContext.Roles.Count(s => s.MA == MA);
            if (count==0)
            {
                return false;
            }
            return true;
        }

        
    }
}
using KMT.DATA_MODEL.Users;
using KMT.Libraly.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.API_DATA.Data.Repository
{
    public class UserRepository:BaseRepository
    {
        public int GetCountByUserName(string UserName)
        {
            return DbContext.Users.Count(s => s.UserName == UserName && s.IsDelete==false);
        }
        public int AddOrUpdate(UserRequest model)
        {
            
            if (model.Id == 0)
            {
                if (IsDuplicate(model.UserName))
                {
                    return 0;
                }
                //them mới
                User user = new User();
                user.UserName = model.UserName;
                user.Name = model.Name;
                user.PassWord = Encryption.EncryptPassword(model.PassWord);
                user.NgayTao = DateTime.Now;
                user.IsDelete = false;
                DbContext.Users.Add(user);
                return DbContext.SaveChanges();
            }
            else
            {
                //cập nhật
                var data = DbContext.Users.FirstOrDefault(s => s.Id == model.Id);
                if (data.UserName!= model.UserName)
                {
                    if (IsDuplicate(model.UserName))
                    {
                        return 0;
                    }
                    int count = DbContext.USER_ROLE.Count(s => s.USERID == model.Id && s.IsDelete == false);
                    if (count > 0)
                    {
                        return 0;
                    }
                }
                data.UserName = model.UserName;

                data.Name = model.Name;
                data.PassWord = Encryption.EncryptPassword(model.PassWord);
                data.NgaySua = DateTime.Now;
                data.IsDelete = false;
                return DbContext.SaveChanges();
            }
        }

        public bool IsDuplicate(string UserName)
        {
            int count = DbContext.Users.Count(s => s.UserName == UserName && s.IsDelete == false);
            if (count == 0)
            {
                return false;
            }
            return true;
        }

        public UserResponse search(UserRequest model)
        {
            int skip = (model.page * model.take) - model.take;
            UserResponse dt = new UserResponse();
            var q = (from x in DbContext.Users
                     where x.IsDelete == false
                     select new UserInfo()
                     {
                         Id = x.Id,
                         Name = x.Name,
                         UserName = x.UserName,

                     }).ToList() ?? new List<UserInfo>();

            dt.total = q.Count();
            dt.data = q.Skip(skip).Take(model.take).ToList();
            dt.page = model.page;
            dt.take = model.take;
            return dt;
        }

        public int Delete(int Id)
        {
            int count = DbContext.USER_ROLE.Count(s => s.USERID == Id && s.IsDelete == false);
            if (count > 0)
            {
                return 0;
            }
            var data = DbContext.Users.FirstOrDefault(s => s.Id == Id);
            data.IsDelete = true;
            return DbContext.SaveChanges();
        }

        public UserInfo GetById(int Id)
        {
            var data = DbContext.Users.Where(s => s.Id == Id).Select(s=>new UserInfo() { 
                Id=s.Id,
                Name=s.Name,
                UserName=s.UserName,

            }).FirstOrDefault();
            return data;
        }
    }
}
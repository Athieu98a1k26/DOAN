using KMT.DATA_MODEL.MenuQuanTri;
using KMT.DATA_MODEL.Permisson;
using KMT.DATA_MODEL.Role;
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
        //GetByUserName
        public UserInfo GetByUserName(string UserName)
        {
            var data = DbContext.Users.Where(s => s.UserName == UserName).Select(s => new UserInfo()
            {
                Id = s.Id,
                Name = s.Name,
                UserName = s.UserName,
                PassWord=s.PassWord

            }).FirstOrDefault();
            return data;
        }


        public UserInfo GetById(int Id)
        {
            var data = DbContext.Users.Where(s => s.Id == Id && s.IsDelete==false).Select(s=>new UserInfo() { 
                Id=s.Id,
                Name=s.Name,
                UserName=s.UserName,

            }).FirstOrDefault();
            return data;
        }

        public UserIdentity getUserIdentity(int Id)
        {
            UserIdentity userIdentity = new UserIdentity();
            userIdentity.userInfo = GetById(Id);

            USER_ROLE user_Role = DbContext.USER_ROLE.FirstOrDefault(s => s.USERID == Id && s.IsDelete==false);
            if (user_Role==null)
            {
                userIdentity.lstRole = null;
            }
            List<int> LstIdRole = user_Role.ROLE.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s=>int.Parse(s)).ToList();
            userIdentity.lstRole = DbContext.Roles.Where(s => LstIdRole.Contains(s.Id) && s.IsDelete == false).Select(s => new RoleInfo()
            {
                Id = s.Id,
                MA = s.MA,
                TEN = s.TEN
            }).ToList() ?? new List<RoleInfo>();

            if (userIdentity.lstRole.Count>0)
            {
                //lấy danh sách quyền
                List<ROLE_PERMISSON> LstRolePermission = DbContext.ROLE_PERMISSON.Where(s => LstIdRole.Contains(s.ROLEID.Value) && s.IsDelete == false).ToList();
                if (LstRolePermission!=null && LstRolePermission.Count>0)
                {
                    List<int> LstPermisson = new List<int>();
                    foreach (var item in LstRolePermission)
                    {
                        foreach (var per in item.PERMISSON.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries))
                        {
                            LstPermisson.Add(int.Parse(per));
                        }
                    }

                    userIdentity.lstPermission = DbContext.PERMISSIONs.Where(s => LstPermisson.Contains(s.Id) && s.IsDelete == false).Select(s => new PermissonInfo()
                    {
                        Id = s.Id,
                        MAQUYEN = s.MAQUYEN,
                        TENQUYEN = s.TENQUYEN
                    }).ToList() ?? new List<PermissonInfo>();


                    List<int> LstMenu = new List<int>();
                    var ListPermissionMenu = DbContext.PERMISSION_MENUQUANTRI.Where(s => LstPermisson.Contains(s.PERMISSIONID.Value) && s.IsDelete == false).ToList();
                    foreach (var item in ListPermissionMenu)
                    {
                        foreach (var menu in item.MENU.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            LstMenu.Add(int.Parse(menu));
                        }
                    }

                    userIdentity.lstMenuQuanTri = DbContext.MENUQUANTRIs.Where(s => LstMenu.Contains(s.Id) ).Select(s => new MenuQuanTriInfo()
                    {
                        Id = s.Id,
                        URL = s.URL,
                        NAME = s.NAME
                    }).ToList() ?? new List<MenuQuanTriInfo>();

                }
            }

            return userIdentity;
        }    
    }
}
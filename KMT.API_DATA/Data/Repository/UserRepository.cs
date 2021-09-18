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
            return DbContext.Users.Count(s => s.UserName == UserName);
        }
        
    }
}
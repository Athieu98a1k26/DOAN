using KMT.DATA_MODEL.Permisson;
using KMT.DATA_MODEL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace KMT.Admin
{
    public abstract class BaseViewPage : WebViewPage
    {
        
        public virtual UserInfo CurrentUser {
            get {
                UserIdentity userIdentity = (UserIdentity)Session["UserIdentity"];
                return userIdentity.userInfo;
            }
        }

        public virtual List<PermissonInfo> lstPermission
        {
            get
            {
                UserIdentity userIdentity = (UserIdentity)Session["UserIdentity"];
                return userIdentity.lstPermission;
            }
        }


    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual UserInfo CurrentUser
        {
            get
            {
                UserIdentity userIdentity = (UserIdentity)Session["UserIdentity"];
                return userIdentity.userInfo;
            }
        }


        public virtual List<PermissonInfo> lstPermission
        {
            get
            {
                UserIdentity userIdentity = (UserIdentity)Session["UserIdentity"];
                return userIdentity.lstPermission;
            }
        }
        //public virtual List<PermissionActionGetByPermissionIdAndUserIdResult> PermissionActions =>
        //    (List<PermissionActionGetByPermissionIdAndUserIdResult>)ViewData["PermissionActions"] ??
        //    new List<PermissionActionGetByPermissionIdAndUserIdResult>();

        //public virtual List<PermissionActionGetByPermissionIdAndUserIdResult> NavActivePages =>
        //    (List<PermissionActionGetByPermissionIdAndUserIdResult>)ViewData["NavActivePages"] ??
        //    new List<PermissionActionGetByPermissionIdAndUserIdResult>();

        //public bool CheckPermision(PageId page, params Action[] actions)
        //{
        //    if (CurrentUser != null && CurrentUser.UserName == "admin")
        //        return true;

        //    return PermissionActions.Any(x =>
        //        x.PageId == (int)page && actions.Any(action => (x.ActionKey & (byte)action) == (byte)action));
        //}

        //public bool CheckPermision(Action action, params PageId[] pages)
        //{
        //    if (CurrentUser != null && CurrentUser.UserName == "admin")
        //        return true;

        //    return PermissionActions.Any(x => pages.Any(page => x.PageId == (int)page) &&
        //                                      (x.ActionKey & (byte)action) == (byte)action);
        //}
    }
}
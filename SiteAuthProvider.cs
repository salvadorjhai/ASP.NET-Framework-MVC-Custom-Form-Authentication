using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ASPProject
{
    public class SiteAuthProvider : AuthorizeAttribute
    {

        private string _siteid;
        private string _permission;

        public SiteAuthProvider(string siteid="", string permission = "")
        {
            _siteid = siteid;
            _permission = permission;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // if not logged in
            var user = httpContext.User;
            if (!user.Identity.IsAuthenticated)
                return false;

            // check site id
            if (string.IsNullOrWhiteSpace(_siteid))
            {
                return true;
            }

            // check role, permission etc
            
            // 
            return UserList.user[user.Identity.Name].Contains(_siteid);
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
    }

    public static class PermissionProvider
    {
        public enum Permission
        {
            can_add,
            can_edit,
            can_delete,
            can_cancel,
            can_print,
            can_import,
            can_export,
            can_viewall,
            can_editall,
            can_level,
            can_return_level,
            lvl2,
            lvl3,
            lvl4,
            lvlothers,
            lvl2return,
            lvl3return,
            lvl4return,
            othersreturn
        }

        /// <summary>
        /// Check if permission is available from user
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static bool IsAllowed(this HtmlHelper helper, Permission permission)
        {
            // check if logged in
            var user = helper.ViewContext.HttpContext.User.Identity;
            if(!user.IsAuthenticated)
            {
                return false;
            }

            // check if given permission exists from user 
            // ...
            // ...
            return true; 
        }
    }
}
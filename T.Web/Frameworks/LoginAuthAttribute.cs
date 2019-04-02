using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T.Common.Tools;
using T.Web.Models;

namespace T.Web.Frameworks
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class LoginAuthAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (WebContext.Current == null || WebContext.Current.User == null)
            {
                var url = "/Home/Login";
                filterContext.Result = new RedirectResult(url, false);
            }
        }
    }
}
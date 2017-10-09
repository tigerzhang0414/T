using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T.Web.Models
{
    /// <summary>
    /// 当前信息
    /// </summary>
    public static class Current
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public static LoginUser LoginUser {
            get {
                if (HttpContext.Current == null)
                    return null;
                var context = HttpContext.Current.Items["CurrentLoginUser"] as LoginUser;
                return context;
            }
        }
    }

    /// <summary>
    /// 当前登录用户
    /// </summary>
    public class LoginUser
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NikiName { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
    }
}
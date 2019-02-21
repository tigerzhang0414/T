using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using T.Common.Entities;
using T.Common.Interface;

namespace T.Common.Tools
{
    public class WebContext
    {
        public static readonly object locker = new object();

        #region 当前登录用户
        private LoginUser _user;
        public LoginUser User
        {
            get { return _user; }
            private set { _user = value; }
        }
        #endregion

        public WebContext() { }

        #region 用户登录信息上下文
        public static WebContext Current
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;
                //获取Key
                var key = GetKey();
                //如果Key为空，返回空
                if (string.IsNullOrEmpty(key))
                    return null;
                //Key写入cookie
                KeyToCookie(key);

                //获取登录信息
                return GetContext(key);
            }
        }
        #endregion

        #region 登录Key
        /// <summary>
        /// 获取登录Key
        /// </summary>
        /// <returns></returns>
        public static string GetKey()
        {
            var key = HttpContext.Current.Request["key"];
            if (string.IsNullOrWhiteSpace(key))
            {
                var cookie = HttpContext.Current.Request.Cookies["loginuser"];
                if (cookie != null) key = cookie.Value;
            }
            else key = key.Trim();

            return key;
        }

        /// <summary>
        /// 获取缓存Key
        /// </summary>
        /// <param name="key">登录Key</param>
        /// <returns></returns>
        public static string CacheKey(string key)
        {
            if (!string.IsNullOrWhiteSpace(key)) return string.Format("cache_loginuser_{0}", key);
            return key;
        }
        #endregion

        #region 登录Cookie
        /// <summary>
        /// 将登录key写入cookie
        /// </summary>
        /// <param name="key">登录Key</param>
        public static void KeyToCookie(string key)
        {
            //创建Key的cookie
            var cookie = new HttpCookie("loginuser");
            cookie.Expires = DateTime.Now.AddMinutes(30);
            cookie.Value = key;
            HttpContext.Current.Response.Cookies.Add(cookie);
            //解决IE浏览器下面iframe里面跨域设置cookie的问题
            HttpContext.Current.Response.AddHeader("P3P", "CP=CAO PSA OUR");
        }
        #endregion

        #region 登录Context
        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <param name="key">登录key</param>
        /// <returns></returns>
        public static WebContext GetContext(string key)
        {
            //优先从缓存中获取
            var ckey = CacheKey(key);
            var cm = DependencyResolver.Current.GetService<ICacheManager>();
            if (cm.IsSet(ckey))
                return cm.Get<WebContext>(ckey);
            else return null;
        }

        /// <summary>
        /// 将用户信息写入缓存
        /// </summary>
        /// <param name="user">登录用户</param>
        /// <returns></returns>
        public static string SetContext(LoginUser user)
        {
            if (user == null) throw new Exception("用户不能为空！");
            // 生成Key
            var key = RandomStringManager.GetRandomString(6, true, true, true, true, null);
            var ckey = CacheKey(key);

            var cm = DependencyResolver.Current.GetService<ICacheManager>();
            //缓存登录信息
            var ctx = new WebContext();
            ctx.User = user;
            cm.Set(ckey, ctx, 60);
            //将key写入cookie
            KeyToCookie(key);
            return key;
        }
        #endregion
    }
}

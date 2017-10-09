using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T.Web.Frameworks;

namespace T.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 系统主页
        /// </summary>
        /// <returns></returns>
        [LoginAuth]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
    }
}
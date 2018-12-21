using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T.Web.Frameworks;
using T.Business.U;

namespace T.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserBusiness _userBusiness;                  //用户业务

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="userBusiness">用户业务</param>
        public HomeController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

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

        /// <summary>
        /// 登录请求
        /// </summary>
        /// <param name="account">帐号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UserLogin(string account, string password)
        {
            if (string.IsNullOrEmpty(account)) return Json(new { IsSuccess = false, Message = "帐号不能为空！" });
            if (string.IsNullOrEmpty(password)) return Json(new { IsSuccess = false, Message = "密码不能为空！" });
            var login_result = _userBusiness.Login(account, password);
            return Json(new { IsSuccess = login_result.Item1, Message = login_result.Item3 });
        }
    }
}
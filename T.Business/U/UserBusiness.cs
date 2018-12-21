using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.Dto.U;
using T.DB;
using T.Common.Extensions;
using T.ModelConverter.U;
using T.Enum.U;
using T.Common.Interface;

namespace T.Business.U
{
    public class UserBusiness : IDependency
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account">帐号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public (bool, LoginUser, string) Login(string account, string password)
        {

            var loginStatus = false;//登录状态
            LoginUser u = null;//登录用户
            string msg = string.Empty;//消息
            if (string.IsNullOrEmpty(account))
            {
                loginStatus = false;
                msg = "用户名不能为空！";
                return (loginStatus, u, msg);
            }
            if (string.IsNullOrEmpty(password))
            {
                loginStatus = false;
                msg = "密码不能为空！";
                return (loginStatus, u, msg);
            }
            var md5Password = password.ToMD5String();//MD5加密密码
            var dtx = new TDbContext();//数据库链接
            var db_LoginUser = dtx.U_LoginUser.FirstOrDefault(f => f.Account == account);
            if (db_LoginUser == null) { loginStatus = false; msg = "用户不存在！"; }//用户不存在
            else if (db_LoginUser.Password != md5Password) { loginStatus = false; msg = "密码错误！"; }//密码错误
            else if (db_LoginUser.Status == UserStatusEnum.Disable) { loginStatus = false; msg = "用户已禁用！"; }//用户已禁用
            else { loginStatus = true; u = db_LoginUser.ToBusinessModel(); msg = "登录成功！"; }//登录成功
            return (loginStatus, u, msg);
        }
    }
}

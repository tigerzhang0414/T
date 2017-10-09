using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.Dto.U;
using T.DB;

namespace T.ModelConverter.U
{
    /// <summary>
    /// 模型转换
    /// </summary>
    public static class LoginUserConverter
    {
        /// <summary>
        /// 转换为数据模型
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public static U_LoginUser ToDataModel(this LoginUser loginUser)
        {
            var u = new U_LoginUser();

            u.Id = loginUser.Id;
            u.Account = loginUser.Account;
            u.NikiName = loginUser.NikiName;
            u.RealName = loginUser.RealName;
            u.Email = loginUser.Email;
            u.Mobile = loginUser.Mobile;
            u.RegistTime = loginUser.RegistTime;
            u.RegistIp = loginUser.RegistIp;
            u.Status = loginUser.Status;
            u.LastLoginTime = loginUser.LastLoginTime;
            return u;
        }

        /// <summary>
        /// 转换为业务模型
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public static LoginUser ToBusinessModel(this U_LoginUser loginUser)
        {
            var u = new LoginUser();

            u.Id = loginUser.Id;
            u.Account = loginUser.Account;
            u.NikiName = loginUser.NikiName;
            u.RealName = loginUser.RealName;
            u.Email = loginUser.Email;
            u.Mobile = loginUser.Mobile;
            u.RegistTime = loginUser.RegistTime;
            u.RegistIp = loginUser.RegistIp;
            u.Status = loginUser.Status;
            u.LastLoginTime = loginUser.LastLoginTime;
            return u;
        }
    }
}

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
            return new U_LoginUser
            {
                Id              = loginUser.Id,
                Account         = loginUser.Account,
                NikiName        = loginUser.NikiName,
                RealName        = loginUser.RealName,
                Email           = loginUser.Email,
                Mobile          = loginUser.Mobile,
                RegistTime      = loginUser.RegistTime,
                RegistIp        = loginUser.RegistIp,
                Status          = loginUser.Status,
                LastLoginTime   = loginUser.LastLoginTime,
            };
        }

        /// <summary>
        /// 转换为业务模型
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public static T.Dto.U.LoginUser ToBusinessModel(this U_LoginUser loginUser)
        {
            return new LoginUser
            {
                Id              = loginUser.Id,
                Account         = loginUser.Account,
                NikiName        = loginUser.NikiName,
                RealName        = loginUser.RealName,
                Email           = loginUser.Email,
                Mobile          = loginUser.Mobile,
                RegistTime      = loginUser.RegistTime,
                RegistIp        = loginUser.RegistIp,
                Status          = loginUser.Status,
                LastLoginTime   = loginUser.LastLoginTime,
            };
        }

        public static T.Common.Entities.LoginUser ToWebContextModel(this T.Dto.U.LoginUser user)
        {
            return new T.Common.Entities.LoginUser
            {
                Id              = user.Id,
                Account         = user.Account,
                NikiName        = user.NikiName,
                RealName        = user.RealName,
                Email           = user.Email,
                Mobile          = user.Mobile,
                RegistTime      = user.RegistTime,
                RegistIp        = user.RegistIp,
                Status          = (int)user.Status,
                LastLoginTime   = user.LastLoginTime,
            };
        }
    }
}

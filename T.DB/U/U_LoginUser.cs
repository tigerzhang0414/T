using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.Enum.U;

namespace T.DB
{
    public class U_LoginUser
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        [StringLength(100)]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(100)]
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [StringLength(100)]
        public string NikiName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [StringLength(100)]
        public string RealName{ get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [StringLength(200)]
        public string Email { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [StringLength(100)]
        public string Mobile { get; set; }

        /// <summary>
        /// 注册IP
        /// </summary>
        [StringLength(100)]
        public string RegistIp { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegistTime { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public UserStatusEnum Status { get; set; }
    }
}

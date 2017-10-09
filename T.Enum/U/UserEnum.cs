using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.Common.Attributes;

namespace T.Enum.U
{
    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatusEnum
    {
        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        [Css("btn-default")]
        Disable = -1,
        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        [Css("btn-success")]
        Enable=1,
    }
}

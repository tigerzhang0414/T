using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.Common.Entities
{
    /// <summary>
    /// JSON返回对象
    /// </summary>
    public class JsonResInfo
    {
        /// <summary>
        /// 成功标记
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }

        public JsonResInfo() { }

        public System.Web.Mvc.JsonResult ToJsonT()
        {
            return new System.Web.Mvc.JsonResult
            {
                Data = this.Data,
                
            };
        }
    }
}

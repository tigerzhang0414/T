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
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }

        public JsonResInfo() { }

        #region 成功
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public JsonResInfo Success()
        {
            IsSuccess = true;
            return this;
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public JsonResInfo Success(string message = null)
        {
            IsSuccess = true;
            Message = message;
            return this;
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public JsonResInfo Success(object data = null,string message = null)
        {
            IsSuccess = true;
            Message = message;
            Data = data;
            return this;
        }
        #endregion

        #region 失败
        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public JsonResInfo Fail(string message)
        {
            IsSuccess = false;
            Message = message;
            return this;
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public JsonResInfo Fail(Exception ex)
        {
            IsSuccess = false;
            if (ex != null)
            {
                Message = ex.Message;
                if (ex.InnerException != null) Message += "内部错误：" + ex.InnerException.Message;
            }
            return this;
        }

        /// <summary>
        /// 失败-出错
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public JsonResInfo Failex(Exception ex)
        {
            var x = new XException(ex);
            IsSuccess = false;
            Message = x.Message;
            return this;
        }
        #endregion

        #region 返回
        /// <summary>
        /// 转换为JsonResult
        /// </summary>
        /// <returns></returns>
        public System.Web.Mvc.JsonResult Json()
        {
            return new System.Web.Mvc.JsonResult
            {
                Data = this,
                ContentEncoding = Encoding.UTF8,
                MaxJsonLength = int.MaxValue,
            };
        }

        /// <summary>
        /// 转换为JsonResultT
        /// </summary>
        /// <returns></returns>
        public JsonResultT JsonT()
        {
            return new JsonResultT
            {
                Data = this.Data,
                Formart = "yyyy-MM-dd HH:mm:ss",
                MaxJsonLength = int.MaxValue,
            };
        }

        /// <summary>
        /// 转换为JsonResultT
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public JsonResultT JsonT(bool success = false, string message = null, object data = null)
        {
            IsSuccess = success;
            Message = message;
            Data = data;
            return new JsonResultT
            {
                Data = this,
                Formart = "yyyy-MM-dd HH:mm:ss",
                MaxJsonLength = int.MaxValue,
            };
        }
        #endregion
    }

    public class JsonResBulk
    {
        /// <summary>
        /// 返回状态：-1：全部失败；0：部分成功；1：成功；
        /// </summary>
        public int Status { get; set; } = -1;
        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 成功数据
        /// </summary>
        public List<JsonResInfo> Succeed { get; set; } = new List<JsonResInfo>();
        /// <summary>
        /// 失败数据
        /// </summary>
        public List<JsonResInfo> Failed { get; set; } = new List<JsonResInfo>();

        public JsonResBulk Success(string message)
        {
            Status = 1;
            Message = message;
            return this;
        }

        public JsonResBulk Fail(string message)
        {
            Status = -1;
            Message = message;
            return this;
        }

        public JsonResBulk Partial(string message)
        {
            Status = 0;
            Message = message;
            return this;
        }
    }
}

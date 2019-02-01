using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using T.Common.Extensions;

namespace T.Common.Entities
{
    /// <summary>
    /// Json返回对象
    /// </summary>
    public class JsonResultT : JsonResult
    {
        const string error = "该GET请求已被组织，请设置JsonRequestBehavior为AllowGet";

        /// <summary>
        /// 格式化字符串
        /// </summary>
        public string Formart { get; set; }


        public JsonResultT() { }


        public JsonResultT(object data, bool time = false)
        {
            this.Data = data;
            if (time) Formart = "yyyy-MM-dd HH:mm:ss";
            else Formart = "yyyy-MM-dd";
        }

        /// <summary>
        /// 重写执行视图
        /// </summary>
        /// <param name="context">上下文</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException(error);

            System.Web.HttpResponseBase response = context.HttpContext.Response;

            if (!string.IsNullOrEmpty(ContentType))
                response.ContentType = ContentType;
            else
                response.ContentType = "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;
            if (Data != null)
            {
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                serializer.MaxJsonLength = int.MaxValue;
                string json = serializer.Serialize(Data);

                string reg = @"\\/Date\((\d+)\)\\/";
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(reg);

                var evaluator = new System.Text.RegularExpressions.MatchEvaluator(ConvertJsonDate);
                json = regex.Replace(json, evaluator);

                response.Write(json);
            }
        }

        /// <summary>
        /// 将Json序列化的时间由/Date(1294499956278)转换为字符串
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private string ConvertJsonDate(System.Text.RegularExpressions.Match match)
        {
            var date = new DateTime(1970, 1, 1);
            date = date.AddMilliseconds(long.Parse(match.Groups[1].Value));
            date = date.ToLocalTime();
            var result = date.ToString(Formart);
            return result;
        }
    }

    /// <summary>
    /// Jsonp返回对象
    /// </summary>
    public class JsonpResult : JsonResult
    {
        private string _callback = "callback";

        public JsonpResult() { }


        public JsonpResult(object data)
        {
            this.Data = data;
            this.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

        Func<int, string>[] s = new Func<int, string>[]
        {
            (x) => { return x.ToString(); },
            (x) => { return x.ToString()+"00000"; },
        };

        public void test()
        {
            foreach (Func<int, string> item in s)
            {
                item.Invoke(1);
            }
        }

        /// <summary>
        /// 重写执行视图
        /// </summary>
        /// <param name="context">上下文</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException();

            System.Web.HttpResponseBase response = context.HttpContext.Response;

            if (!string.IsNullOrEmpty(ContentType))
                response.ContentType = ContentType;
            else
                response.ContentType = "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;
            if (Data != null)
            {
                string buffer;
                if (!string.IsNullOrEmpty(context.HttpContext.Request[_callback]))
                {
                    _callback = context.HttpContext.Request[_callback];
                    buffer = string.Format("{0}{1}", _callback, Data.ToJson<object>());
                }
                else
                    buffer = Data.ToJson<object>();

                response.Write(buffer);
            }
        }
    }
}

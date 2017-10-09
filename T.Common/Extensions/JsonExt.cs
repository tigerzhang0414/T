using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace T.Common.Extensions
{
    /// <summary>
    /// JSON扩展类
    /// </summary>
    public static class JsonExt
    {
        /// <summary>
        /// 序列化JSON字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToJsonString(this object t)
        {
            return JsonConvert.SerializeObject(t);
        }

        /// <summary>
        /// 反序列化JSON对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T ToJsonObject<T>(this string strJson)
        {
            return JsonConvert.DeserializeObject<T>(strJson);
        }
    }
}

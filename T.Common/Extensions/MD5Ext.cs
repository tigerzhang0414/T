using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace T.Common.Extensions
{
    /// <summary>
    /// MD5加密扩展类
    /// </summary>
    public static class MD5Ext
    {
        /// <summary>
        /// MD5加密方法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMD5String(this string str)
        {
            str = str ?? "";
            var md5Str = string.Empty;
            var md5 = new MD5CryptoServiceProvider();
            var fromData = System.Text.Encoding.Unicode.GetBytes(str);
            var targetData = md5.ComputeHash(fromData);
            for (int i = 0; i < targetData.Length; i++)
            {
                md5Str += targetData[i].ToString("x");
            }
            return md5Str;
        }
    }
}

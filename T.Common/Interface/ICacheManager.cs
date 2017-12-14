using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.Common.Interface
{
    public interface ICacheManager
    {
        /// <summary>
        /// 通过KEY获得缓存中的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 通过key缓存对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cacheTime"></param>
        void Set(string key, object data, int cacheTime);

        /// <summary>
        /// 通过key判断缓存中是否有数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool IsSet(string key);

        /// <summary>
        /// 通过key移除缓存
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// 通过key批量移除缓存（key通过字符串的StartsWith匹配）
        /// </summary>
        /// <param name="pattern"></param>
        void RemoveByPattern(string pattern);

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        void Clear();
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using T.Common.Interface;

namespace T.Common.Tools
{
    /// <summary>
    /// 设置管理
    /// </summary>
    public class SettingManager
    {
        private static readonly SettingManager _instance = new SettingManager();
        public static SettingManager instance { get { return _instance; } }


        #region 获取设置
        /// <summary>
        /// 获取设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetSetting<T>() where T : ISetting, new()
        {
            var fileName = typeof(T).Name + ".config";
            var cacheKey = "SettingCache_" + fileName;
            var cacheManager = new MemoryCacheManger();
            if (cacheManager.IsSet(cacheKey)) return cacheManager.Get<T>(cacheKey);
            object setting = null;
            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/Settings");
            var filePath = Path.Combine(dir, fileName);
            if (File.Exists(filePath))
            {
                var xml = XElement.Load(filePath);
                var serializer = new XmlSerializer(typeof(T));
                using (var reader = xml.CreateReader())
                {
                    setting = serializer.Deserialize(reader);
                }
                cacheManager.Set(cacheKey, setting, 2);
            }
            return (T)setting;
        }

        /// <summary>
        /// 获取设置（重载）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public T GetSetting<T>(string fileName) where T : ISetting, new()
        {
            if (string.IsNullOrEmpty(fileName)) fileName = typeof(T).Name + ".config";
            else fileName = string.Format("{0}.{1}", fileName, "config");
            var cacheKey = "SettingCache_" + fileName;
            var cacheManager = new MemoryCacheManger();
            if (cacheManager.IsSet(cacheKey)) return cacheManager.Get<T>(cacheKey);
            object setting = null;
            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/Settings");
            var filePath = Path.Combine(dir, fileName);
            if (File.Exists(filePath))
            {
                var xml = XElement.Load(filePath);
                var serializer = new XmlSerializer(typeof(T));
                using (var reader = xml.CreateReader())
                {
                    setting = serializer.Deserialize(reader);
                }
                cacheManager.Set(cacheKey, setting, 2);
            }
            return (T)setting;
        }
        #endregion

        /// <summary>
        /// 保存设置
        /// </summary>
        /// <param name="setting"></param>
        public void SaveSetting(ISetting setting)
        {
           var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/Settings");
            var fileName = setting.GetType().Name + ".config";
            var fileNameBak = fileName + ".bak";
            var filePath = Path.Combine(dir, fileName);
            var filePathBak = filePath + ".bak";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            var ser = new XmlSerializer(setting.GetType());
            var xml = new XDocument();
            using (var writer = xml.CreateWriter())
            {
                var xmlns = new XmlSerializerNamespaces();
                xmlns.Add(string.Empty, string.Empty);
                ser.Serialize(writer, setting, xmlns);
            }
            //如果当前配置修改时间是12小时以前，先备份当前配置再修改
            if (File.Exists(filePath) && (DateTime.Now - File.GetLastWriteTime(filePath)).Hours > 12)
            {
                var fi = new FileInfo(filePath);
                if (fi.Exists && fi.IsReadOnly) fi.IsReadOnly = false;
                var fib = new FileInfo(filePathBak);
                if (fib.Exists && fib.IsReadOnly) fib.IsReadOnly = false;
                File.Delete(filePathBak);
                File.Move(filePath, filePathBak);
            }
            xml.Root.Save(filePath, SaveOptions.None);

            var cacheKey = "SettingCache_" + fileName;
            ClearSettingCache(cacheKey);
        }

        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <param name="key"></param>
        private void ClearSettingCache(string key)
        {
            var cacheManger = new MemoryCacheManger();
            cacheManger.Remove(key);
        }
    }
}

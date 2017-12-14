using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using T.Common.Interface;

namespace T.Web.Models
{
    /// <summary>
    /// 任务集合
    /// </summary>
    public class ScheduleTaskSetting : ISetting
    {
        public List<ScheduleTask> ScheduleTasks { get; set; }
    }

    /// <summary>
    /// 自动任务
    /// </summary>
    public class ScheduleTask
    {
        /// <summary>
        /// 任务ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 间隔时长（秒）
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// 任务类型：类，程序集
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 出错时是否终止任务
        /// </summary>
        public bool StopOnError { get; set; }
    }
}
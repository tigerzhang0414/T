using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using T.Common.Interface;
using T.Web.Models;

namespace T.Web.Frameworks.Tasks
{
    /// <summary>
    /// 自动任务类
    /// </summary>
    public class Task
    {
        #region 属性
        private bool _enabled;
        private readonly string _type;
        private readonly string _name;
        private readonly bool _stopOnError;
        private DateTime? _lastStartUtc;
        private DateTime? _lastSuccessUtc;
        private DateTime? _lastEndUtc;
        private bool _isRunning;

        /// <summary>
        /// 是否正在运行
        /// </summary>
        public bool IsRunning { get { return this._isRunning; } }

        /// <summary>
        /// 最近运行开始时间
        /// </summary>
        public DateTime? LastStartUtc { get { return this._lastStartUtc; } }

        /// <summary>
        /// 最近运行结束时间
        /// </summary>
        public DateTime? LastEndUtc { get { return this._lastEndUtc; } }

        /// <summary>
        /// 最近执行成功时间
        /// </summary>
        public DateTime? LastSuccessUtc { get { return this._lastSuccessUtc; } }

        /// <summary>
        /// 任务类型：类，程序集
        /// </summary>
        public string Type { get { return this._type; } }

        /// <summary>
        /// 出错时是否终止任务
        /// </summary>
        public bool StopOnError { get { return this._stopOnError; } }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get { return this._name; } }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get { return this._enabled; } }
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        private Task()
        {
            this._enabled = true;
        }

        /// <summary>
        /// 带任务的构造方法
        /// </summary>
        /// <param name="task"></param>
        public Task(ScheduleTask task)
        {
            this._type = task.Type;
            this._enabled = task.Enabled;
            this._stopOnError = task.StopOnError;
            this._name = task.Name;
        }

        /// <summary>
        /// 创建任务
        /// </summary>
        /// <returns></returns>
        private ITask CreateTask()
        {
            ITask task = null;
            if (this.Enabled)
            {
                var type2 = System.Type.GetType(this._type);
                if (type2 != null)
                {
                    var instance = Activator.CreateInstance(type2);
                    task = instance as ITask;
                }
            }
            return task;
        }

        public void Execute()
        {
            this._isRunning = true;
            try
            {
                var task = this.CreateTask();
                if (task != null)
                {
                    this._lastStartUtc = DateTime.Now;
                    task.Execute();
                    this._lastEndUtc = this._lastSuccessUtc = DateTime.Now;
                }
            }
            catch (Exception)
            {
                this._enabled = !this.StopOnError;
                this._lastEndUtc = DateTime.Now;
            }
            this._isRunning = false;
        }
    }
}
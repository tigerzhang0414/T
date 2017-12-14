using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using T.Common.Tools;
using T.Web.Models;

namespace T.Web.Frameworks.Tasks
{
    /// <summary>
    /// 自动任务管理器
    /// </summary>
    public class TaskManager
    {
        private static readonly TaskManager _taskManager = new TaskManager();
        private readonly List<TaskThread> _taskThreads = new List<TaskThread>();
        private TaskManager()
        {

        }


        public void Initialize()
        {
            this._taskThreads.Clear();
            var _scheduleTaskSetting = SettingManager.instance.GetSetting<ScheduleTaskSetting>();
            var schduleTasks = _scheduleTaskSetting.ScheduleTasks.Where(x => x.Enabled).ToList();
            foreach (var schduleTask in schduleTasks)
            {
                var taskThread = new TaskThread(schduleTask);
                this._taskThreads.Add(taskThread);
                var task = new Task(schduleTask);
                taskThread.AddTask(task);
            }
        }

        public void Start()
        {
            foreach (var taskThread in this._taskThreads)
            {
                taskThread.InitTimer();
            }
        }


        public void Stop()
        {
            foreach (var taskThread in this._taskThreads)
            {
                taskThread.Dispose();
            }
        }


        public static TaskManager Instance
        {
            get
            {
                return _taskManager;
            }
        }

        public IList<TaskThread> TaskThreads
        {
            get
            {
                return new ReadOnlyCollection<TaskThread>(this._taskThreads);
            }
        }
    }
}
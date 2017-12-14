using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Web;
using T.Web.Models;

namespace T.Web.Frameworks.Tasks
{
    public class TaskThread : IDisposable
    {
        private Timer _timer;
        private bool _disposed;
        private DateTime _startedUtc;
        private bool _isRunning;
        private readonly Dictionary<string, Task> _tasks;
        private int _seconds;

        internal TaskThread()
        {
            this._tasks = new Dictionary<string, Task>();
            this._seconds = 10 * 60;
        }

        internal TaskThread(ScheduleTask scheduleTask)
        {
            this._tasks = new Dictionary<string, Task>();
            this._seconds = scheduleTask.Seconds;
            this._isRunning = false;
        }

        private void Run()
        {
            if (_seconds <= 0)
                return;
            this._startedUtc = DateTime.Now;
            this._isRunning = true;
            foreach (var task in this._tasks.Values)
            {
                task.Execute();
            }
            this._isRunning = false;
        }


        private void TimerHandler(object statte)
        {
            this._timer.Change(-1, 1);
            this.Run();
            this._timer.Change(this.Interval, this.Interval);
        }

        public void Dispose()
        {
            if ((this._timer != null) && !this._disposed)
            {
                lock (this)
                {
                    this._timer.Dispose();
                    this._timer = null;
                    this._disposed = true;
                }
            }
        }


        public void InitTimer()
        {
            if (this._timer == null) this._timer = new Timer(new TimerCallback(this.TimerHandler), null, this.Interval, this.Interval);
        }


        public void AddTask(Task task)
        {
            if (!this._tasks.ContainsKey(task.Name)) this._tasks.Add(task.Name, task);
        }


        public int Seconds
        {
            get
            {
                return this._seconds;
            }
            internal set
            {
                this._seconds = value;
            }
        }


        public DateTime Started
        {
            get
            {
                return this._startedUtc;
            }
        }


        public bool Running
        {
            get
            {
                return this._isRunning;
            }
        }


        public IList<Task> Tasks
        {
            get
            {
                var list = new List<Task>();
                foreach(var task in this._tasks.Values)
                {
                    list.Add(task);
                }
                return new ReadOnlyCollection<Task>(list);
            }
        }


        public int Interval
        {
            get
            {
                return this._seconds * 1000;
            }
        }
    }
}
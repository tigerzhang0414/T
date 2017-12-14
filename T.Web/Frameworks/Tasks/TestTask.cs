using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using T.Common.Interface;

namespace T.Web.Frameworks.Tasks
{
    public class TestTask : ITask
    {
        public void Execute()
        {
            try
            {
                //var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                //if (!File.Exists(dir))
                //{
                //    System.IO.Directory.CreateDirectory(dir);
                //}
                //var file = Path.Combine(dir, DateTime.Now.ToString("yyyyMMddHHmmssfff")) + ".txt";
                //FileStream myFs = new FileStream(file, FileMode.Create);
                //StreamWriter mySw = new StreamWriter(myFs);
                //mySw.Write("测试自动任务！");
                //mySw.Close();
                //myFs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
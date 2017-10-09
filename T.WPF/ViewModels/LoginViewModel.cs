using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T.Business.U;
using T.WPF.Commands;

namespace T.WPF.ViewModels
{
    /// <summary>
    /// 登录视图模型
    /// </summary>
    public class LoginViewModel : MVVMObject
    {
        #region 帐号
        /// <summary>
        /// 帐号，私有属性
        /// </summary>
        private string account;

        /// <summary>
        /// 帐号，公开属性
        /// </summary>
        public string Account
        {
            get { return account; }
            set
            {
                this.account = value;
                this.RaisePropertyChanged("account");
            }
        }
        #endregion

        #region 密码
        /// <summary>
        /// 密码，私有属性
        /// </summary>
        private string password;

        /// <summary>
        /// 密码，公开属性
        /// </summary>
        public string Password
        {
            get { return password; }
            set
            {
                this.password = value;
                this.RaisePropertyChanged("password");
            }
        }
        #endregion

        #region 消息
        /// <summary>
        /// 消息，私有属性
        /// </summary>
        private string msg;

        /// <summary>
        /// 消息，公开属性
        /// </summary>
        public string Msg
        {
            get { return msg; }
            set
            {
                this.msg = value;
                this.RaisePropertyChanged("msg");
            }
        }
        #endregion

        /// <summary>
        /// 登录命令
        /// </summary>
        public DelegateCommand ExecuteLoginCommand { get; set; }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="parameter"></param>
        public void ExecuteLogin(object parameter)
        {
            var userBusiness = new UserBusiness();
            var loginUser = userBusiness.Login(this.Account, this.Password);
            this.Msg = loginUser.Item3;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public LoginViewModel()
        {
            this.ExecuteLoginCommand = new DelegateCommand();//实例化登录命令
            this.ExecuteLoginCommand.ExecuteAction = new Action<object>(this.ExecuteLogin);//将登录方法传递给登录命令的执行操作
        }
    }
}

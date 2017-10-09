using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.DB
{
    /// <summary>
    /// 数据库连接
    /// </summary>
    public class TDbContext : DbContext
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public TDbContext() : base("name=TDbContext")
        {
            if (!Database.Exists())
            {
                Database.CreateIfNotExists();
                InitBaseData();//初始化基础数据
            }
            Database.SetInitializer<TDbContext>(null);
        }

        /// <summary>
        /// 创建数据库时初始化数据
        /// </summary>
        public void InitBaseData()
        {
            var adminUser = new U_LoginUser
            {
                Id = Guid.NewGuid(),
                Account = "admin",
                LastLoginTime = DateTime.Now,
                NikiName = "系统管理员",
                Password = "cebfd1559b68d67688884d7a3d3e8c",
                Status = Enum.U.UserStatusEnum.Enable,
                RealName = "系统管理员",
                RegistTime = DateTime.Now,
            };

            var dtx = new TDbContext();
            dtx.U_LoginUser.Add(adminUser);
            dtx.SaveChanges();
        }

        /// <summary>
        /// 登录用户表
        /// </summary>
        public virtual DbSet<U_LoginUser> U_LoginUser { get; set; }

        /// <summary>
        /// 收支类别
        /// </summary>
        public virtual DbSet<F_PaymentCate> F_PaymentCate { get; set; }

        /// <summary>
        /// 重构OnModelCreating方法
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}

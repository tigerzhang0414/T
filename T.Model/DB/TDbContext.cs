using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.Model.DB
{
    /// <summary>
    /// 数据库连接
    /// </summary>
    public class TDbContext:DbContext
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public TDbContext() : base("name=TDbContext")
        {
            if (!Database.Exists())
                Database.CreateIfNotExists();
            Database.SetInitializer<TDbContext>(null);
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

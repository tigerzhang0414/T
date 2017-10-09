using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.DB
{
    /// <summary>
    /// 收支类别
    /// </summary>
    public class F_PaymentCate
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [StringLength(100)]
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 父类别ID
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 父类别编号
        /// </summary>
        [StringLength(100)]
        public string ParentCode { get; set; }

        /// <summary>
        /// 父类别名称
        /// </summary>
        [StringLength(100)]
        public string ParentName { get; set; }

        /// <summary>
        /// 收支类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public Guid CreateById { get; set; }

        /// <summary>
        /// 创建人帐号
        /// </summary>
        [StringLength(100)]
        public string CreateByCode { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        [StringLength(100)]
        public string CreateByName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}

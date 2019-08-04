using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity
{
    /// <summary>
    /// 权限表
    /// </summary>
    [Table("SysPower")]
    public class SysPower : BaseEntity
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        [Key]
        public string PowerId
        {
            get; set;
        }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string PowerName
        {
            get; set;
        }

        /// <summary>
        /// 建立日期
        /// </summary>
        public DateTime CreateDate
        {
            get; set;
        }

        /// <summary>
        /// 最后更新日期
        /// </summary>
        public DateTime LastModifyDate
        {
            get; set;
        }

        /// <summary>
        /// 建立人
        /// </summary>
        public string CreateBy
        {
            get; set;
        }

        /// <summary>
        /// 更新人
        /// </summary>
        public string LastModifyBy
        {
            get; set;
        }
    }
}

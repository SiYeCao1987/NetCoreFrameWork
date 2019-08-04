using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity
{
    /// <summary>
    /// 角色表
    /// </summary>
    [Table("SysRole")]
    public class SysRole : BaseEntity
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [Key]
        public string RoleId
        {
            get; set;
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
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
        /// 状态：0禁用，1启用
        /// </summary>
        public int IStatus
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

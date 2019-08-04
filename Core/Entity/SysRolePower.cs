using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity
{
    /// <summary>
    /// 角色权限表
    /// </summary>
    [Table("SysRolePower")]
    public class SysRolePower : BaseEntity
    {
        /// <summary>
        /// 角色权限ID
        /// </summary>
        [Key]
        public string Id
        {
            get; set;
        }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleId
        {
            get; set;
        }

        /// <summary>
        /// 权限ID
        /// </summary>
        public string PowerId
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

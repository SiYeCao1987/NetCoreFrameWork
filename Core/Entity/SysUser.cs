using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity
{
    /// <summary>
    /// 系统用户表
    /// </summary>
    [Table("SysUser")]
    public class SysUser : BaseEntity
    {
        /// <summary>
        /// 系统用户表ID
        /// </summary>
        [Key]
        public string UserId
        {
            get; set;
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get; set;
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord
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
        /// 状态：0禁用，1启用，2审核中
        /// </summary>
        public int IStatus
        {
            get; set;
        }

        /// <summary>
        /// 超级管理员：0不是，1是
        /// </summary>
        public int SuperUser
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

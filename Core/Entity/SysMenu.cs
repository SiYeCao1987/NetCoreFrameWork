using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity
{
    /// <summary>
    /// 菜单表
    /// </summary>
    [Table("SysMenu")]
    public class SysMenu : BaseEntity
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        [Key]
        public string MenuId
        {
            get;set;
        }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName
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
        /// 是否显示菜单:0不显示,1显示
        /// </summary>
        public int ShowMenu
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

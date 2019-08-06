using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infrastructure.DataBase
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
           : base(options)
        {

        }

        public DbSet<SysUser> sysUser { get; set; }
        public DbSet<SysMenu> SysMenu { get; set; }
        public DbSet<SysPower> SysPower { get; set; }
        public DbSet<SysRole> SysRole { get; set; }
        public DbSet<SysRolePower> SysRolePower { get; set; }
        public DbSet<SysUserInRole> SysUserInRole { get; set; }
        public DbSet<SysUserPower> SysUserPower { get; set; }
    }
}

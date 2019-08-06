using Common.Autofac;
using Core.Entity;
using Core.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public class SysUserRepository : BaseRepository<SysUser>, ISysUserRepository<SysUser>, ITransientDependency
    {

    }
}

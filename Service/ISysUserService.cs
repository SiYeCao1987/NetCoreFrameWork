using Common.Helper;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface ISysUserService
    {
        int AddUser(SysUser sysUser);
        List<SysUser> getSysUserPagination(Pagination pagination);
        List<SysUser> getSysUserPaginationExpression(string userId, Pagination pagination);
    }
}

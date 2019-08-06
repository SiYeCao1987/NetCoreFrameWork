using Common.Helper;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Service
{
    public interface ISysUserService
    {
        ServiceResult AddUser(SysUser sysUser);
        List<SysUser> getSysUserPagination(Pagination pagination);
        List<SysUser> getSysUserPaginationExpression(string userId, Pagination pagination);
    }
}

using Common.Autofac;
using Common.Helper;
using Core.Business.Service;
using Core.Entity;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.ServiceImpl
{
    public class SysUserServiceImpl : ISysUserService, ITransientDependency
    {
        public ISysUserRepository<SysUser> sysUserRepository { get; set; }
        public ServiceResult AddUser(SysUser sysUser)
        {
            ServiceResult result = new ServiceResult("添加系统用户");
            sysUser.CreateDate = DateTime.Now;
            sysUser.LastModifyDate = DateTime.Now;
            sysUser.IStatus = 1;
            sysUserRepository.Insert(sysUser);
            return result.IsOK();
        }

        public List<SysUser> getSysUserPagination(Pagination pagination)
        {
            return sysUserRepository.FindList(pagination);
        }

        public List<SysUser> getSysUserPaginationExpression(string userId, Pagination pagination)
        {
            var express = ExtLinq.True<SysUser>();
            express = express.And(t => t.UserId == userId);
            return sysUserRepository.FindList(express, pagination);
        }
    }
}

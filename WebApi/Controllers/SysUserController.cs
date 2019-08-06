using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Helper;
using Core.Business.Service;
using Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.RequestForm.Sys;

namespace WebApi.Controllers
{
    /// <summary>
    /// 系统用户控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SysUserController : ApiBaseController
    {
        public ISysUserService sysUserService { get; set; }

        [HttpPost]
        public ActionResult AddSysUser(RequestBody<SysUserForm> form)
        {
            ResponseResult result = new ResponseResult();

            SysUserForm sysUserForm = form.Body;
            SysUser sysUser = new SysUser();
            sysUser.UserId = Guid.NewGuid().ToString();
            sysUser.UserName = sysUserForm.UserName;
            sysUser.PassWord = sysUserForm.PassWord;
            sysUser.SuperUser = sysUserForm.SuperUser;

            sysUserService.AddUser(sysUser);

            result.Code = ResponseResultType.Success;
            result.Message = "添加系统用户成功";
            return Content(result.ToJson());
        }

        [HttpGet]
        public ActionResult getList(int page, int rows, string userId)
        {
            ResponseResult result = new ResponseResult();
            Pagination pagination = new Pagination();
            pagination.rows = rows;
            pagination.page = page;
            pagination.sidx = "CreateDate";
            pagination.sord = "desc";
            List<SysUser> list = sysUserService.getSysUserPaginationExpression(userId, pagination);
            result.Code = ResponseResultType.Success;
            result.Data = list;
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult getSysUserPagination(int page, int rows)
        {
            ResponseResult result = new ResponseResult();
            Pagination pagination = new Pagination();
            pagination.rows = rows;
            pagination.page = page;
            List<SysUser> list = sysUserService.getSysUserPagination( pagination);
            result.Code = ResponseResultType.Success;
            result.Data = list;
            return Content(result.ToJson());
        }
    }
}
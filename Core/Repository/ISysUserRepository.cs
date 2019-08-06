using Core.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface ISysUserRepository<T> : IBaseRepository<T> where T : class, new()
    {

    }
}

using Common.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.InjectTest
{
    public class Person : Iperson, ITransientDependency
    {
        public string GetName()
        {
            return "syc";
        }
    }
}

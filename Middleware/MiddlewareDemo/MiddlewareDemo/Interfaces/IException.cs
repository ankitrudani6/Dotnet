using MiddlewareDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Interfaces
{
    interface IException
    {
        Task AddError(ExceptionLogging ex);
    }
}

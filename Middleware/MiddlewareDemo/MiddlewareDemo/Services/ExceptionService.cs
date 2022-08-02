using MiddlewareDemo.Interfaces;
using MiddlewareDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Services
{
    public class ExceptionService:IException
    {
        private DotnetDBContext DbContext { get; set; }
        public ExceptionService(DotnetDBContext dBContext)
        {
            DbContext = dBContext;
        }

        async public Task AddError(ExceptionLogging ex)
        {
            using(DotnetDBContext dBContext = new DotnetDBContext())
            {
                dBContext.ExceptionLoggings.Add(ex);
                await dBContext.SaveChangesAsync();
            }
            
            
        }
    }
}

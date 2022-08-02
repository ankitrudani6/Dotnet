using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Interfaces
{
    public interface IClientConfiguration
    {
        string ClientName { get; set; }
        DateTime InvokedDateTime { get; set; }
    }
}

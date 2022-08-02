using MiddlewareDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo
{
    public class ClientConfiguration : IClientConfiguration
    {
        public string ClientName { get; set; }
        public DateTime InvokedDateTime { get; set; }
    }
}

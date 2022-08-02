using MiddlewareDemo.Interfaces;
using MiddlewareDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Services
{
    public class PersonService:Repository<Person>,IPerson
    {
        public PersonService(DotnetDBContext dBContext):base(dBContext)
        {

        }
    }
}

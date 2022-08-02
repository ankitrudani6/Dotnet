using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyCompanyAPI.Models;

namespace ToyCompanyAPI.Interfaces
{
    public interface ICustomer : IRepository<Customer>
    {
        List<Toy> GetToy();
    }
}

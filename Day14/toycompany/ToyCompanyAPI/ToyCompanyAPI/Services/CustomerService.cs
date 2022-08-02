using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyCompanyAPI.Interfaces;
using ToyCompanyAPI.Models;

namespace ToyCompanyAPI.Services
{
    
    public class CustomerService : Repository<Customer>, ICustomer
    {
        private ToyCompanyContext DBContext { get; set; }
        public CustomerService(ToyCompanyContext toyCompanyContext) : base(toyCompanyContext)
        {
            DBContext = toyCompanyContext;
        }

        public List<Toy> GetToy()
        {
            return DbContext.Toys.ToList();
        }
    }
}

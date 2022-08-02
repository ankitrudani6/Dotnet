using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyCompany.Models;

namespace ToyCompany.Services
{
    public interface ICustomerService:IRepository<Customer>  
    {
        
    }
    public class CustomerService : Repository<Customer>, ICustomerService
    {
        public CustomerService(ToyCompanyContext toyCompanyContext): base(toyCompanyContext)
        {

        }
    }

}

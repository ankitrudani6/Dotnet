using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class EmployeeService:Repository<Employee>,IEmployee
    {
        public EmployeeService(EmployeeDBContext dBContext):base(dBContext)
        {

        }
    }
}

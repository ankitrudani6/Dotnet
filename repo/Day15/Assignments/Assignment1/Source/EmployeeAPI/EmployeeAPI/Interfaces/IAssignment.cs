using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Interfaces
{
    public interface IAssignment:IRepository<Assignment>
    {
        List<Assignment> GetAllAssignment(int eid);
    }
}

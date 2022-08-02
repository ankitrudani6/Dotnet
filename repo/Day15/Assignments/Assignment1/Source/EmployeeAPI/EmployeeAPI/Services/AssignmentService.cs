using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class AssignmentService:Repository<Assignment>,IAssignment
    {
        private EmployeeDBContext DBContext { get; set; }
        public AssignmentService(EmployeeDBContext dBContext):base(dBContext)
        {
            DBContext = dBContext;
        }

        public List<Assignment> GetAllAssignment(int eid)
        {
            return DbContext.Employees.Find(eid).Assignments.ToList();
        }
    }
}

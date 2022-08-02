using HospitalManagementAPI.Interfaces;
using HospitalManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementAPI.Services
{
    public class DepartmentService:Repository<Department>,IDepartment
    {
        public DepartmentService(HospitalContext context):base(context)
        {

        }
    }
}

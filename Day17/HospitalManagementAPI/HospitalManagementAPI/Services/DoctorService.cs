using HospitalManagementAPI.Interfaces;
using HospitalManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementAPI.Services
{
    public class DoctorService:Repository<Doctor>,IDoctor
    {
        public DoctorService(HospitalContext context):base(context)
        {

        }
    }
}

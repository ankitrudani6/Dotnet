using HospitalManagementAPI.Interfaces;
using HospitalManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementAPI.Services
{
    public class DoctorService:Repository<Doctor>,IDoctor
    {
        private HospitalContext HospitalContext { get; set; }
        public DoctorService(HospitalContext context):base(context)
        {
            HospitalContext = context;
        }

        public List<Patient> GetPatients(int dID)
        {
            return HospitalContext.Patients.Where(p => p.DoctorId == dID).ToList();
        }
    }
}

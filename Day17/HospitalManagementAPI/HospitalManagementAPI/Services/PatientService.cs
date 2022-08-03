using HospitalManagementAPI.Interfaces;
using HospitalManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementAPI.Services
{
    public class PatientService:Repository<Patient>,IPatient
    {
        public PatientService(HospitalContext context):base(context)
        {

        }
    }
}

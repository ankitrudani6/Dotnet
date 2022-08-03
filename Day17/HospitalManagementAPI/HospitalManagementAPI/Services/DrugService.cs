using HospitalManagementAPI.Interfaces;
using HospitalManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementAPI.Services
{
    public class DrugService:Repository<Drug>,IDrug
    {
        public DrugService(HospitalContext context):base(context)
        {

        }
    }
}

using HospitalManagementAPI.Interfaces;
using HospitalManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementAPI.Services
{
    public class DrugSummaryService:Repository<DrugSummary>,IDrugSummary
    {
        public DrugSummaryService(HospitalContext context):base(context)
        {

        }
    }
}

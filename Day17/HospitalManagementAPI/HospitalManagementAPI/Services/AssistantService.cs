using HospitalManagementAPI.Interfaces;
using HospitalManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementAPI.Services
{
    public class AssistantService:Repository<Assistant>,IAssistant
    {
        public AssistantService(HospitalContext context):base(context)
        {

        }
    }
}

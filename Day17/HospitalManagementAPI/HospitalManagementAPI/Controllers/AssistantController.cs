using HospitalManagementAPI.Interfaces;
using HospitalManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssistantController : ControllerBase
    {
        private IAssistant AssistantService { get; set; }
        public AssistantController(IAssistant assistantService)
        {
            AssistantService = assistantService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(AssistantService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(AssistantService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Assistant assistant)
        {
            return Ok(AssistantService.Add(assistant));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var assistant = AssistantService.GetById(id);
            return Ok(AssistantService.Delete(assistant));
        }
    }
}

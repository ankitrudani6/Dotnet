using HospitalManagementAPI.Interfaces;
using HospitalManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class DepartmentController : ControllerBase
    {
        private IDepartment DepartmentService { get; set; }
        public DepartmentController(IDepartment departmentService)
        {
            DepartmentService = departmentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DepartmentService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(DepartmentService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            return Ok(DepartmentService.Add(department));
        }

        [HttpDelete("{id}")]
        [Authorize]

        public IActionResult Delete(int id)
        {
            var department = DepartmentService.GetById(id);
            return Ok(DepartmentService.Delete(department));
        }
    }
}

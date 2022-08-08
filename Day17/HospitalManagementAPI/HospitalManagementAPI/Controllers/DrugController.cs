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
    public class DrugController : ControllerBase
    {
        private IDrug DrugService { get; set; }
        public DrugController(IDrug drugService)
        {
            DrugService = drugService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DrugService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(DrugService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Drug drug)
        {
            return Ok(DrugService.Add(drug));
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Drug newDrug)
        {
            var drug = DrugService.GetById(id);
            Exception
            return Ok(DrugService.Put(drug, newDrug));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var drug = DrugService.GetById(id);
            return Ok(DrugService.Delete(drug));
        }
    }
}

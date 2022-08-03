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
    public class DrugSummaryController : ControllerBase
    {
        private IDrugSummary  DrugSummaryService { get; set; }
        public DrugSummaryController(IDrugSummary drugSummaryService)
        {
            DrugSummaryService = drugSummaryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DrugSummaryService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(DrugSummaryService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(DrugSummary drugSummary)
        {
            return Ok(DrugSummaryService.Add(drugSummary));
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, DrugSummary newDrugSummary)
        {
            var drugSummary = DrugSummaryService.GetById(id);
            return Ok(DrugSummaryService.Put(drugSummary, newDrugSummary));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var drugSummary = DrugSummaryService.GetById(id);
            return Ok(DrugSummaryService.Delete(drugSummary));
        }
    }
}

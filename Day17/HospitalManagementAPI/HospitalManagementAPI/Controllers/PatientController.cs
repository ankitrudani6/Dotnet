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
    public class PatientController : ControllerBase
    {
        private IPatient PatientService { get; set; }
        public PatientController(IPatient patientService)
        {
            PatientService = patientService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(PatientService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(PatientService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Patient patient)
        {
            return Ok(PatientService.Add(patient));
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Patient newPatient)
        {
            var patient = PatientService.GetById(id);
            return Ok(PatientService.Put(patient, newPatient));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var patient = PatientService.GetById(id);
            return Ok(PatientService.Delete(patient));
        }
    }
}

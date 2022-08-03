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
    public class DoctorController : ControllerBase
    {
        private IDoctor DoctorService { get; set; }
        public DoctorController(IDoctor doctorService)
        {
            DoctorService = doctorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DoctorService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(DoctorService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Doctor doctor)
        {
            return Ok(DoctorService.Add(doctor));
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Doctor newDoctor)
        {
            var doctor = DoctorService.GetById(id);
            return Ok(DoctorService.Put(doctor, newDoctor));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var doctor = DoctorService.GetById(id);
            return Ok(DoctorService.Delete(doctor));
        }

        [HttpGet("{docId}/GetPatients")]
        public IActionResult GetPatient(int docId)
        {
            return Ok();
        }
    }
}

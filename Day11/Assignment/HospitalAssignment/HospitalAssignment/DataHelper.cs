using HospitalAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HospitalAssignment
{
    class DataHelper
    {
        public HospitalContext DbContext { get; set; }
        public DataHelper()
        {
            DbContext = new HospitalContext();
        }

        public void AddDoctor()
        {
            var doctor = new Doctor();

            Console.Write("Enter Doctor Name : ");
            doctor.DoctorName = Console.ReadLine();

            Console.Write("Enter Phone Number : ");
            doctor.Phone = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter Department Id : ");
            doctor.DepartmentId = Convert.ToInt32(Console.ReadLine());

            DbContext.Add(doctor);
            DbContext.SaveChanges();
        }

        public void DisplayDoctor()
        {
            var doctors = DbContext.Doctors.ToList();
            foreach (var d in doctors)
            {
                Console.WriteLine();
            }
        }
        public void UpdateDoctor()
        {
            var doc = DbContext.Doctors.Where(d => d.DoctorId == 4).FirstOrDefault();
            doc.Phone = 9999999999;
            DbContext.Update(doc);
            DbContext.SaveChanges();
        }

        public void DeleteDoctor()
        {
            var doc = DbContext.Doctors.Where(d => d.DoctorId == 6).FirstOrDefault();
            DbContext.Remove(doc);
            DbContext.SaveChanges();
        }

        public void PatientReport()
        {
            var d = DbContext.Patients.Include("Doctor");
            //var data = DbContext.JsonDatas.FromSqlRaw("EXEC sp_patient_report").AsEnumerable().Single();
            

        }

        public List<Department> GetDepartments()
        {
            return DbContext.Departments.ToList();
        }

        public void AddDepartment()
        {
            var department = new Department();
            department.DepartmentName = "Dental";
            DbContext.Add(department);
            DbContext.SaveChanges();
        }
        public void UpdateDepartment()
        {
            var dept = DbContext.Departments.Where(d => d.DepartmentId == 1).FirstOrDefault();
            dept.DepartmentName = "Mental";
            DbContext.Update(dept);
            DbContext.SaveChanges();
        }

        public void DeleteDepartment()
        {
            var dept = DbContext.Departments.Where(d => d.DepartmentId == 1).FirstOrDefault();
            DbContext.Remove(dept);
            DbContext.SaveChanges();
        }

    }
}

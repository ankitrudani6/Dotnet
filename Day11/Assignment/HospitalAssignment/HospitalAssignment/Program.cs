using System;

namespace HospitalAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int ch = -1;
            DataHelper dataHelper = new DataHelper();

            while (ch != 0)
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Display Doctor");
                Console.WriteLine("3. Update Doctor");
                Console.WriteLine("4. Delete Doctor");
                Console.WriteLine("5. Report of patient assigned to a particular doctor");
                Console.WriteLine("6. Report of medicine list for a particular patient");
                Console.WriteLine("7. Summary report of Doctor and patient");
                Console.WriteLine(new string('-', 50));

                Console.Write("Enter Your Choice : ");
                ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        {
                            dataHelper.AddDoctor();
                            break;
                        }
                    case 2:
                        {
                            dataHelper.DisplayDoctor();
                            break;
                        }
                }
            }

            //Insert Doctor
            //dataHelper.InsertDoctor();

            //Update Doctor
            //dataHelper.UpdateDoctor();

            //Delete Doctor
            //dataHelper.DeleteDoctor();
            dataHelper.PatientReport();
            //Display Doctor
            dataHelper.GetDoctors().ForEach(d => Console.WriteLine(d.DoctorId+", "+d.DoctorName + ", " + d.Phone + ", " + d.DepartmentId));
        }
    }
}

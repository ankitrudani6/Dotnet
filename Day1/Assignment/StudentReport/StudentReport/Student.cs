using System;
using System.Collections.Generic;
using System.Text;

namespace StudentReport
{
    class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Hindi { get; set; }
        public int English { get; set; }
        public int Maths { get; set; }
        public int Total { get { return Hindi + English + Maths;  } }
        public float Percentage { get { return Total/ 3.0f; } } 
        public string Compute()
        {
            if (Percentage > 95)
                return "A+";
            else if (Percentage > 70)
                return "A";
            else if (Percentage > 55)
                return "B";
            else if (Percentage > 45)
                return "C";
            return "D";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Day2Assignment
{
    class Person
    {
        
        public Person(string First, string Last, string Email, string DateOfBirth)
        {
            this.FirstName = First;
            this.LastName = Last;
            this.EmailAddress = Email;
            this.DateOfBirth = Convert.ToDateTime(DateOfBirth).Date;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsAdult { 
            get
            {
                int age = DateTime.Now.Year - DateOfBirth.Year;
                if (age < 18)
                    return true;
                return false;
            } 
        }

        public string SunSign
        {
            get
            {
                int day = DateOfBirth.Day;
                int month = DateOfBirth.Month;

                if ((day >= 21 && month == 3) || (day <= 20 && month == 4))
                    return "Aries";
                if ((day >= 24 && month == 9) || (day <= 23 && month == 10))
                    return "Libra";
                if ((day >= 21 && month == 4) || (day <= 21 && month == 5))
                    return "Taurus";
                if ((day >= 24 && month == 10) || (day <= 22 && month == 11))
                    return "Scorpio";
                if ((day >= 22 && month == 5) || (day <= 21 && month == 6))
                    return "Gemini";
                if ((day >= 23 && month == 11) || (day <= 21 && month == 12))
                    return "Sagittarius";
                if ((day >= 21 && month == 6) || (day <= 23 && month == 7))
                    return "Cancer";
                if ((day >= 22 && month == 12) || (day <= 20 && month == 1))
                    return "Capricorn";
                if ((day >= 24 && month == 7) || (day <= 23 && month == 8))
                    return "Leo";
                if ((day >= 21 && month == 1) || (day <= 19 && month == 2))
                    return "Aquarius";
                if ((day >= 24 && month == 8) || (day <= 23 && month == 9))
                    return "Virgo";
                if ((day >= 20 && month == 2) || (day <= 20 && month == 3))
                    return "Pisces";
                return "";
            }
        }
        public string ChineseSign
        {
            get
            {
                int year = DateOfBirth.Year;
                float st1 = year / 12f;
                float rem = st1 - (int)st1;
                int code = (int)Math.Round(rem * 12);

                if (code == 0)
                    return "Monkey";
                else if (code == 1)
                    return "Rooster";
                else if (code == 2)
                    return "Dog";
                else if (code == 3)
                    return "Pig";
                else if (code == 4)
                    return "Rat";
                else if (code == 5)
                    return "Ox";
                else if (code == 6)
                    return "Tiger";
                else if (code == 7)
                    return "Rabbit";
                else if (code == 8)
                    return "Dragon";
                else if (code == 9)
                    return "Snake";
                else if (code == 10)
                    return "Horse";
                else if (code == 11)
                    return "Sheep";
                return "";
            }
        }

        public bool Birthday {
            get
            {
                if(DateTime.Compare(DateTime.Now.Date,DateOfBirth.Date)==0)
                    return true;
                return false;
            } 
        }

        public string ScreenName { 
            get
            {
                return FirstName + LastName + DateOfBirth.ToString("MMddyyyy");
            }
        }
    }
}

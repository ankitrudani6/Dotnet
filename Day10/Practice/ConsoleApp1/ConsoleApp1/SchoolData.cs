using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    class SchoolData
    {
        SqlConnection connection = null;
        public SchoolData()
        {
            string conString = ConfigurationManager.ConnectionStrings["SchoolDB"].ConnectionString;
            connection = new SqlConnection(conString);
        }
        public List<Person> GetPeople()
        {
            
            List<Person> people = new List<Person>();
            
            try
            {
                string queryString = "Select PersonId, LastName, FirstName, HireDate, Discriminator from Person";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
 
                while (reader.Read())
                {
                    people.Add(new Person() { PersonId = Convert.ToInt32(reader[0].ToString()), LastName = reader[1].ToString(), FirstName = reader[2].ToString(), HireDate = reader[3].ToString()!=""? Convert.ToDateTime(reader[3].ToString()):DateTime.Now, Discriminator = reader[4].ToString() });
                }
                reader.Close();
                connection.Close();
                
            }
            catch(Exception e)
            {
                Console.WriteLine("{0}",e.Message);
            }
            finally
            {
                connection.Close();
            }
            return people;

        }

        public List<Course> GetCourse()
        {

            List<Course> courses = new List<Course>();

            try
            {
                string queryString = "Select * from Course";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    courses.Add(new Course() {CourseId =Convert.ToInt32(reader["CourseId"].ToString()), Title = reader["Title"].ToString(), Credits = Convert.ToInt32(reader["Credits"].ToString()), DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString())  });
                }
                reader.Close();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
            finally
            {
                connection.Close();
            }
            return courses;

        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Models;

namespace WebAPIDemo
{
    public class DataHelper
    {
        private DotnetDBContext DbContext { get; set; }

        public DataHelper()
        {
            DbContext = new DotnetDBContext();
        }

        public async Task<List<Person>> GetPersonList()
        {
            var people = await (from p in DbContext.People
                                select p).ToListAsync();
            
            return people;
        }

        public async Task<Person> GetPerson(int id)
        {
            var person = await (from p in DbContext.People
                                where p.PersonId == id
                                select p).FirstOrDefaultAsync();
            return person;
        }

        public async Task<int> AddPerson(Person person)
        {
            DbContext.Add(person);
            await DbContext.SaveChangesAsync();

            return person.PersonId;
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            var result = await DbContext.People.FirstOrDefaultAsync(p => p.PersonId == person.PersonId);
            if (result != null)
            {
                result.FirstName = person.FirstName;
                result.LastName = person.LastName;
                result.BirthDate = person.BirthDate;
                result.Email = person.Email;
                result.PhoneNumber = person.PhoneNumber;
                result.City = person.City;

                await DbContext.SaveChangesAsync();

                return result;
            }
            
            return null;
        }

        public async Task<int> UpdatePersonField(Person person)
        {
            DbContext.Update(person);
            await DbContext.SaveChangesAsync();

            return person.PersonId;
        }

        public async Task<bool> DeletePerson(int id)
        {
            var person = await DbContext.People.FirstOrDefaultAsync(p => p.PersonId == id);

            if (person != null)
            {
                DbContext.Remove(person);
                await DbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}

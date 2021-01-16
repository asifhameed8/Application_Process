using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.December2020.Web.Abstract;
using Hahn.ApplicatonProcess.December2020.Data.Entities;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class DatabaseController : AppControllerBase<DatabaseController>
    {
        [HttpGet, Route("CreateDatabase")]
        public async Task SeedDatabase()
        {
            await DbContext.Database.EnsureDeletedAsync();
            await DbContext.Database.EnsureCreatedAsync();

            var applicantsList = new List<Applicant>
            {
                new Applicant { Name = "Applicant 1", FamilyName  = "A1", Address  = "California US", CountryOfOrigin ="US", Age=21, EmailAddress  = "Applicant1@gmail.com", Hired = true },
                new Applicant { Name = "Applicant 2", FamilyName  = "A2", Address  = "California US", CountryOfOrigin ="US", Age=22, EmailAddress  = "Applicant2@gmail.com", Hired = true },
                new Applicant { Name = "Applicant 3", FamilyName  = "A3", Address  = "Dubai UAE", CountryOfOrigin ="US", Age=23, EmailAddress  = "Applicant3@yahoo.com", Hired = false }
            };
            for (int i = 0; i < 25; i++)
            {
                applicantsList.Add(new Applicant
                {
                    Name = Faker.Name.FullName(Faker.NameFormats.Standard),
                    FamilyName = Faker.Lorem.Sentence(10),
                    Address = Faker.Address.City(),
                    CountryOfOrigin = Faker.Country.TwoLetterCode(),
                    Age = Faker.RandomNumber.Next(10, 90),
                    EmailAddress = Faker.Internet.Email(),
                    Hired = Faker.Boolean.Random()
                });
            }
            DbContext.Applicants.AddRange(applicantsList);
            await DbContext.SaveChangesAsync();

        }
    }
}

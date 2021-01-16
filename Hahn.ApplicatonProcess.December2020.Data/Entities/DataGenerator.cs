using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Data.Entities
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>()))
            {
                // Look for any Applicants.
                if (context.Applicants.Any())
                {
                    return;   // Data was already seeded
                }
                context.Database.EnsureDeletedAsync();
                context.Database.EnsureCreatedAsync();

                var applicantsList = new List<Applicant>
            {
                new Applicant { Name = "Applicant 1", FamilyName  = "A1", Address  = "California US", CountryOfOrigin ="US", Age=21, EmailAddress  = "Applicant1@gmail.com", Hired = true },
                new Applicant { Name = "Applicant 2", FamilyName  = "A2", Address  = "California US", CountryOfOrigin ="US", Age=22, EmailAddress  = "Applicant2@gmail.com", Hired = true },
                new Applicant { Name = "Applicant 3", FamilyName  = "A3", Address  = "Dubai UAE", CountryOfOrigin ="US", Age=23, EmailAddress  = "Applicant3@yahoo.com", Hired = false }
            };
                context.Applicants.AddRange(applicantsList);
                context.SaveChangesAsync();
            }
        }
    }
}

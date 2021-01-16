using Hahn.ApplicatonProcess.December2020.Data.Entities;
using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Data.ExampleData
{
    public class ApplicantModelExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new ApplicantModel
            {
                ID = 0,
                Name = "Applicant 1",
                FamilyName = "A1",
                Address = "Test Address",
                EmailAddress = "Applicant1@gmail.com",
                Age = 22,
                Hired = true
                
            };
        }
    }
}

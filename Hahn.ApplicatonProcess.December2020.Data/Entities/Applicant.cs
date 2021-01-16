using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Data.Entities
{
    public class Applicant
    {
        public int ID { get; set; }
        [DefaultValue("Applicant 1")]
        public string Name { get; set; }
        [DefaultValue("A1")]
        public string FamilyName { get; set; }
        [DefaultValue("Applicant Address")]
        public string Address { get; set; }
        [DefaultValue("Applicant origin")]
        public string CountryOfOrigin { get; set; }
        [DefaultValue("Applicant1@gmail.com")]
        public string EmailAddress { get; set; }
        [DefaultValue(22)]

        public int Age { get; set; }

        public bool Hired { get; set; }
    }
}

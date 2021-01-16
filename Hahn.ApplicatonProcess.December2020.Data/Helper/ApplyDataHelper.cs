using Hahn.ApplicatonProcess.December2020.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    public class ApplyDataHelper 
    {
        private IServiceCollection serviceProvider;
        //#region lets you specify a block of code that you can expand or collapse when using the outlining feature of the Visual Studio Code Editor. 
        #region Applicant

        //Create a list of Applicant objects and call this function GetAllApplicant
        public static List<Applicant> GetAllApplyData(ApplicationContext _dbContext)
        {

            //using (var _dbContext = new ApplicationContext(
            //       serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>()))
            //{
                //Initialize list as a List of EmployeeCustom objects
                List<Applicant> list = new List<Applicant>();

                //getting list of Applicants
                list = _dbContext.Applicants.ToList();
                Applicant applicant = new Applicant();
                foreach (var item in list)
                {
                    applicant.ID = item.ID;
                    applicant.Name = item.Name;
                    applicant.FamilyName = item.FamilyName;
                    applicant.EmailAddress = item.EmailAddress;
                    applicant.Age = item.Age;
                    applicant.CountryOfOrigin = item.CountryOfOrigin;
                    applicant.Address = item.Address;
                    applicant.Hired = item.Hired;
                }
            return list;

        //}
        }

        public static Applicant GetApplicantByID(int Id, ApplicationContext _dbContext)
        {
            Applicant applicant = new Applicant();
                //Finding Applicant record by Id
                applicant = _dbContext.Applicants.Where(a => a.ID == Id).FirstOrDefault();
            return applicant;
        }
        public static String SaveOrUpdateApplicant(Applicant applicant, ApplicationContext _dbContext)
        {
            
                var list = new List<Applicant>();
                if (applicant.ID > 0)
                {

                    var local = _dbContext.Set<Applicant>()
                         .Local
                         .FirstOrDefault(f => f.ID == applicant.ID);
                    if (local != null)
                    {
                        _dbContext.Entry(local).State = EntityState.Detached;
                    }
                    _dbContext.Entry(applicant).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return "Success";

                }
                else
                {
                    var applicantExist = _dbContext.Applicants.Where(a => a.Name == applicant.Name).FirstOrDefault();
                    if (applicantExist == null)
                    {
                        _dbContext.Applicants.Add(applicant);
                        _dbContext.SaveChanges();
                        return "Success";
                    }
                    else
                    {
                        return "Already Exist";
                    }
                }
        }
        public static Applicant DeleteApplicantByID(Applicant applicant, ApplicationContext _dbContext)
        {
            
                var list = new List<Applicant>();
                //Finding Applicant record by Id
                applicant = _dbContext.Applicants.Where(a => a.ID == applicant.ID).FirstOrDefault();
                //Removing Applicant record from database by Id
                _dbContext.Applicants.Remove(applicant);
                _dbContext.SaveChanges();
                //getting remaining list of Applicants
                list = _dbContext.Applicants.ToList();
                Applicant obj = new Applicant();
                foreach (var item in list)
                {

                    obj.ID = item.ID;
                    obj.Name = item.Name;
                    obj.FamilyName = item.FamilyName;
                    obj.Age = item.Age;
                    obj.Address = item.Address;
                    obj.EmailAddress = item.EmailAddress;
                    obj.Hired = item.Hired;
                }
                return obj;
        }
        #endregion
    }
}
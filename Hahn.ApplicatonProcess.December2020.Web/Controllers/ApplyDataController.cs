using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.December2020.Data.Entities;
using Microsoft.Extensions.Logging;
using Hahn.ApplicatonProcess.December2020.Data.ExampleData;
using Swashbuckle.Examples;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [ApiController]
   [Route("[controller]")]
    public class ApplyDataController : ControllerBase
    {
        private ApplicationContext _dbContext;
        private readonly ILogger _logger;
        public ApplyDataController(ApplicationContext dbContext, ILogger<ApplyDataController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        private IConfiguration _config;
        
        [Route("GetData")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = new List<Applicant>();
            
            try
            {
                list =  _dbContext.Applicants.ToList();
                return Ok(list);
            }
            
            catch (Exception ex)
            {

                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };
                return Ok(response);
            }
        }

        [Route("GetDataById")]
        [HttpGet]
        public async Task<IActionResult> GetDataById(int ID)
        {
            try
            {
                var applicant = _dbContext.Applicants.Where(a => a.ID == ID).FirstOrDefault();
                return this.Ok(applicant);
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };
                return this.Ok(response);
            }
        }
        /// <summary>
        /// SaveOrUpdate Applicant Form
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post / SaveData
        ///     {
        ///        "ID": 0,
        ///        "Name": "Applicant",
        ///        "FamilyName": "A1",
        ///        "Address":"Applicant Address",
        ///        "EmailAddress": "Applicant@gmail.com",
        ///        "Age" : 22,
        ///        "Hired" = true
        ///     }
        /// </remarks>
        [Route("SaveData")]
        [HttpPost]
        [SwaggerRequestExample(typeof(ApplicantModel), typeof(ApplicantModelExample))]
        public async Task<IActionResult> SaveOrUpdate(Applicant applicant)
        {
            try
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
                        return this.Ok("Success");
                    
                }
                else
                {
                    var applicantExist = _dbContext.Applicants.Where(a => a.Name == applicant.Name).FirstOrDefault();
                    if (applicantExist == null)
                    {
                        _dbContext.Applicants.Add(applicant);
                        _dbContext.SaveChanges();
                        return this.Ok("Success");
                    }
                    else
                    {
                        return this.Ok("Already Exist");
                    }
                }

            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };
                return this.Ok(response);
            }
        }

        [Route("PutData")]
        [HttpPut]
        public void Put(Applicant applicant)
        {
        }

        [Route("DeleteData")]
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int ID)
        {
            try
            {
                var list = new List<Applicant>();
                var applicant = _dbContext.Applicants.Where(a => a.ID == ID).FirstOrDefault();
                _dbContext.Applicants.Remove(applicant);
                _dbContext.SaveChanges();
                list = _dbContext.Applicants.ToList();
                return this.Ok(list);
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };
                return this.Ok(response);
            }
        }
        
    }
}

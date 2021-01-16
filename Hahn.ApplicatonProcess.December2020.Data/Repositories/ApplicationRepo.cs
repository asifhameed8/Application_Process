using Hahn.ApplicatonProcess.December2020.Data.Entities;
using Hahn.ApplicatonProcess.December2020.Data.Repositories.Base;
using Hahn.ApplicatonProcess.December2020.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Data.Repositories
{
    public class ApplicationRepo : GenericRepository<Applicant>, IApplicationRepository
    {
        private readonly DbSet<Applicant> _applicants;
        public ApplicationRepo(ApplicationContext dbContext)
            : base(dbContext) {
           // _applicants = dbContext.Set<Applicant>();
        }
    }

    public interface IApplicationRepository : IGenericRepository<Applicant>
    {
    }
}

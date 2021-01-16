using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Data.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Have to define Topics abstract class to have a table to have all 
            // sub classes appear in the same base table with a discriminator column
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Applicant> Applicants { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrePass.Models;
using PrePass.Models.ViewModels;

namespace PrePass.Data
{
    public class PrePassContext : DbContext
    {

          public PrePassContext(DbContextOptions<PrePassContext> options)
            : base(options)
        {

        }

        public DbSet<PrePass.Models.Staff> Staff { get; set; }
        public DbSet<PrePass.Models.Applicant> Applicants { get; set; }
        public DbSet<PrePass.Models.District> Districts { get; set; }

        public DbSet<PrePass.Models.Assessment> Assessments { get; set; }

        public DbSet<PrePass.Models.Session> Sessions { get; set; }

//        public DbSet<PrePass.Models.Report> Report { get; set; }

    }
}

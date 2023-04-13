using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalProject.Models
{
    public class ProjectDbContext : DbContext
    {

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {




        }

        public DbSet<HospitalEntity> tblHospital { get; set; }
        public DbSet<PatientEntity> tblPatients { get; set; }

       public DbSet<DepartmentEntity> tblDepartments { get; set; }

        public DbSet<LabEntity> tblLab { get; set; }
        public DbSet<DrEntity> tblDr { get; set; }


        public DbSet<PharmacyEntity> tblPharmacy { get; set; }
        public DbSet<PharmacistEntity> tblPharmacist { get; set; }
    }
}



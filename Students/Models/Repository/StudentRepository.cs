using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Students.Models.Repository
{
    public class StudentRepository : DbContext
    {
        public StudentRepository()
            : base("DefaultConnection")
        {
            Database.SetInitializer<StudentRepository>(new CreateDatabaseIfNotExists<StudentRepository>());

        }
        public DbSet<Address> Address { get; set; }

        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
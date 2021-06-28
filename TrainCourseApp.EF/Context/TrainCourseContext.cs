using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainCourseApp.EF.Configuration;
using TrainCourseApp.Model;

namespace TrainCourseApp.EF.Context {
    public class TrainCourseContext : DbContext {

        protected TrainCourseContext() : base() {
        }


        public TrainCourseContext(DbContextOptions options) : base(options) {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-B2H5QAB\SQLEXPRESS;Initial Catalog=DbTrainCourse;Trusted_Connection=True;");



            base.OnConfiguring(optionsBuilder);
        }
        //Server=DESKTOP-B2H5QAB\SQLEXPRESS;Database=FuelStation;Trusted_Connection=True;


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }


    }
}

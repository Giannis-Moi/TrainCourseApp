using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainCourseApp.EF.Context {
    class TrainCourseContextFactory : IDesignTimeDbContextFactory<TrainCourseContext> {
        public TrainCourseContext CreateDbContext(string[] args) {

            var optionsBuilder = new DbContextOptionsBuilder<TrainCourseContext>();

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-B2H5QAB\SQLEXPRESS;Initial Catalog=DbTrainCourse;Trusted_Connection=True;");

            return new TrainCourseContext(optionsBuilder.Options);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainCourseApp.Model;

namespace TrainCourseApp.EF.Configuration {
    public class CourseConfiguration : IEntityTypeConfiguration<Course> {
        public void Configure(EntityTypeBuilder<Course> builder) {

            builder.ToTable("Course", "School");
            builder.HasKey(Course => Course.Id);
            builder.Property(Course => Course.Id).ValueGeneratedOnAdd();
            builder.Property(Course => Course.Title).HasMaxLength(100).IsRequired(true);
            builder.Property(Course => Course.Category).HasMaxLength(100).IsRequired(true);
            builder.Property(Course => Course.Date).IsRequired(true);
        }
    }
}

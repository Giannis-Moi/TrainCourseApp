using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainCourseApp.Model;

namespace TrainCourseApp.EF.Configuration {
    public class StudentConfiguration : IEntityTypeConfiguration<Student> {
        public void Configure(EntityTypeBuilder<Student> builder) {

            builder.ToTable("Student", "School");

            builder.HasKey(Student => Student.Id);
            builder.Property(Student => Student.Id).ValueGeneratedOnAdd();
            builder.Property(Student => Student.Name).HasMaxLength(100).IsRequired(true);
            builder.Property(Student => Student.Surname).HasMaxLength(100).IsRequired(true);
            builder.Property(Student => Student.Birthdate).IsRequired(true);
            builder.Property(Student => Student.Address).HasMaxLength(100).IsRequired(true); 




        }
    }
}
    


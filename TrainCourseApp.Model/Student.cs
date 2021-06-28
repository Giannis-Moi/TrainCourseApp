using System;

namespace TrainCourseApp.Model {
    public class Student : EntityBase {

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthdate { get; set; }

        public string Address { get; set; }
    }
}

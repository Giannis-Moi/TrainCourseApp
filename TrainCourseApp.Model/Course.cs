using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainCourseApp.Model {
     public class Course : EntityBase {

        public string Title { get; set; }

        public string Category { get; set; }

        public DateTime Date { get; set; }

        public int Duration { get; set; }


    }
}

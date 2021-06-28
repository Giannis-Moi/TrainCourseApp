using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainCourseApp.EF.Context;
using TrainCourseApp.Model;

namespace TrainCourseApp {
    public partial class CourseForm : Form {


        private TrainCourseContext _trainCourseContext;
       
        public CourseForm() {
            InitializeComponent();

            bindingSource1.DataSource = typeof(Course);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;

            textBox1.DataBindings.Add("Text", bindingSource1, "Title");
            textBox2.DataBindings.Add("Text", bindingSource1, "Category");

            //textBox3.DataBindings.Add("Text", bindingSource1, "Date");
            textBox4.DataBindings.Add("Text", bindingSource1, "Duration");
        }

        private void CourseForm_Load(object sender, EventArgs e) {

            var optionsBuilder = new DbContextOptionsBuilder<TrainCourseContext>();

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-B2H5QAB\SQLEXPRESS;Initial Catalog=DbTrainCourse;Trusted_Connection=True;");


            _trainCourseContext = new TrainCourseContext(optionsBuilder.Options);

            Refresh();

        }

        private void CourseForm_FormClosed(object sender, FormClosedEventArgs e) {

            _trainCourseContext.Dispose();

        }

        private void button4_Click(object sender, EventArgs e) {

            _trainCourseContext.SaveChanges();

        }

        private void button2_Click(object sender, EventArgs e) {

            var course = bindingSource1.Current as Course;
            if (course is null)
                return;

            bindingSource1.RemoveCurrent();

            _trainCourseContext.Courses.Remove(course);




        }

        private void Refresh() {


            bindingSource1.Clear();
            _trainCourseContext.ChangeTracker.Clear();
            foreach (var course in _trainCourseContext.Courses.ToList()) {

                bindingSource1.Add(course);
            }
        }

        private void button3_Click(object sender, EventArgs e) {

            Refresh();
        }

        private void button1_Click(object sender, EventArgs e) {

            var newCourse = new Course();
            newCourse.Title = "No title";

            bindingSource1.Insert(0, newCourse);
            _trainCourseContext.Courses.Add(newCourse);



        }
    }
    }


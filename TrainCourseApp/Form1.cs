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
    public partial class Form1 : Form {

        private TrainCourseContext _trainCourseContext;
        public Form1() {
            InitializeComponent();
            bindingSource1.DataSource = typeof(Student);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;

            textBox1.DataBindings.Add("Text", bindingSource1, "Name");
            textBox2.DataBindings.Add("Text", bindingSource1, "Surname");

            //textBox3.DataBindings.Add("Text", bindingSource1, "Birthday");
            textBox4.DataBindings.Add("Text", bindingSource1, "Address");
        }

        private void Form1_Load(object sender, EventArgs e) {


            var optionsBuilder = new DbContextOptionsBuilder<TrainCourseContext>();

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-B2H5QAB\SQLEXPRESS;Initial Catalog=DbTrainCourse;Trusted_Connection=True;");


            _trainCourseContext = new TrainCourseContext(optionsBuilder.Options);

            Refresh();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {


            _trainCourseContext.Dispose();
        }

        private void button1_Click(object sender, EventArgs e) {

            _trainCourseContext.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e) {

            var student = bindingSource1.Current as Student;
            if (student is null)
                return;

            bindingSource1.RemoveCurrent();

            _trainCourseContext.Students.Remove(student);

        }

        private void button3_Click(object sender, EventArgs e) {

            Refresh();

        }


        private void Refresh() {


            bindingSource1.Clear();
            _trainCourseContext.ChangeTracker.Clear();
            foreach (var student in _trainCourseContext.Students.ToList()) {

                bindingSource1.Add(student);
            }
        }

        private void button4_Click(object sender, EventArgs e) {

            var newStudent = new Student();
            newStudent.Name = "No name";

            bindingSource1.Insert(0, newStudent);
            _trainCourseContext.Students.Add(newStudent);

        }
    }
}

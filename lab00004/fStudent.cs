﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace lab00004
{
    public partial class fStudent : Form
    {
        public Student TheStudent;
        public fStudent(Student t)
        {
            TheStudent = t;
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void btnOK_Click1(object sender, EventArgs e)
        {
            TheStudent.Name = tbName.Text.Trim();
            TheStudent.Surname = tbSurname.Text.Trim();
            TheStudent.Age = int.Parse(tbAge.Text.Trim());
            TheStudent.University = tbUniversity.Text.Trim();
            TheStudent.Specialty = tbSpecialty.Text.Trim();
            TheStudent.Year = int.Parse(tbYear.Text.Trim());
            TheStudent.Rating1 = int.Parse(tbRating1.Text.Trim());
            TheStudent.Rating2 = int.Parse(tbRating2.Text.Trim());
            TheStudent.Rating3 = int.Parse(tbRating3.Text.Trim());
            TheStudent.Scholarship = chbScholarship.Checked;
            DialogResult = DialogResult.OK;
        }
        private void fStudent_Load(object sender, EventArgs e)
        {
            if (TheStudent != null)
            {
                tbName.Text = TheStudent.Name;
                tbSurname.Text = TheStudent.Surname;
                tbAge.Text = TheStudent.Age.ToString();
                tbUniversity.Text = TheStudent.University;
                tbSpecialty.Text = TheStudent.Specialty;
                tbYear.Text = TheStudent.Year.ToString();
                tbRating1.Text = TheStudent.Rating1.ToString();
                tbRating2.Text = TheStudent.Rating2.ToString();
                tbRating3.Text = TheStudent.Rating3.ToString();
                chbScholarship.Checked = TheStudent.Scholarship;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

    }
}
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab00004
{
    public partial class fMain : Form
    {
        BindingSource studentsBindingSource = new BindingSource();

        public fMain()
        {
            InitializeComponent();
            btnExit.Alignment = ToolStripItemAlignment.Right;
            this.Load += fMain_Load;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int buttonsSize = 5 * btnAdd.Width + 2 * tsSeparator1.Width + 30;
            btnExit.Margin = new Padding(Width - buttonsSize, 0, 0, 0);
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            gvStudents.AutoGenerateColumns = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn { DataPropertyName = "Name", Name = "Ім'я студента" };
            gvStudents.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { DataPropertyName = "Surname", Name = "Прізвище" };
            gvStudents.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { DataPropertyName = "Age", Name = "Вік" };
            gvStudents.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { DataPropertyName = "University", Name = "Університет" };
            gvStudents.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { DataPropertyName = "Specialty", Name = "Спеціальність" };
            gvStudents.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { DataPropertyName = "Year", Name = "Рік навчання" };
            gvStudents.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { DataPropertyName = "Rating1", Name = "Оцінка №1" };
            gvStudents.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { DataPropertyName = "Rating2", Name = "Оцінка №2" };
            gvStudents.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { DataPropertyName = "Rating3", Name = "Оцінка №3" };
            gvStudents.Columns.Add(column);

            column = new DataGridViewCheckBoxColumn { DataPropertyName = "Scholarship", Name = "Стипендія" };
            gvStudents.Columns.Add(column);

            var students = new List<Student> { new Student("Олександр", "Рудик", 18, "ВНТУ", "ІСТ", 2024, 95, 90, 80, true) };

            studentsBindingSource.DataSource = students;
            gvStudents.DataSource = studentsBindingSource;

            EventArgs args = new EventArgs();
            OnResize(args);
            gvStudents.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student newStudent = new Student();

            fStudent ft = new fStudent(newStudent);

            if (ft.ShowDialog() == DialogResult.OK)
            {
                studentsBindingSource.Add(newStudent);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Student student = (Student)bindScrStudents.List[bindScrStudents.Position];

            fStudent ft = new fStudent(student);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindScrStudents.List[bindScrStudents.Position] = student;
            }
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Видалити поточний запис", "Видалення запису", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                studentsBindingSource.RemoveCurrent();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистити таблюцю?\n\nВсі данні будуть втрачені", "Очищення данних", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                studentsBindingSource.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрити застосунок", "Вихід з програми", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void gvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}

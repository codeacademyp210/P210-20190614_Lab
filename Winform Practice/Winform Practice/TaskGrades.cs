using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform_Practice.Models;
using Task = Winform_Practice.Models.Task;

namespace Winform_Practice
{
    public partial class TaskGrades : Form
    {
        private readonly int _taskId;
        Grade gr;

        public TaskGrades(int taskId)
        {
            InitializeComponent();
            _taskId = taskId;
        }

        private void TaskGrades_Load(object sender, EventArgs e)
        {
            FillGrades();
        }

        private void FillGrades()
        {
            AcademyManagementEntities db = new AcademyManagementEntities();

            Task task = db.Tasks.FirstOrDefault(t => t.Id == _taskId);

            List<Student> students = db.Students.Where(s=>s.GroupID == task.GroupID ).ToList();

            foreach (var student in students)
            {
                Grade grade = student.Grades.FirstOrDefault(g=> g.TaskID == task.Id);

                if (grade != null)
                {
                    dgvTaskGrades.Rows.Add(grade.Id,
                                       student.Id,
                                       student.Name,
                                       grade.Grade1);
                } else
                {
                    dgvTaskGrades.Rows.Add(null,
                                            student.Id,
                                            student.Name,
                                            null);
                }

                

            }

        }

        private void dgvTaskGrades_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AcademyManagementEntities db = new AcademyManagementEntities();

            int stuId;

            if (dgvTaskGrades.Rows[e.RowIndex].Cells[0].Value == null)
            {
                gr = new Models.Grade();
                gr.TaskID = _taskId;
                gr.StudentID = (int)dgvTaskGrades.Rows[e.RowIndex].Cells[1].Value;
            } else
            {

                int grade = Convert.ToInt32(dgvTaskGrades.Rows[e.RowIndex].Cells[0].Value);
                gr = db.Grades.FirstOrDefault(g => g.Id == grade);
                //grade = (int)dgvTaskGrades.Rows[e.RowIndex].Cells[3].Value;
                //stuId = (int)dgvTaskGrades.Rows[e.RowIndex].Cells[1].Value;

            }
            
            //  int gradeID = (int)dgvTaskGrades.Rows[e.RowIndex].Cells[0].Value;

            if (gr.Id != 0)
            {
                txtGrade.Text = gr.Grade1.ToString();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AcademyManagementEntities db = new AcademyManagementEntities();

            gr.Grade1 = Convert.ToInt32(txtGrade.Text);
            if (gr.Id == 0)
            {
                db.Grades.Add(gr);
            }
            else
            {
                Grade updatedGrade = db.Grades.FirstOrDefault(g => g.Id == gr.Id);
                updatedGrade.Grade1 = gr.Grade1;
               // db.Entry(gr).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
        }
    }
}

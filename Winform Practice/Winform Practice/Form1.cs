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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillTasks();
        }

        private void FillTasks()
        {
            AcademyManagementEntities db = new AcademyManagementEntities();

            List<Task> tasks = db.Tasks.ToList();

            foreach (var task in tasks)
            {
                dgvTasks.Rows.Add(task.Id, 
                                  task.Group.Id,
                                  task.Name,
                                  task.Deadline,
                                  task.Group.Name);
            }


        }

        private void dgvTasks_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int taskID = (int)dgvTasks.Rows[e.RowIndex].Cells[0].Value;
            TaskGrades task = new TaskGrades(taskID);
            task.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_for_Project
{
    public partial class ContentsPage : Form
    {
        public ContentsPage()
        {
            InitializeComponent();
        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }

        private void GoToTeacher_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form TeacherPage = new TeacherPage();
            TeacherPage.ShowDialog();
            this.Close();
        }

        private void GoToStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form StudentPage = new StudentPage();
            StudentPage.ShowDialog();
            this.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

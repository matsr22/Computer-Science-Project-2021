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
    public partial class TeacherPage : Form
    {
        public TeacherPage()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Contents = new ContentsPage();
            Contents.ShowDialog();
            this.Close();
        }
    }
}

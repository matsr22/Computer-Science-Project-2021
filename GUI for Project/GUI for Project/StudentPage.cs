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
    public partial class StudentPage : Form
    {
        public StudentPage()
        {
            InitializeComponent();
        }

        private void Return(object sender, EventArgs e)
        {
            this.Hide();
            Form Contents = new ContentsPage();
            Contents.ShowDialog();
            this.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void OpenLearningModule_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form LearningMods = new LearningModules();
            LearningMods.ShowDialog();
            this.Close();
        }

        private void CustomBuilder_Click(object sender, EventArgs e)
        {
            Hide();
            CustomCircuitBuilder CustomBuilder = new CustomCircuitBuilder();
            CustomBuilder.ShowDialog();
            Close();
        }
    }
}

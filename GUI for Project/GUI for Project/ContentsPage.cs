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
            Hide();
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
            Close();

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

        private void CreditsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creation: Me\nElectronics Advice and stuff:Mike Rose\nGeneral Coding Advice: Computing Friends");
        }
    }
}

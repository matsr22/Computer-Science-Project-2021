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
    public partial class LearningModules : Form
    {
        public LearningModules()
        {
            InitializeComponent();
        }
        // All the following just Open up new instances of forms when the user selects them with a button click
        private void ParraResistors_Click(object sender, EventArgs e)
        {
            Hide();
            ComponentsInParrallel ParrallelResistors = new ComponentsInParrallel();
            ParrallelResistors.ShowDialog();
            Close();
        }

        private void PowLaws_Click(object sender, EventArgs e)
        {
            Hide();
            Power PowerLawDemos = new Power();
            PowerLawDemos.ShowDialog();
            Close();
        }

        private void Ohms_Click(object sender, EventArgs e)
        {
            Hide();
            OhmsLaw OhmsLawDemo = new OhmsLaw();
            OhmsLawDemo.ShowDialog();
            Close();
        }
    }
}

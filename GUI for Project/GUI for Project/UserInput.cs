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
    public partial class InputForm : Form
    {
        public string data;
        private string[] UnitPrefixes = new string[] {"", "n", "µ", "m", "k","M","G"};
        private string[] PrefixForShowing;
        public string ChosenPrefix;
        public InputForm(string instruction,char UnitPrefix)
        {
            InitializeComponent();
            InstructionLabel.Text = instruction;
            PrefixForShowing = UnitPrefixes;
            for (int i = 0;i<PrefixForShowing.Length;i++)
            {
                PrefixForShowing[i] = PrefixForShowing[i] + UnitPrefix;
            }
            UnitListBox.DataSource = PrefixForShowing;
            InstructionLabel.BackColor = SettingsVariables.ControlBackgroundColour;
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (InputBox.Text != "" )
                {

                    data = (InputBox.Text);
                    ChosenPrefix = UnitListBox.Text;
                    Close();
                }
                else
                {
                    MessageBox.Show("Please enter a correct value");
                }
            }

        }
    }
}

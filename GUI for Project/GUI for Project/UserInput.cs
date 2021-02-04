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
        Form1 ToGoBackTo;
        public InputForm(Form1 sender,string instruction)
        {
            InitializeComponent();
            ToGoBackTo = sender;
            InstructionLabel.Text = instruction;
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (InputBox.Text != "" )
                {

                    data = (InputBox.Text);
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

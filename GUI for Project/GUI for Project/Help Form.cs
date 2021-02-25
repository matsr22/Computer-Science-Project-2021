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
    public partial class Help_Form : Form
    {
        public Help_Form(string Title, string Contents)
        {
            InitializeComponent();
            TitleLabel.Text = Title;
            ContentsLabel.Text = Contents;
        }
    }
}

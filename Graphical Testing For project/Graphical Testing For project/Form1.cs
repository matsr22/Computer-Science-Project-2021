using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Testing_For_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Label NumberLabel = new Label() { Anchor = AnchorStyles.Top | AnchorStyles.Left, Text = "Hi" };
            Label Label2 = new Label() { Anchor = AnchorStyles.Right | AnchorStyles.Bottom, Text = "ssdf" };
            Thing1.Controls.Add(NumberLabel);
            Thing1.Controls.Add(Label2);
        }
    }
}

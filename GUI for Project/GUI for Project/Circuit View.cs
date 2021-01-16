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
    public partial class Form1 : Form
    {
        private int TopOffset = 0;
        private int RightOffset = 200;
        private DataGridView ComponentGrid;
        private List<ComponentRow> ComponentGridElements;

        public Form1()
        {

            InitializeComponent();
            CreatePanel();
        }
        public void CreatePanel()
        {
            ComponentGrid = new DataGridView();
            ComponentGrid.Parent = this;
            ComponentGrid.Location = new Point(RightOffset, TopOffset);
            ComponentGrid.Name = "Components";
            ComponentGrid.TabIndex = 0;
            ComponentGrid.ColumnHeadersVisible = false; // You could turn this back on if you wanted, but this hides the headers that would say, "Cell1, Cell2...."
            ComponentGrid.RowHeadersVisible = false;
            ComponentGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ComponentGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            ComponentGrid.Size = new Size(ClientRectangle.Width - RightOffset, ClientRectangle.Height - TopOffset);
            ComponentGrid.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            ComponentGrid.BackColor = Color.Aqua;
            this.ResumeLayout(false);
            ComponentGrid.Visible = true;
            this.Controls.Add(ComponentGrid);
            FillPanel();
            TestingClass();
        }
        public void TestingClass()
        {
            ComponentGridElements[0].Cell1.Image = new Bitmap(@"C:\Users\matth\source\repos\matsr22\Computer-Science-Project-2021\GUI for Project\GUI for Project\Images\Across_1.jpg");
            ComponentGridElements[0].Cell1.ClientSize = new Size(10, 10);
            ComponentGridElements[0].Cell1.Dock = DockStyle.Fill;
            ComponentGridElements[0].Cell1.Show();
            ComponentGrid.Refresh();
        }
        public class ComponentRow
        {
            public PictureBox Cell1 = new PictureBox();
            public PictureBox Cell2 = new PictureBox();
            public PictureBox Cell3 = new PictureBox();
            public PictureBox Cell4 = new PictureBox();
            public PictureBox Cell5 = new PictureBox();
            public PictureBox Cell6 = new PictureBox();
            public PictureBox Cell7 = new PictureBox();
            public PictureBox Cell8 = new PictureBox();
            public PictureBox Cell9 = new PictureBox();
            public PictureBox Cell10 = new PictureBox();
            public PictureBox Cell11 = new PictureBox();
            public PictureBox Cell12 = new PictureBox();
            public PictureBox Cell13 = new PictureBox();
        }
        public void FillPanel()
        {
            ComponentGridElements = new List<ComponentRow>();
            for (int i = 0; i < 13; i++)
            {
                ComponentGridElements.Add(new ComponentRow());
            }
            ComponentGrid.DataSource = ComponentGridElements;
        }


        /*private void Form1_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.Size = new Size(ClientRectangle.Width - RightOffset, ClientRectangle.Height - TopOffset);
        }
        */
    }
}

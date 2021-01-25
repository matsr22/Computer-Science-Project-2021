using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Physics_Engine ;

namespace GUI_for_Project
{
    public partial class Form1 : Form
    {
        

        private string ImageDefaultPath = @"C:\Users\matth\source\repos\matsr22\Computer-Science-Project-2021\GUI for Project\GUI for Project\Images\";// This is where most images will be kept
        private int numRows;
        private int numColls;
        public Form1()
        {

            InitializeComponent();
            numRows = ComponentList.RowCount;
            numColls = ComponentList.ColumnCount;
            CreatePanel();
            ResetPanel();
        }
        public void CreatePanel()
        {
            for (int x = 0;x< numColls;x++)
            {
                for (int y = 0; y < numRows; y++)
                {
                    AddPicture(CreatePath("White.png"), x, y); // Fills the TableLayoutPanel with blank images
                }
            }

            
            
        }
        public void ResetPanel()
        {
            for (int x = 0; x < numColls; x++)
            {
                for (int y = 0; y < numRows; y++)
                {
                    ModifyPicture(CreatePath("White.png"), x, y,null); // Resets the TableLayoutPanel with blank images
                }
            }
            for (int x = 0; x < numRows; x++) // Makes the Vertical Wires
            {

                ModifyPicture(CreatePath("Down.png"), x, 0, null);
                ModifyPicture(CreatePath("Down.png"), x, numColls - 1, null);
            }

            for (int y = 0; y < numColls; y++)//Makes the Horizontal Wires
            {
                ModifyPicture(CreatePath("Across.png"), 0, y, null);
                ModifyPicture(CreatePath("Across.png"), numRows - 1, y, null);
            }
            //Makes the Corners
            ModifyPicture(CreatePath("RightBottom.png"), 0, 0, null);
            ModifyPicture(CreatePath("TopRight.png"), numRows - 1, 0, null);
            ModifyPicture(CreatePath("TopLeft.png"), numRows - 1, numColls - 1, null);
            ModifyPicture(CreatePath("LeftBottom.png"), 0, numColls - 1, null);
        }
        public void AddPicture(string path,int x,int y)// Adds the blank picture
        {

            ComponentList.Controls.Add(new PictureBox() { Image = Image.FromFile(path), SizeMode = PictureBoxSizeMode.StretchImage, Margin = new Padding(0), Dock = DockStyle.Fill }, x,y);
        }
        public string CreatePath(string ImagePath)
        {
            return ImageDefaultPath + ImagePath;
        }
        
        public void ModifyPicture (string path, int x, int y,string value)
        {
            int index = x + y * ComponentList.RowCount;
            PictureBox PanelToModify = (PictureBox)ComponentList.Controls[index];
            ModifyComponentImage(path, value, ref PanelToModify);


        }
        public void ModifyComponentImage(string path, string AssignedValue, ref PictureBox ImagePictureBox)// Needs cleaning up as reusing from earlier itterations
        {
            ImagePictureBox.Controls.Clear();
            ImagePictureBox.Image = Image.FromFile(path);
            ImagePictureBox.Resize -= ImageResizer; // This removes any previous event handler bc for some reason having more than one breaks stuff
            if (AssignedValue != null)
            {
                Label ValueOfComponent = new Label();
                ValueOfComponent.Text = AssignedValue;
                ValueOfComponent.BackColor = Color.Transparent;
                ValueOfComponent.Dock = DockStyle.Bottom;
                ImagePictureBox.Controls.Add(ValueOfComponent);
                ImagePictureBox.Resize += ImageResizer;
            }

            
        }
        public void DrawSection(ResistiveComponent component,int StartingX,int StartingY)
        {
             if (component.GetType().Name == "ResistiveComponent")
             {
                ModifyPicture("Resistor.png",StartingX,StartingY,component.GetResistance().ToString()); // This code may have to be changed if I need to make the resistor into a 2x1 image rather than a 1x1
             }
             else if (component.GetType().Name == "ParrallelComponent")
            {
                //foreach (ResistiveComponent element in ParraComponent)
            }
        }
        private void ImageResizer(object sender, EventArgs e) // Resizes the text under a component so it is consistant
        {
            PictureBox ToBeResized = sender as PictureBox;
            if (ToBeResized != null)
            {
                int height = ToBeResized.Height;
                int width = ToBeResized.Width;
                ToBeResized.Controls[0].Height = Convert.ToInt32(height * 0.3); 
                ToBeResized.Controls[0].Width = Convert.ToInt32(width * 0.5);
            }
        }



}
}

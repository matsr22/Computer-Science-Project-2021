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
        private string ImageDefaultPath = @"C:\Users\matth\source\repos\matsr22\Computer-Science-Project-2021\GUI for Project\GUI for Project\Images\";
        private DataGridView ComponentGrid;

        public Form1()
        {

            InitializeComponent();
            CreatePanel();
        }
        public void CreatePanel()
        {
            for (int x = 0;x< ComponentList.ColumnCount;x++)
            {
                for (int y = 0; y < ComponentList.RowCount; y++)
                {
                    AddPicture(ImageDefaultPath + "White.png", x, y);
                }
            }
            for (int x = 0; x < ComponentList.RowCount; x++)
            {

                ModifyPicture(ImageDefaultPath + "Down.png", x, 0);
                ModifyPicture(ImageDefaultPath + "Down.png", x, ComponentList.ColumnCount-1);
            }
            
            for (int y = 0; y < ComponentList.ColumnCount; y++)
            {
                ModifyPicture(ImageDefaultPath+"Across.png", 0, y);
                ModifyPicture(ImageDefaultPath + "Across.png", ComponentList.RowCount-1, y);
            }
            
            ModifyPicture(ImageDefaultPath + "RightBottom.png", 0, 0);
            ModifyPicture(ImageDefaultPath + "TopRight.png", ComponentList.RowCount-1 , 0);
            ModifyPicture(ImageDefaultPath + "TopLeft.png", ComponentList.RowCount -1, ComponentList.ColumnCount-1 );
            ModifyPicture(ImageDefaultPath + "LeftBottom.png", 0 , ComponentList.ColumnCount -1);
            
            
        }
        public void AddPicture(string path,int x,int y)
        {

            ComponentList.Controls.Add(new PictureBox() { Image = Image.FromFile(path), SizeMode = PictureBoxSizeMode.StretchImage, Margin = new Padding(0), Dock = DockStyle.Fill }, x,y);
        }
        public void ModifyPicture (string path, int x, int y)
        {
            PictureBox picture = (PictureBox)ComponentList.Controls[x + y * (ComponentList.RowCount )];
            picture.Image = Image.FromFile(path);

        }
        public void TestingClass()
        {

        }
        public void FillPanel()
        {
            
        }

}
}

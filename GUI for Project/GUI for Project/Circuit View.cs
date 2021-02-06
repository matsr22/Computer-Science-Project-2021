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
    public partial class Form1  : Form
    {
        // Local Variables
        #region Locals
        private string ImageDefaultPath = @"C:\Users\matth\source\repos\matsr22\Computer-Science-Project-2021\GUI for Project\GUI for Project\Images\";// This is where most images will be kept
        private int numRows;
        private int numColls;
        private Circuit MainCircuit;
        private int MiddleCollumn;
        #endregion
        public Form1()
        {

            InitializeComponent();
            numRows = ComponentList.RowCount;
            numColls = ComponentList.ColumnCount;
            MiddleCollumn = numColls / 2;
            CreatePanel();
            ResetPanel();
            CreateBasicCircuit();
        }

        // This is stuff that is mainly responsible for the custom builder 
        #region UIFunction
        public void CreateBasicCircuit()// Remove Testing stuff when done
        {
            double Voltage = Convert.ToDouble(GetUserInput("Please Enter the Voltage of the Circuit"));
            double IntRes = Convert.ToDouble(GetUserInput("Please Enter the internal resistance of the Circuit"));
            double InitialResistor = Convert.ToDouble(GetUserInput("Please Enter the Resistance of the first resistor"));
            MainCircuit = new Circuit('v', Voltage, IntRes, InitialResistor);
            DrawCircuit(Voltage);
        }
        public void DrawCircuit(double Voltage)
        {
            ResetPanel();
            DrawSection(MainCircuit.Main, 1, numRows - 1);
            if (MainCircuit.Main.FindComponentFromName("IntRes").GetResistance() == 0)
            {
                ModifyPicture(CreatePath("Cell.png"), MiddleCollumn, 0, Voltage.ToString() + "V");
            }
            else
            {
                ModifyPicture(CreatePath("Cell.png"), MiddleCollumn, 0, Voltage.ToString() + "V");
                GeneralComponent InternalResistance = MainCircuit.Main.FindComponentFromName("IntRes");
                ModifyPicture(CreatePath("ResistorIntRes.png"), MiddleCollumn + 1, 0, InternalResistance.GetResistance() + "Ω");
                
            }
        }
        public void ComponentClick(object sender, EventArgs e)
        {
            PictureBoxWithReference SenderPicture = (PictureBoxWithReference)sender;
            if (SenderPicture.AssosiatedComponent != null)
            {
                switch (ClickActions.SelectedItem.ToString())
                {

                    case ("Edit Values"):
                        double value = Convert.ToDouble(GetUserInput($"What would you like to change the value of {SenderPicture.AssosiatedComponent.GetName()} to ?"));
                        SenderPicture.AssosiatedComponent.AssignResistance(value);
                        Label InternalLabel = ((Label)SenderPicture.Controls[0]);
                        InternalLabel.Text = value.ToString() + "Ω";
                        MainCircuit.Main.CalculateResistance();
                        break;


                    case "Add Resistor In Parrallel":
                        double NewResistanceValue = Convert.ToDouble(GetUserInput("What is the resistance of the new resistor"));
                        MainCircuit.Main.ComponentSearch(SenderPicture.AssosiatedComponent.GetName(), "Insert", new string[] { NewResistanceValue.ToString(), "p" });
                        MainCircuit.RunVoltageCalcs();
                        DrawCircuit(MainCircuit.GetEmfValue());
                        break;
                    case "Add Resistor In Series":
                        double NewResistanceValue2 = Convert.ToDouble(GetUserInput("What is the resistance of the new resistor"));
                        MainCircuit.Main.ComponentSearch(SenderPicture.AssosiatedComponent.GetName(), "Insert", new string[] { NewResistanceValue2.ToString(), "s" });
                        MainCircuit.RunVoltageCalcs();
                        DrawCircuit(MainCircuit.GetEmfValue());
                        break;
                    case "Remove Resistor":
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        //This is stuff required for the circuit simulation to work and is not necessarily part of the custom builder
        #region BasicFunction 
        private void ImageResizer(object sender, EventArgs e) // Resizes the text under a component so it is consistant
        {
            PictureBoxWithReference ToBeResized = sender as PictureBoxWithReference;
            if (ToBeResized != null)
            {
                int height = ToBeResized.Height;
                int width = ToBeResized.Width;
                ToBeResized.Controls[0].Height = Convert.ToInt32(height * 0.3);
                ToBeResized.Controls[0].Width = Convert.ToInt32(width * 0.5);
            }
        }
        public void DrawBottomLine(int StartingX,int StartingY,int EndingX)
        {
            for(int i = StartingX; i < EndingX; i++)
            {
                ModifyPicture(CreatePath("Across.png"), i, StartingY, null);
            }
        }
        public void DrawSection(GeneralComponent component, int StartingX, int StartingY)
        {
            MainCircuit.Main.CalculateResistance();
            if (component.GetType() == 'b')
            {

                
                    ModifyPicture(CreatePath("Resistor.png"), StartingX, StartingY, (component.GetResistance().ToString()) + "Ω"); // This code may have to be changed if I need to make the resistor into a 2x1 image rather than a 1x1
                    PictureBoxWithReference PictureBoxImage = (PictureBoxWithReference)ComponentList.Controls[StartingX * numRows + StartingY];
                    PictureBoxImage.AssosiatedComponent = component;
                
            }
            else if (component.GetType() == 'p')
            {
                List<GeneralComponent> ListForDrawing = component.GetCopyOfSubList();// Gets a copy of the current circuit from the PhysicsEngine Module

                // Starts From Current position and starts to draw a parrallel component
                ModifyPicture(CreatePath("TopRightLeft.png"), StartingX, StartingY, null);
                ModifyPicture(CreatePath("TopRightLeft.png"), StartingX + component.size[1] -1 , StartingY, null);
                // Recursivley calls the next draw function to draw the bottom line
                DrawBottomLine(StartingX + 1, StartingY, StartingX + component.size[1] - 1);
                DrawSection(ListForDrawing[0], StartingX + 1, StartingY);

                //Starts going through the vertical list of components to be drawn in parrallel
                for (int i = 1; i < ListForDrawing.Count; i++)
                {
                    //If the y Size of The Component that Has to be drawn previously is larger than 1, extra extentions are drawn 
                    for (int x = 1; x < ListForDrawing[i - 1].size[0]; x++)
                    {

                        StartingY--;//Moves the Y value up
                        ModifyPicture(CreatePath("Down.png"), StartingX, StartingY, null);//Draws a vertical Straight Line
                        ModifyPicture(CreatePath("Down.png"), StartingX + (component.size[1] - 1), StartingY, null);//Draws the corresponding line on the other side
                    }
                    StartingY--;//Itterates the Y one more
                    if (i == ListForDrawing.Count - 1)// If this is the last component in the List, Draw a different joining wire
                    {
                        ModifyPicture(CreatePath("RightBottom.png"), StartingX, StartingY, null);
                        ModifyPicture(CreatePath("LeftBottom.png"), StartingX + (component.size[1] - 1), StartingY, null);
                    }
                    else
                    {
                        ModifyPicture(CreatePath("TopRightBottom.png"), StartingX, StartingY, null);//If not then Just branch for the next component
                        ModifyPicture(CreatePath("TopLeftBottom.png"), StartingX + (component.size[1] - 1), StartingY, null);
                    }
                    DrawBottomLine(StartingX + 1, StartingY, StartingX + component.size[1] - 1);
                    DrawSection(ListForDrawing[i], StartingX + 1, StartingY);

                }
                

            }
            else if (component.GetType() == 's')
            {
                List<GeneralComponent> ListForDrawing = component.GetCopyOfSubList();// Gets a copy of the current circuit from the PhysicsEngine Module
                foreach (GeneralComponent subComponent in ListForDrawing)// Goes through each series component
                {
                    if (subComponent.GetName() != "IntRes")
                    {
                        DrawSection(subComponent, StartingX, StartingY);//Draws each one 
                        StartingX += subComponent.size[1] ;// Increments The starting X so it is in the correct position for next component.
                    }
                }
            }
        }
        public void ModifyComponentImage(string path, string AssignedValue, ref PictureBoxWithReference ImagePictureBox)// Needs cleaning up as reusing from earlier itterations
        {
            ImagePictureBox.Controls.Clear();
            ImagePictureBox.Image = Image.FromFile(path);
            ImagePictureBox.Resize -= ImageResizer; // This removes any previous event handler bc for some reason having more than one breaks stuff
            if (AssignedValue != null) // If the Image has data that needs displaying e.g. voltage or current or resistance A label is added to the list of controls of the picture
            {
                Label ValueOfComponent = new Label();
                ValueOfComponent.Text = AssignedValue;
                ValueOfComponent.BackColor = Color.Transparent; // Transparent so underneath component can be seen
                ValueOfComponent.Dock = DockStyle.Bottom;
                ImagePictureBox.Controls.Add(ValueOfComponent);
                ImagePictureBox.Resize += ImageResizer; // Image Resizer is the event handler I created to make sure everything stays the right size
            }


        }
        public void ModifyPicture(string path, int x, int y, string value)
        {
            int index = x * numRows + y;
            PictureBoxWithReference PanelToModify = (PictureBoxWithReference)ComponentList.Controls[index];
            ModifyComponentImage(path, value, ref PanelToModify);


        }
        public string CreatePath(string ImagePath)
        {
            return ImageDefaultPath + ImagePath;
        }
        public void AddPicture(string path, int x, int y)// Adds the blank picture
        {

            ComponentList.Controls.Add(new PictureBoxWithReference() { Image = Image.FromFile(path), SizeMode = PictureBoxSizeMode.StretchImage, Margin = new Padding(0), Dock = DockStyle.Fill }, x, y);
            ComponentList.Controls[x * numRows + y].Click += new EventHandler(ComponentClick);
        }
        public string GetUserInput(string Instruction)
        {
            var f2 = new InputForm(this, Instruction);
            f2.ShowDialog(this);
            string ToBeReturned = f2.data;
            f2.Dispose();
            return ToBeReturned;
        }
        public void CreatePanel()
        {
            for (int x = 0; x < numColls; x++)
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
                    ModifyPicture(CreatePath("White.png"), x, y, null); // Resets the TableLayoutPanel with blank images
                }
            }
            for (int y = 0; y < numRows; y++) // Makes the Vertical Wires
            {

                ModifyPicture(CreatePath("Down.png"), 0, y, null);
                ModifyPicture(CreatePath("Down.png"), numColls - 1, y, null);
            }

            for (int x = 0; x < numColls; x++)//Makes the Horizontal Wires
            {
                ModifyPicture(CreatePath("Across.png"), x, 0, null);
                ModifyPicture(CreatePath("Across.png"), x, numRows - 1, null);
            }
            //Makes the Corners
            ModifyPicture(CreatePath("RightBottom.png"), 0, 0, null);
            ModifyPicture(CreatePath("TopRight.png"), 0, numRows - 1, null);
            ModifyPicture(CreatePath("TopLeft.png"), numColls - 1, numRows - 1, null);
            ModifyPicture(CreatePath("LeftBottom.png"), numColls - 1, 0, null);

        }


        #endregion
    }
    public class PictureBoxWithReference : PictureBox
    {
        public GeneralComponent AssosiatedComponent;
    }
}

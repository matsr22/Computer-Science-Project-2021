using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Physics_Engine;
using GUI_for_Project.Properties;

namespace GUI_for_Project
{
    public partial class BaseCircuitGUI : Form
    {
        
        protected int numRows;
        protected int numColls;
        protected Circuit MainCircuit;
        protected int MiddleCollumn;

        public BaseCircuitGUI()
        {
            InitializeComponent();
            numRows = ComponentList.RowCount;
            numColls = ComponentList.ColumnCount;
            MiddleCollumn = numColls / 2;
            CreatePanel();
            ResetPanel();
        }
        #region BasicFunction 
        public void DrawCircuit()
        {
            double EMFValue = MainCircuit.GetEmfValue();
            MainCircuit.Main.CalculateResistance(); // Recalcuates so all drawn values are correct
            UpdateDimensions();//Resizes the table based on the current size of the circuit
            ResetPanel();
            DrawSection(MainCircuit.Main, 1, numRows - 1);//Draws the circuit recursively
            if (MainCircuit.Main.FindComponentFromName("IntRes") == null)
            {
                DrawEMFSource(EMFValue);
            }
            else
            {
                DrawEMFSource(EMFValue);
                GeneralComponent InternalResistance = MainCircuit.Main.FindComponentFromName("IntRes");//Finds the internal resistance from the circuit
                ModifyPicture(Resources.ResistorIntRes, MiddleCollumn + 1, 0, PrefixDouble(InternalResistance.GetResistance(), 'Ω')).AssosiatedComponent = InternalResistance;//Updates the diagram to include internal resistance

            }
        }
        public virtual void DrawEMFSource(double EMFVal)
        {
            ModifyPicture(Resources.Cell, MiddleCollumn, 0, PrefixDouble(EMFVal, MainCircuit.GetTypeOfPsource()));//Adds a Cell in the centre of the image
        }
        public void ImageResizer(object sender, EventArgs e) // Resizes the text under a component so it is consistant (Dosn't really work as intended)
        {
            PictureBoxWithReference ToBeResized = sender as PictureBoxWithReference;
            if (ToBeResized != null)
            {
                int height = ToBeResized.Height;
                int width = ToBeResized.Width;
                ToBeResized.Controls[0].Height = Convert.ToInt32(height * 0.3);// Scales the label size a bit arbitarily
                ToBeResized.Controls[0].Width = Convert.ToInt32(width * 0.5);
            }
        }
        public virtual void UpdateDimensions()
        {
            ComponentList.RowCount = MainCircuit.Main.ysize + 3;// The Plus bits on here control the vertical and horizontal padding
            ComponentList.ColumnCount = MainCircuit.Main.xsize + 4;
            numRows = ComponentList.RowCount;
            numColls = ComponentList.ColumnCount;
            MiddleCollumn = numColls / 2;
            ClearPanel();// All controls have to be removed for resizing to work, this introduces some visual artefacting but I'm not sure how to stop this
            CreatePanel();
        }
        public void ClearPanel()
        {
            ComponentList.Controls.Clear();
        }
        public void RefreshDiagram()//Used Whenever a change has occured in the circuit, obviously not in the parent form 
        {
            RunVoltageCalculations();
            DrawCircuit();
        }
        public virtual void RunVoltageCalculations()//Reruns Voltage Calcs and in Forms with Current/ Voltage probes updates their values
        {
            MainCircuit.RunVoltageCalcs();

        }
        public void DrawBottomLine(int StartingX, int StartingY, int EndingX)// Draws a line when one branch of a parrallel component has more components than the other
        {
            for (int i = StartingX; i < EndingX; i++)
            {
                ModifyPicture(Resources.Across, i, StartingY);
            }
        }
        public void DrawSection(GeneralComponent component, int StartingX, int StartingY)
        {
            if (component.GetType() == 'b')
            {
                PictureBoxWithReference PictureBoxImage = ModifyPicture(Resources.Resistor, StartingX, StartingY, PrefixDouble(component.GetResistance(), 'Ω')); // This is the bit that draws the resistors based on positions worked out by the parrallel and series bits
                PictureBoxImage.AssosiatedComponent = component;
            }
            else if (component.GetType() == 'p')
            {
                List<GeneralComponent> ListForDrawing = component.GetCopyOfSubList();// Gets a copy of the current circuit from the PhysicsEngine Module

                // Starts From Current position and starts to draw a parrallel component
                // Draws the bottom line first as if it dosn't, It ovverides TOPRIGHTLEFT
                DrawBottomLine(StartingX + 1, StartingY, StartingX + component.xsize - 1);// If this wasn't there there would be gaps 
                ModifyPicture(Resources.TopRightLeft, StartingX, StartingY).AssosiatedComponent = component;
                ModifyPicture(Resources.TopRightLeft, StartingX + component.xsize - 1, StartingY).AssosiatedComponent = component;


                DrawSection(ListForDrawing[0], StartingX + 1, StartingY);

                //Starts going through the vertical list of components to be drawn in parrallel
                for (int i = 1; i < ListForDrawing.Count; i++)
                {
                    //If the y Size of The Component that Has to be drawn previously is larger than 1, extra extentions are drawn 
                    for (int x = 1; x < ListForDrawing[i - 1].ysize; x++)
                    {

                        StartingY--;//Moves the Y value up
                        ModifyPicture(Resources.Down, StartingX, StartingY).AssosiatedComponent = component;//Draws a vertical Straight Line
                        ModifyPicture(Resources.Down, StartingX + (component.xsize - 1), StartingY).AssosiatedComponent = component;//Draws the corresponding line on the other side
                    }
                    StartingY--;//Itterates the Y one more
                    if (i == ListForDrawing.Count - 1)// If this is the last component in the List, Draw a different joining wire
                    {
                        ModifyPicture(Resources.RightBottom, StartingX, StartingY).AssosiatedComponent = component;
                        ModifyPicture(Resources.LeftBottom, StartingX + (component.xsize - 1), StartingY).AssosiatedComponent = component;
                    }
                    else
                    {
                        ModifyPicture(Resources.TopRightBottom, StartingX, StartingY).AssosiatedComponent = component;//If not then Just branch for the next component
                        ModifyPicture(Resources.TopLeftBottom, StartingX + (component.xsize - 1), StartingY).AssosiatedComponent = component;
                    }
                    DrawBottomLine(StartingX + 1, StartingY, StartingX + component.xsize - 1);
                    DrawSection(ListForDrawing[i], StartingX + 1, StartingY);// Goes up the parrallel component and draws the next section

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
                        StartingX += subComponent.xsize;// Increments The starting X so it is in the correct position for next component.
                    }
                }
            }
        }
        public virtual void ModifyComponentImage(Image image, string AssignedValue, ref PictureBoxWithReference ImagePictureBox)// Needs cleaning up as reusing from earlier itterations
        {
            ImagePictureBox.Controls.Clear();
            ImagePictureBox.Image = image;
            ImagePictureBox.Resize -= ImageResizer; // This removes any previous event handler bc for some reason having more than one breaks stuff
            if (AssignedValue != null) // If the Image has data that needs displaying e.g. voltage or current or resistance A label is added to the list of controls of the picture
            {
                Label ValueOfComponent = new Label();
                ValueOfComponent.Text = AssignedValue;
                ValueOfComponent.BackColor = Color.Transparent; // Transparent so underneath component can be seen
                ValueOfComponent.Dock = DockStyle.Fill;
                ValueOfComponent.TextAlign = ContentAlignment.MiddleCenter;

                ImagePictureBox.Controls.Add(ValueOfComponent);

                ImagePictureBox.Resize += ImageResizer; // Image Resizer is the event handler I created to make sure everything stays the right size
            }


        }
        public PictureBoxWithReference ModifyPicture(Image image, int x, int y, string value = null)// Adds Labels to images, Changes event handlers and changes the image themselves
        {
            int index = x * numRows + y;
            PictureBoxWithReference PanelToModify = (PictureBoxWithReference)ComponentList.Controls[index];
            ModifyComponentImage(image, value, ref PanelToModify);
            return PanelToModify;


        }
        public virtual void AddPicture(Image image, int x, int y)// Adds the blank picture
        {

            ComponentList.Controls.Add(new PictureBoxWithReference() { Image = image, SizeMode = PictureBoxSizeMode.StretchImage, Margin = new Padding(0), Dock = DockStyle.Fill }, x, y);

        }
        public string[] GetUserInput(string Instruction, char UnitPrefix)// This gets User Input, along with the suffix they have chosen 
        {
            string ToBeReturned ="";
            string SelectedPrefix="";
            bool ValidAnswer = false;
            while (ValidAnswer != true)
            {
                // I don't really understand the Methods assossiated with a Form so I just used .Close and .Dispose as it worked
                var f2 = new InputForm(Instruction, UnitPrefix);
                f2.ShowDialog(this);
                ToBeReturned = f2.data;
                SelectedPrefix = f2.ChosenPrefix;
                f2.Close(); 
                f2.Dispose();
                if(ToBeReturned != null)
                {
                    ValidAnswer = true;
                }
                else
                {
                    MessageBox.Show("Enter a Valid value!");
                }
            }
            return new string[] { ToBeReturned, SelectedPrefix };
        }
        public double GetUserInputAsDouble(string Instruction, char UnitPrefix)//Parses the String input from GetUserInput to a double 
        {
            while (true)
            {
                string[] InputAsString = GetUserInput(Instruction, UnitPrefix);
                string Value = TryToConvertToStandardForm(InputAsString[0]);
                if (Value != null)
                {
                    string ParsedValue = RemovePrefixAndCheckDouble(Value, InputAsString[1]);
                    if (ParsedValue != null)
                    {
                        return Convert.ToDouble(ParsedValue);
                    }
                }
                MessageBox.Show("Input was not in correct Format, Enter again");
            }
        }
        public string PrefixDouble(double input, char UnitPrefix)// Adds all the unit prefixes to the right magnitude of double, bit boring probably could have done this with some kind of clever dictionary
        {
            if (1 <= input && input < 1000)
            {
                return Math.Round(input,5).ToString() + UnitPrefix;
            }
            else if (0.001 <= input && input < 1)
            {
                return Math.Round((input * 1000),5).ToString() + "m" + UnitPrefix;
            }
            else if (1.0E-6 <= input && input < 0.001)
            {
                return Math.Round((input * 1E6), 5).ToString() + "µ" + UnitPrefix;
            }
            else if (1.0E-9 <= input && input < 1.0E-6)
            {
                return Math.Round((input * 1E9), 5).ToString() + "n" + UnitPrefix;
            }
            else if (1000 <= input && input < 1E6)
            {
                return Math.Round((input / 1000), 5).ToString() + "k" + UnitPrefix;
            }
            else if (1E6 <= input && input < 1E9)
            {
                return Math.Round((input / 1E6), 5).ToString() + "M" + UnitPrefix;
            }
            else if (1E9 <= input && input < 1E12)
            {
                return Math.Round((input / 1E9), 5).ToString() + "G" + UnitPrefix;
            }
            else
            {
                return Math.Round((input), 5).ToString("G3") + UnitPrefix;// The G3 Just tells .ToString how this should be Displayed - In this case it is in standard form to 3 sf on mantissa and 2 s.f on exponent
            }
        }
        public string RemovePrefixAndCheckDouble(string input, string prefix)//Scales up the Suffixed value to a double
        {
            try
            {
                double inputAsdouble = Convert.ToDouble(input);
                switch (prefix[0])
                {
                    case 'n':
                        inputAsdouble *= Math.Pow(10, -9);
                        break;
                    case 'μ':
                        inputAsdouble *= Math.Pow(10, -6);
                        break;
                    case 'm':
                        inputAsdouble *= Math.Pow(10, -3);
                        break;
                    case 'k':
                        inputAsdouble *= Math.Pow(10, 3);
                        break;
                    case 'M':
                        inputAsdouble *= Math.Pow(10, 6);
                        break;
                    case 'G':
                        inputAsdouble *= Math.Pow(10, 9);
                        break;
                    default:
                        break;

                }
                return Convert.ToString(inputAsdouble);
            }
            catch (FormatException)
            {
                return null;
            }
        }
        public string TryToConvertToStandardForm(string Input)//This might be entirely unecessary because c# might deal with some of this stuff allready but as it isn't called that often I'm fine with it
        {
            Input = Input.ToLower();
            if (Input.Contains("e"))
            {
                try
                {
                    double Mantissa = Convert.ToDouble(Input.Split('e')[0]);
                    int exp = Convert.ToInt32(Input.Split('e')[1]);
                    double FinalNumber = Mantissa * Math.Pow(10, exp);
                    return FinalNumber.ToString();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {

                return Input;
            }

        }
        public void CreatePanel()
        {
            for (int x = 0; x < numColls; x++)
            {
                for (int y = 0; y < numRows; y++)
                {
                    AddPicture(Resources.White, x, y); // Fills the TableLayoutPanel with blank images
                }
            }
        }
        public void ResetPanel()
        {
            for (int x = 0; x < numColls; x++)
            {
                for (int y = 0; y < numRows; y++)
                {
                    ModifyPicture(Resources.White, x, y); // Resets the TableLayoutPanel with blank images
                }
            }
            for (int y = 0; y < numRows; y++) // Makes the Vertical Wires
            {

                ModifyPicture(Resources.Down, 0, y);
                ModifyPicture(Resources.Down, numColls - 1, y);
            }

            for (int x = 0; x < numColls; x++)//Makes the Horizontal Wires
            {
                ModifyPicture(Resources.Across, x, 0);
                ModifyPicture(Resources.Across, x, numRows - 1);
            }
            //Makes the Corners
            ModifyPicture(Resources.RightBottom, 0, 0);
            ModifyPicture(Resources.TopRight, 0, numRows - 1);
            ModifyPicture(Resources.TopLeft, numColls - 1, numRows - 1);
            ModifyPicture(Resources.LeftBottom, numColls - 1, 0);

        }


        #endregion
    }
    public class PictureBoxWithReference : PictureBox
    {
        public GeneralComponent AssosiatedComponent;
    }
}

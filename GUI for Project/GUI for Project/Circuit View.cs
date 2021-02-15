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
    public partial class CircuitView  : Form
    {
        // Local Variables
        #region Locals
        private string ImageDefaultPath = @"C:\Users\matth\source\repos\matsr22\Computer-Science-Project-2021\GUI for Project\GUI for Project\Images\";// This is where most images will be kept
        private int numRows;
        private int numColls;
        private Circuit MainCircuit;
        private int MiddleCollumn;
        private GeneralComponent CurrentProbeTarget;
        #endregion
        public CircuitView()
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
            double Voltage = GetUserInputAsDouble("Please Enter the Voltage of the Circuit",'V');
            double IntRes = GetUserInputAsDouble("Please Enter the internal resistance of the Circuit", 'Ω');
            double InitialResistor = GetUserInputAsDouble("Please Enter the Resistance of the first resistor", 'Ω');
            MainCircuit = new Circuit('v', Voltage, IntRes, InitialResistor);
            DrawCircuit();
        }



        public void ComponentClick(object sender, EventArgs e)
        {
            PictureBoxWithReference SenderPicture = (PictureBoxWithReference)sender;
            if (SenderPicture.AssosiatedComponent != null)
            {
                switch (ClickActions.SelectedItem.ToString())
                {

                    case ("Edit Values"):
                        double value = GetUserInputAsDouble($"What would you like to change the value of {SenderPicture.AssosiatedComponent.GetName()} to ?", 'Ω');
                        SenderPicture.AssosiatedComponent.AssignResistance(value);
                        Label InternalLabel = ((Label)SenderPicture.Controls[0]);
                        InternalLabel.Text = PrefixDouble(value, 'Ω');
                        RefreshDiagram();
                        break;


                    case "Add Resistor In Parrallel":
                        double NewResistanceValue = GetUserInputAsDouble("What is the resistance of the new resistor", 'Ω');
                        MainCircuit.Main.ComponentSearch(SenderPicture.AssosiatedComponent.GetName(), "Insert", new string[] { NewResistanceValue.ToString(), "p" });
                        RefreshDiagram();
                        break;
                    case "Add Resistor In Series":
                        double NewResistanceValue2 = GetUserInputAsDouble("What is the resistance of the new resistor", 'Ω');
                        MainCircuit.Main.ComponentSearch(SenderPicture.AssosiatedComponent.GetName(), "Insert", new string[] { NewResistanceValue2.ToString(), "s" });
                        RefreshDiagram();
                        break;
                    case "Remove Resistor":
                        MainCircuit.Main.ComponentSearch(SenderPicture.AssosiatedComponent.GetName(),"Remove");
                        RefreshDiagram();
                        break;
                    case "Current Probe":
                        CurrentProbeTarget = SenderPicture.AssosiatedComponent;
                        UpdateCurrentProbeText();
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }


        public void UpdateCurrentProbeText()
        {
            if (CurrentProbeTarget != null)
            {
                CurrentVal.Text = PrefixDouble(CurrentProbeTarget.GetCurrent(), 'Ω');
            }
        }
        #endregion

        //This is stuff required for the circuit simulation to work and is not necessarily part of the custom builder
        #region BasicFunction 
        public void ClearPanel()
        {
            ComponentList.Controls.Clear();
        }
        public void DrawCircuit()
        {
            double Voltage = MainCircuit.GetEmfValue();
            MainCircuit.Main.CalculateResistance();
            UpdateDimensions();
            ResetPanel();
            DrawSection(MainCircuit.Main, 1, numRows - 1);
            if (MainCircuit.Main.FindComponentFromName("IntRes").GetResistance() == 0)
            {
                ModifyPicture("Cell.png", MiddleCollumn, 0, PrefixDouble(Voltage, 'V'));
            }
            else
            {
                ModifyPicture("Cell.png", MiddleCollumn, 0, PrefixDouble(Voltage, 'V'));
                GeneralComponent InternalResistance = MainCircuit.Main.FindComponentFromName("IntRes");
                ModifyPicture("ResistorIntRes.png", MiddleCollumn + 1, 0, PrefixDouble(InternalResistance.GetResistance(), 'Ω'));

            }
        }
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
        public void UpdateDimensions()
        {
            ComponentList.RowCount = MainCircuit.Main.ysize + 3;
            ComponentList.ColumnCount = MainCircuit.Main.xsize + 4;
            numRows = ComponentList.RowCount;
            numColls = ComponentList.ColumnCount;
            MiddleCollumn = numColls / 2;
            ClearPanel();
            CreatePanel();
        }
        public void RefreshDiagram()
        {
            RunVoltageCalculations();
            DrawCircuit();
        }
        public void RunVoltageCalculations()
        {
            MainCircuit.RunVoltageCalcs();
            UpdateCurrentProbeText();
        }
        public void DrawBottomLine(int StartingX,int StartingY,int EndingX)
        {
            for(int i = StartingX; i < EndingX; i++)
            {
                ModifyPicture("Across.png", i, StartingY);
            }
        }
        public void DrawSection(GeneralComponent component, int StartingX, int StartingY)
        {
            if (component.GetType() == 'b')
            {

                
                    PictureBoxWithReference PictureBoxImage = ModifyPicture("Resistor.png", StartingX, StartingY, PrefixDouble(component.GetResistance(), 'Ω')); // This code may have to be changed if I need to make the resistor into a 2x1 image rather than a 1x1
                    PictureBoxImage.AssosiatedComponent = component;
                    
                
            }
            else if (component.GetType() == 'p')
            {
                List<GeneralComponent> ListForDrawing = component.GetCopyOfSubList();// Gets a copy of the current circuit from the PhysicsEngine Module

                // Starts From Current position and starts to draw a parrallel component
                ModifyPicture("TopRightLeft.png", StartingX, StartingY).AssosiatedComponent = component;
                ModifyPicture("TopRightLeft.png", StartingX + component.xsize -1 , StartingY).AssosiatedComponent = component;
                // Recursivley calls the next draw function to draw the bottom line
                DrawBottomLine(StartingX + 1, StartingY, StartingX + component.ysize - 1);
                DrawSection(ListForDrawing[0], StartingX + 1, StartingY);

                //Starts going through the vertical list of components to be drawn in parrallel
                for (int i = 1; i < ListForDrawing.Count; i++)
                {
                    //If the y Size of The Component that Has to be drawn previously is larger than 1, extra extentions are drawn 
                    for (int x = 1; x < ListForDrawing[i - 1].ysize; x++)
                    {

                        StartingY--;//Moves the Y value up
                        ModifyPicture("Down.png", StartingX, StartingY).AssosiatedComponent = component;//Draws a vertical Straight Line
                        ModifyPicture("Down.png", StartingX + (component.xsize - 1), StartingY).AssosiatedComponent = component;//Draws the corresponding line on the other side
                    }
                    StartingY--;//Itterates the Y one more
                    if (i == ListForDrawing.Count - 1)// If this is the last component in the List, Draw a different joining wire
                    {
                        ModifyPicture("RightBottom.png", StartingX, StartingY).AssosiatedComponent = component;
                        ModifyPicture("LeftBottom.png", StartingX + (component.xsize - 1), StartingY).AssosiatedComponent = component;
                    }
                    else
                    {
                        ModifyPicture("TopRightBottom.png", StartingX, StartingY).AssosiatedComponent = component;//If not then Just branch for the next component
                        ModifyPicture("TopLeftBottom.png", StartingX + (component.xsize - 1), StartingY).AssosiatedComponent = component;
                    }
                    DrawBottomLine(StartingX + 1, StartingY, StartingX + component.xsize - 1);
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
                        StartingX += subComponent.xsize ;// Increments The starting X so it is in the correct position for next component.
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
                ValueOfComponent.Anchor = AnchorStyles.Bottom;
                ValueOfComponent.AutoSize = true;
                ImagePictureBox.Controls.Add(ValueOfComponent);
                
                ImagePictureBox.Resize += ImageResizer; // Image Resizer is the event handler I created to make sure everything stays the right size
            }


        }
        public PictureBoxWithReference ModifyPicture(string path, int x, int y, string value = null)
        {
            int index = x * numRows + y;
            PictureBoxWithReference PanelToModify = (PictureBoxWithReference)ComponentList.Controls[index];
            ModifyComponentImage(CreatePath(path), value, ref PanelToModify);
            return PanelToModify;


        }
        public string CreatePath(string ImagePath)
        {
            return ImageDefaultPath + ImagePath;
        }
        public void AddPicture(string path, int x, int y)// Adds the blank picture
        {

            ComponentList.Controls.Add(new PictureBoxWithReference() { Image = Image.FromFile(CreatePath(path)), SizeMode = PictureBoxSizeMode.StretchImage, Margin = new Padding(0), Dock = DockStyle.Fill }, x, y);
            ComponentList.Controls[x * numRows + y].Click += new EventHandler(ComponentClick);
        }
        public string[] GetUserInput(string Instruction,char UnitPrefix)
        {
            var f2 = new InputForm(Instruction,UnitPrefix);
            f2.ShowDialog(this);
            string ToBeReturned = f2.data;
            string SelectedPrefix = f2.ChosenPrefix;
            f2.Dispose();
            return new string[] { ToBeReturned, SelectedPrefix } ;
        }
        public double GetUserInputAsDouble(string Instruction,char UnitPrefix)
        {
            while (true)
            {
                string[] InputAsString = GetUserInput(Instruction,UnitPrefix);
                string Value = TryToConvertToStandardForm(InputAsString[0]);
                if (Value != null)
                {
                    string ParsedValue = RemovePrefixAndCheckDouble(Value,InputAsString[1]);
                    if (ParsedValue != null)
                    {
                        return Convert.ToDouble(ParsedValue);
                    }
                }
                MessageBox.Show("Input was not in correct Format, Enter again");
            }
        }
        public string PrefixDouble(double input,char UnitPrefix)
        {
            if (1 <= input&& input < 1000)
            {
                return input.ToString() + UnitPrefix;
            }
            else if(0.001<= input && input < 1)
            {
                return (input*1000).ToString() + "m" + UnitPrefix;
            }
            else if(1.0E-6<=input&& input < 0.001)
            {
                return (input*1E6).ToString() + "µ" + UnitPrefix;
            }
            else if(1.0E-9<=input && input < 1.0E-6)
            {
                return (input*1E9).ToString() + "n" + UnitPrefix;
            }
            else if (1000 <= input && input < 1E6)
            {
                return (input / 1000).ToString() + "k"+UnitPrefix;
            }
            else if (1E6<= input && input < 1E9)
            {
                return (input / 1E6).ToString() + "M" + UnitPrefix;
            }
            else if(1E9<=input&& input < 1E12)
            {
                return (input / 1E9).ToString() + "G" + UnitPrefix;
            }
            else
            {
                return (input).ToString("G3") + UnitPrefix;// The G3 Just tells .ToString how this should be Displayed - In this case it is in standard form to 3 sf on mantissa and 2 s.f on exponent
            }
        }
        public string RemovePrefixAndCheckDouble(string input,string prefix)
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
        public string TryToConvertToStandardForm(string Input)
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
                    AddPicture("White.png", x, y); // Fills the TableLayoutPanel with blank images
                }
            }
        }
        public void ResetPanel()
        {
            for (int x = 0; x < numColls; x++)
            {
                for (int y = 0; y < numRows; y++)
                {
                    ModifyPicture("White.png", x, y); // Resets the TableLayoutPanel with blank images
                }
            }
            for (int y = 0; y < numRows; y++) // Makes the Vertical Wires
            {

                ModifyPicture("Down.png", 0, y);
                ModifyPicture("Down.png", numColls - 1, y);
            }

            for (int x = 0; x < numColls; x++)//Makes the Horizontal Wires
            {
                ModifyPicture("Across.png", x, 0);
                ModifyPicture("Across.png", x, numRows - 1);
            }
            //Makes the Corners
            ModifyPicture("RightBottom.png", 0, 0);
            ModifyPicture("TopRight.png", 0, numRows - 1);
            ModifyPicture("TopLeft.png", numColls - 1, numRows - 1);
            ModifyPicture("LeftBottom.png", numColls - 1, 0);

        }


        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}

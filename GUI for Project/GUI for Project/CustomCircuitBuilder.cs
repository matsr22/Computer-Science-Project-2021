using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Physics_Engine;

namespace GUI_for_Project
{
    public partial class CustomCircuitBuilder : BaseCircuitGUI
    {
        protected GeneralComponent CurrentProbeTarget;
        protected GeneralComponent VoltageTarget;
        public CustomCircuitBuilder()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            numRows = ComponentList.RowCount;
            numColls = ComponentList.ColumnCount;
            MiddleCollumn = numColls / 2;
            CreatePanel();
            ResetPanel();
            CreateBasicCircuit();
        }
        #region UIFunction
        public void CreateBasicCircuit()// Creates a circuit based on user inputs
        {
            // User Input
            double Voltage = GetUserInputAsDouble("Please Enter the Voltage of the Circuit", 'V');
            double IntRes = GetUserInputAsDouble("Please Enter the internal resistance of the Circuit", 'Ω');
            double InitialResistor = GetUserInputAsDouble("Please Enter the Resistance of the first resistor", 'Ω');
            MainCircuit = new Circuit('v', Voltage, IntRes, InitialResistor);
            DrawCircuit();
        }



        public void ComponentClick(object sender, EventArgs e)// Forwards on the correct action when user clicks a component
        {
            PictureBoxWithReference SenderPicture;
            // This first bit just gets the correct PictureBoxWithReference as the user can click on the label covering the picture or the picture itself
            if (sender.GetType() == new Label().GetType())
            {
                SenderPicture = (PictureBoxWithReference)(((Label)sender).Parent);
            }
            else
            {
                SenderPicture = (PictureBoxWithReference)sender;
            }

            if (SenderPicture.AssosiatedComponent != null && ClickActions.SelectedItem != null)// Checks the image has a resistor attached
            {
                switch (ClickActions.SelectedItem.ToString())//Switches on the ClickActions Drop Down menu
                {

                    case ("Edit Values"):
                        double value = GetUserInputAsDouble($"What would you like to change the value of {SenderPicture.AssosiatedComponent.GetName()} to ?", 'Ω');
                        SenderPicture.AssosiatedComponent.AssignResistance(value);
                        Label InternalLabel = ((Label)SenderPicture.Controls[0]);// Now Updates the Label to reflect the new value
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
                        if(!(MainCircuit.Main.GetCopyOfSubList().Count == 1 || (MainCircuit.Main.GetCopyOfSubList().Count == 2 && MainCircuit.Main.FindComponentFromName("IntRes")!= null&&SenderPicture.AssosiatedComponent.GetName() != "IntRes")))// This long if statement checks if the component to be removed is the last in the circuit, if it is, it isn't removed
                        {
                            MainCircuit.Main.ComponentSearch(SenderPicture.AssosiatedComponent.GetName(), "Remove");
                            RefreshDiagram();
                        }
                        break;
                    case "Current Probe":
                        CurrentProbeTarget = SenderPicture.AssosiatedComponent;// Changes the targeted component for Probing
                        UpdateCurrentProbeText();
                        break;
                    case "Voltage Probe":
                        VoltageTarget = SenderPicture.AssosiatedComponent;
                        UpdateVoltageTargetText();
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        public void EditVoltageValue(object sender, EventArgs e)// Called only when the EMF source is changed 
        {
            double value = GetUserInputAsDouble("What would you like to change the value of the EMF source to?", 'V');
            MainCircuit.AssignEMF(value);
            //Updates all things that might be changed by changing the VoltageSource
            UpdateCurrentProbeText();
            UpdateVoltageTargetText();
            RefreshDiagram();
        }


        public void UpdateCurrentProbeText()
        {
            if (CurrentProbeTarget != null)//Checks current probe actual has a target
            {
                CurrentVal.Text = PrefixDouble(CurrentProbeTarget.GetCurrent(), 'A');
            }
        }
        public void UpdateVoltageTargetText()
        {
            if(VoltageTarget!= null)
            {
                VoltageDisplay.Text = PrefixDouble(VoltageTarget.GetVoltage(), 'V');
            }
        }
        #endregion
        #region Ovveriden Methods
        // These are all methods that need to change somehow due to extras implemented
        public override void RunVoltageCalculations()
        {
            base.RunVoltageCalculations();
            UpdateCurrentProbeText();
            UpdateVoltageTargetText();
        }
        public override void AddPicture(Image image, int x, int y)
        {
            base.AddPicture(image, x, y);
            ComponentList.Controls[x * numRows + y].Click += new EventHandler(ComponentClick);// Adds the functionality on click 
        }
        public override void ModifyComponentImage(Image image, string AssignedValue, ref PictureBoxWithReference ImagePictureBox)
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
                ValueOfComponent.Click += new EventHandler(ComponentClick);
                ImagePictureBox.Controls.Add(ValueOfComponent);

                ImagePictureBox.Resize += ImageResizer; // Image Resizer is the event handler I created to make sure everything stays the right size
            }
        }
        public override void DrawEMFSource(double EMFVal)
        {
            base.DrawEMFSource(EMFVal);
            //Adds Event Handlers to the EMF Source image so its value can be changed at runtime
            ComponentList.Controls[MiddleCollumn * numRows].Click += new EventHandler(EditVoltageValue);
            ComponentList.Controls[MiddleCollumn * numRows].Controls[0].Click += new EventHandler(EditVoltageValue);
        }

        #endregion

        private void Reset_Click(object sender, EventArgs e)
        {
            ResetPanel();//Clears the Panel
            CreateBasicCircuit();//Creates a new one in its place
        }


        private void RecalculateValues_Click(object sender, EventArgs e)//Shouldn't be necessary as the program should calculate Resistance on its own but is there just in case
        {
            MainCircuit.Main.CalculateResistance();
            RefreshDiagram();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Hide();
            StudentPage studentPage = new StudentPage();
            studentPage.ShowDialog();
            Close();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            Hide();
            Help_Form HelpPage = new Help_Form("Custom Circuit Builder Help:", "This Program allows you to dynamicly add resistors and measure the affect on the circuit\nSelect the Action You would like to be performed\nThen select the Component you would like it to be performed on\nClicking on the Arms of a Parrallel Component selects the entire parrallel section\nSelecting the EMF Source will allow you to change its value");
            HelpPage.ShowDialog();
            Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

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
        public void CreateBasicCircuit()
        {
            // User Input
            double Voltage = GetUserInputAsDouble("Please Enter the Voltage of the Circuit", 'V');
            double IntRes = GetUserInputAsDouble("Please Enter the internal resistance of the Circuit", 'Ω');
            double InitialResistor = GetUserInputAsDouble("Please Enter the Resistance of the first resistor", 'Ω');
            MainCircuit = new Circuit('v', Voltage, IntRes, InitialResistor);
            DrawCircuit();
        }



        public void ComponentClick(object sender, EventArgs e)
        {
            PictureBoxWithReference SenderPicture;
            if (sender.GetType() == new Label().GetType())
            {
                SenderPicture = (PictureBoxWithReference)(((Label)sender).Parent);
            }
            else
            {
                SenderPicture = (PictureBoxWithReference)sender;
            }

            if (SenderPicture.AssosiatedComponent != null && ClickActions.SelectedItem != null)
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
                        if(!(MainCircuit.Main.GetCopyOfSubList().Count == 1 || (MainCircuit.Main.GetCopyOfSubList().Count == 2 && MainCircuit.Main.FindComponentFromName("IntRes")!= null&&SenderPicture.AssosiatedComponent.GetName() != "IntRes")))
                        {
                            MainCircuit.Main.ComponentSearch(SenderPicture.AssosiatedComponent.GetName(), "Remove");
                            RefreshDiagram();
                        }
                        break;
                    case "Current Probe":
                        CurrentProbeTarget = SenderPicture.AssosiatedComponent;
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
        public void EditVoltageValue(object sender, EventArgs e)
        {
            double value = GetUserInputAsDouble("What would you like to change the value of the EMF source to?", 'V');
            MainCircuit.AssignEMF(value);
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
        public override void RunVoltageCalculations()
        {
            base.RunVoltageCalculations();
            UpdateCurrentProbeText();
            UpdateVoltageTargetText();
        }
        public override void AddPicture(Image image, int x, int y)
        {
            base.AddPicture(image, x, y);
            ComponentList.Controls[x * numRows + y].Click += new EventHandler(ComponentClick);
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
            ComponentList.Controls[MiddleCollumn * numRows].Click += new EventHandler(EditVoltageValue);
            ComponentList.Controls[MiddleCollumn * numRows].Controls[0].Click += new EventHandler(EditVoltageValue);
        }

        #endregion

        private void Reset_Click(object sender, EventArgs e)
        {
            ResetPanel();
            CreateBasicCircuit();
        }


        private void RecalculateValues_Click(object sender, EventArgs e)
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

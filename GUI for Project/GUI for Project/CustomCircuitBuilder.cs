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
        public CustomCircuitBuilder()
        {
            InitializeComponent();
            numRows = ComponentList.RowCount;
            numColls = ComponentList.ColumnCount;
            MiddleCollumn = numColls / 2;
            CreatePanel();
            ResetPanel();
            CreateBasicCircuit();
        }
        #region UIFunction
        public void CreateBasicCircuit()// Remove Testing stuff when done
        {
            double Voltage = GetUserInputAsDouble("Please Enter the Voltage of the Circuit", 'V');
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
                        MainCircuit.Main.ComponentSearch(SenderPicture.AssosiatedComponent.GetName(), "Remove");
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
        #region Ovveriden Methods
        public override void RunVoltageCalculations()
        {
            base.RunVoltageCalculations();
            UpdateCurrentProbeText();
        }
        public override void AddPicture(string path, int x, int y)
        {
            base.AddPicture(path, x, y);
            ComponentList.Controls[x * numRows + y].Click += new EventHandler(ComponentClick);
        }
        #endregion
    }
}

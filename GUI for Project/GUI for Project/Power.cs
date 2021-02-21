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
    public partial class Power : BaseCircuitGUI
    {
        protected double EMFValue;
        protected double Resistance;
        protected double PowerNow;
        protected int GraphMode;
        protected string TypeMOde;
        public Power()
        {
            InitializeComponent();
        }

        private void Power_Load(object sender, EventArgs e)
        {
            numRows = ComponentList.RowCount;
            numColls = ComponentList.ColumnCount;
            MiddleCollumn = numColls / 2;
            EMFValue = 12;
            Resistance = 10;
            GraphMode = 1;
            MainCircuit = new Circuit('v', EMFValue, 0, Resistance);
            TypeMOde = "Voltage";
            GraphTypeControl.SelectedIndex = 0;
            VariableResistance.Value = 10;
            VariableEMF.Value = 12;
            DrawCircuit();
        }
        public void CalculatePower()
        {
            double Voltage = MainCircuit.Main.GetVoltage();
            double Current = MainCircuit.Main.GetCurrent();
            PowerNow = Voltage * Current;
            PowerLabel.Text = PrefixDouble(PowerNow, 'W');
        }

        private void VariableResistance_ValueChanged(object sender, EventArgs e)
        {
            GeneralComponent Load = MainCircuit.Main.GetCopyOfSubList()[0];
            Resistance = (sender as TrackBar).Value;
            Load.AssignResistance(Resistance);
            CalculatePower();
            RefreshDiagram();
        }

        private void VariableEMF_ValueChanged(object sender, EventArgs e)
        {
            EMFValue = (sender as TrackBar).Value;
            MainCircuit.AssignEMF(EMFValue);
            CalculatePower();
            RefreshDiagram();
        }

        private void PowerToggle_Click(object sender, EventArgs e)
        {
            if(MainCircuit.GetTypeOfPsource() == 'a')
            {
                MainCircuit.ChangeType('v');
                TypeMOde = "Voltage";
            }
            else
            {
                MainCircuit.ChangeType('a');
                TypeMOde = "Current";
            }
            RefreshAxisTitle();
            DrawCircuit();
        }

        private void PlotGraphPoint_Click(object sender, EventArgs e)
        {
            double XCoord;
            double YCoord = PowerNow;
            switch (GraphMode)
            {
                case 1:
                    XCoord = EMFValue;
                    break;
                case 2:
                    XCoord = Math.Pow(EMFValue,2);
                    break;
                default:
                    XCoord = -1;
                    break;

            }
            PowerLawDigram.Series[0].Points.AddXY(XCoord, YCoord);
        }

        private void Power_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearGraph();
        }
        public void ClearGraph()
        {
            PowerLawDigram.Series[0].Points.Clear();
        }
        public void RefreshAxisTitle()
        {
            if ((string)(GraphTypeControl.SelectedItem) == "Power - Y, EMFValue - X")
            {
                GraphMode = 1;
                PowerLawDigram.ChartAreas[0].AxisY.Title = "Power(W)";
                PowerLawDigram.ChartAreas[0].AxisX.Title = TypeMOde + "(" + MainCircuit.GetTypeOfPsource().ToString().ToUpper() + ")";

            }
            else
            {
                GraphMode = 2;
                PowerLawDigram.ChartAreas[0].AxisY.Title = "Power(W)";
                PowerLawDigram.ChartAreas[0].AxisX.Title = TypeMOde + "^2" + "(" + MainCircuit.GetTypeOfPsource().ToString().ToUpper() + "^2" + ")";
            }
            ClearGraph();
        }

        private void GraphTypeControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAxisTitle();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

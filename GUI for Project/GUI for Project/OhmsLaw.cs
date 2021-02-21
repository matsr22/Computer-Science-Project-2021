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
    public partial class OhmsLaw : GUI_for_Project.BaseCircuitGUI
    {
        protected double Voltage;
        protected double Resistance;
        protected double Current;
        public OhmsLaw()
        {
            InitializeComponent();
        }

        private void OhmsLaw_Load(object sender, EventArgs e)
        {
            Voltage = 12;// Might change the starting values to be system wide
            Resistance = 5;
            Current = Voltage / Resistance;
            MainCircuit = new Circuit('v', Voltage, 0, Resistance);
            VoltageSlider.Value = Convert.ToInt32(Voltage);
            ResistanceSlider.Value = Convert.ToInt32(Resistance);
            OhmsChart.ChartAreas[0].AxisX.Title = "Voltage(V)";
            OhmsChart.ChartAreas[0].AxisY.Title = "Current(A)";
            DrawCircuit();
        }

        private void VoltageSlider_ValueChanged(object sender, EventArgs e)// When 
        {

            Voltage = (sender as TrackBar).Value;
            VoltageLabel.Text = PrefixDouble(Voltage, 'V');
            MainCircuit.AssignEMF(Voltage);
            UpdateCurrent();
            RefreshDiagram();
        }

        private void ResistanceSlider_ValueChanged(object sender, EventArgs e)
        {
            GeneralComponent Load = MainCircuit.Main.GetCopyOfSubList()[0];
            Resistance = (sender as TrackBar).Value;
            ResistanceLabel.Text = PrefixDouble(Resistance, 'Ω');
            Load.AssignResistance(Resistance);
            UpdateCurrent();
            RefreshDiagram();
        }
        public void UpdateCurrent()
        {
            Current = MainCircuit.Main.GetCurrent();
            CurrentLabel.Text = PrefixDouble(Current, 'A');
        }

        private void GraphPlot_Click(object sender, EventArgs e)
        {
            OhmsChart.Series[0].Points.AddXY(Voltage, Current);
        }

        private void ClearGraph_Click(object sender, EventArgs e)
        {
            OhmsChart.Series[0].Points.Clear();
        }


    }
}

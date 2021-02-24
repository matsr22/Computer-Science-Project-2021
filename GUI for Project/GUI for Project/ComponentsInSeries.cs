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
    public partial class ComponentsInSeries : GUI_for_Project.BaseCircuitGUI
    {
        protected double CurrentResistance;
        protected double SumResistance;
        protected double SumCurrent;
        protected double VoltagePerComponent;
        protected double Voltage;
        public ComponentsInSeries()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            numRows = ComponentList.RowCount;
            numColls = ComponentList.ColumnCount;
            MiddleCollumn = numColls / 2;
            CreatePanel();
            ResetPanel();
            CurrentResistance = SettingsVariables.ResistanceDefaultValue;
            Voltage = SettingsVariables.EMFDefaultValue;
            MainCircuit = new Circuit('v', Voltage, 0, CurrentResistance);
            panel1.BackColor = SettingsVariables.ControlBackgroundColour;
            panel2.BackColor = SettingsVariables.ControlBackgroundColour;
            UpdatePointers();

            DrawCircuit();
        }
        public override void UpdateDimensions()
        {
            ComponentList.RowCount = MainCircuit.Main.ysize + 1;// The Plus bits on here control the vertical and horizontal padding
            ComponentList.ColumnCount = MainCircuit.Main.xsize + 2;
            numRows = ComponentList.RowCount;
            numColls = ComponentList.ColumnCount;
            MiddleCollumn = numColls / 2;
            ClearPanel();// All controls have to be removed for resizing to work, this introduces some visual artefacting but I'm not sure how to stop this
            CreatePanel();
        }

        private void EditResistance_Click(object sender, EventArgs e)
        {

            try
            {
                CurrentResistance = Convert.ToDouble(UserResistanceValue.Text);
                MainCircuit.Main.BatchChangeResistance(CurrentResistance);
                MainCircuit.Main.CalculateResistance();
                RefreshDiagram();
                UpdatePointers();
            }
            catch (FormatException)
            {
                UserResistanceValue.Text = "";
                MessageBox.Show("Please enter a resistance Value without units (Value is in ohms)");

            }

        }

        private void AddC_Click(object sender, EventArgs e)
        {
            GeneralComponent ComponentToBeInsertedAt = MainCircuit.Main.GetCopyOfSubList()[0];
            MainCircuit.Main.ComponentSearch(ComponentToBeInsertedAt.GetName(), "Insert", new string[] { CurrentResistance.ToString(), "s" });
            MainCircuit.Main.CalculateResistance();
            RefreshDiagram();
            UpdatePointers();
        }

        private void RemoveC_Click(object sender, EventArgs e)
        {
            GeneralComponent ParraComponentList = MainCircuit.Main;
            if (ParraComponentList.GetCopyOfSubList().Count != 1)
            {
                ParraComponentList.RemoveComponent(ParraComponentList.GetCopyOfSubList()[0]);
            }
            MainCircuit.Main.CalculateResistance();
            RefreshDiagram();
            UpdatePointers();

        }
        public void UpdatePointers()
        {
            GeneralComponent ParraComponentList = MainCircuit.Main;        
            SumResistance = ParraComponentList.GetResistance();
            VoltagePerComponent = ParraComponentList.GetCopyOfSubList()[0].GetVoltage();
            SumCurrent = ParraComponentList.GetCurrent();
            UpdateLabels();
        }
        public void UpdateLabels()
        {
            TotalCurrentLabel.Text = PrefixDouble(SumCurrent, 'A');
            ResistanceTotalLabel.Text = PrefixDouble(SumResistance, 'Ω');
            SubVoltageValue.Text = PrefixDouble(VoltagePerComponent, 'V');
        }

    }
}

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
    public partial class ComponentsInParrallel : BaseCircuitGUI
    {
        protected double CurrentResistance;
        protected double SumResistance;
        protected double SumCurrent;
        protected double CurrentPerBranch;
        protected double Voltage;
        public ComponentsInParrallel()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            numRows = ComponentList.RowCount;
            numColls = ComponentList.ColumnCount;
            MiddleCollumn = numColls / 2;
            CreatePanel();
            ResetPanel();
            CurrentResistance = 10;
            Voltage = 12;
            MainCircuit = new Circuit('v', Voltage, 0, CurrentResistance);
            SingleResistorLabelValues();
            DrawCircuit();
        }
        public override void UpdateDimensions()
        {
            ComponentList.RowCount = MainCircuit.Main.ysize +1;// The Plus bits on here control the vertical and horizontal padding
            ComponentList.ColumnCount = MainCircuit.Main.xsize+2;
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
            catch(FormatException)
            {
                UserResistanceValue.Text = "";
                MessageBox.Show("Please enter a resistance Value without units (Value is in ohms)");

            }

        }

        private void AddC_Click(object sender, EventArgs e)
        {
            GeneralComponent ComponentToBeInsertedAt = MainCircuit.Main.GetCopyOfSubList()[0];
            if(ComponentToBeInsertedAt.GetType() != 'b')
            {
                ComponentToBeInsertedAt = ComponentToBeInsertedAt.GetCopyOfSubList()[0];
            }
            MainCircuit.Main.ComponentSearch(ComponentToBeInsertedAt.GetName(), "Insert", new string[] { CurrentResistance.ToString(),"p" });
            MainCircuit.Main.CalculateResistance();
            RefreshDiagram();
            UpdatePointers();
        }

        private void RemoveC_Click(object sender, EventArgs e)
        {
            GeneralComponent ParraComponentList  = MainCircuit.Main.GetCopyOfSubList()[0];
            if (ParraComponentList.GetType() != 'b')
            {
                ParraComponentList.RemoveComponent(ParraComponentList.GetCopyOfSubList()[0]);
                RefreshDiagram();
            }
            UpdatePointers();
        }
        public void UpdatePointers()
        {
            GeneralComponent ParraComponentList = MainCircuit.Main.GetCopyOfSubList()[0];
            if (ParraComponentList.GetType() != 'b') 
            {
                SumResistance = ParraComponentList.GetResistance();
                CurrentPerBranch = ParraComponentList.GetCopyOfSubList()[0].GetCurrent();
                SumCurrent = ParraComponentList.GetCurrent();
                UpdateLabels();
            }
            else
            {
                SingleResistorLabelValues();
            }

        }
        public void UpdateLabels()
        {
            TotalCurrentLabel.Text = PrefixDouble(SumCurrent, 'A');
            ResistanceTotalLabel.Text = PrefixDouble(SumResistance, 'Ω');
            BranchCurrent.Text = PrefixDouble(CurrentPerBranch, 'A');
        }
        public void SingleResistorLabelValues()
        {
            SumResistance = MainCircuit.Main.GetResistance();
            CurrentPerBranch = Voltage / SumResistance;
            SumCurrent = MainCircuit.Main.GetCurrent();
            UpdateLabels();
        }
    }
}

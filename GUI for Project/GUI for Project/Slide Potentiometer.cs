using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_for_Project
{
    public partial class Slide_Potentiometer : Form
    {
        private double TotalResistancePool;
        private double Voltage;
        private double ResistancePercentage;
        private int XCoordLeft = 465;
        public int TotalLength = 203;
        public Slide_Potentiometer()
        {
            InitializeComponent();
            Voltage = SettingsVariables.EMFDefaultValue;
            TotalResistancePool = SettingsVariables.ResistanceDefaultValue;
            ResistancePercentage = 0.5;
            PotenitometerSlide.Value = 50;
            PotenitometerSlide.BackColor = SettingsVariables.ControlBackgroundColour;
            
            UpdateEverything();

        }

        private void PotenitometerSlide_ValueChanged(object sender, EventArgs e)
        {
            UpdateEverything();
        }
        public void UpdateEverything()
        {
            ResistancePercentage = Convert.ToDouble(PotenitometerSlide.Value) / 100;
            BaseCircuitGUI RefForm = new BaseCircuitGUI();
            R1Value.Text = RefForm.PrefixDouble(TotalResistancePool * ResistancePercentage, 'Ω');
            R2Value.Text = RefForm.PrefixDouble(TotalResistancePool * (1 - ResistancePercentage), 'Ω');
            VoltageLabel.Text = RefForm.PrefixDouble(Voltage,'V');
            PotentiometerArm.Location = new Point(XCoordLeft + Convert.ToInt32(ResistancePercentage * TotalLength), PotentiometerArm.Location.Y);
            VoutLabel.Text = RefForm.PrefixDouble(Voltage * ResistancePercentage, 'V');
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Hide();
            LearningModules learningModules = new LearningModules();
            learningModules.ShowDialog();
            Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            Hide();
            Help_Form HelpBox = new Help_Form("Potentiometer Help:","This program demonstrates potential dividers to create an output voltage different to that of the input. \n Hopefully using this software you can also deduce how a slide potentiometer works");
            HelpBox.ShowDialog();
            Show();

        }
    }
}

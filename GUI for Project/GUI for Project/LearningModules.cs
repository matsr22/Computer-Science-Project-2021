﻿using System;
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
    public partial class LearningModules : Form
    {
        public LearningModules()
        {
            InitializeComponent();
        }
        // All the following just Open up new instances of forms when the user selects them with a button click
        private void ParraResistors_Click(object sender, EventArgs e)
        {
            Hide();
            ComponentsInParrallel ParrallelResistors = new ComponentsInParrallel();
            ParrallelResistors.ShowDialog();
            Close();
        }

        private void PowLaws_Click(object sender, EventArgs e)
        {
            Hide();
            Power PowerLawDemos = new Power();
            PowerLawDemos.ShowDialog();
            Close();
        }

        private void Ohms_Click(object sender, EventArgs e)
        {
            Hide();
            OhmsLaw OhmsLawDemo = new OhmsLaw();
            OhmsLawDemo.ShowDialog();
            Close();
        }

        private void SeriesResistors_Click(object sender, EventArgs e)
        {
            Hide();
            ComponentsInSeries SeriesDemo = new ComponentsInSeries();
            SeriesDemo.ShowDialog();
        }

        private void PotentiometerButton_Click(object sender, EventArgs e)
        {
            Hide();
            Slide_Potentiometer potentiometer = new Slide_Potentiometer();
            potentiometer.ShowDialog();
        }

        private void ReturnToPreviousScreen_Click(object sender, EventArgs e)
        {
            Hide();
            StudentPage HomePage = new StudentPage();
            HomePage.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

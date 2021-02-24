using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace GUI_for_Project
{


    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            UpdateTextBoxes();

        }
        public void UpdateTextBoxes()
        {
            MaxValTextBox.Text = SettingsVariables.SliderMaxValue.ToString();
            MinValTextBox.Text = SettingsVariables.SliderMinValue.ToString();
            StepValTextBox.Text = SettingsVariables.SliderStepValue.ToString();
            InitalEMFTextBox.Text = SettingsVariables.EMFDefaultValue.ToString();
            InitalResistanceVal.Text = SettingsVariables.ResistanceDefaultValue.ToString();
            ColourTextBox.Text = ColorTranslator.ToHtml(SettingsVariables.ControlBackgroundColour);
        }
        private void MaxValinfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This controls the maximum value of data sliders found in some learning modules");
        }

        private void MinValinfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This controls the minimum value of data sliders found in some learning modules");
        }

        private void StepInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This controls the step between values on data sliders.\n Set this to a lower value to increase performance\nSet to a higher value to increase precision");
        }

        private void EMFInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Controls default Voltage/Current for supplies");
        }

        private void InitResistanceValInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Controls default resistance for some learning modules");
        }

        private void SystemInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Be careful with this one");// This one will crash the program if Imperial is selected bc why not
        }

        private void ColourThemeInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Changes the Colour of the background of some controls, will probably look horrible but could be a bit of fun");
        }

        private void ApplySettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsVariables.SliderMaxValue = Convert.ToInt32(MaxValTextBox.Text);
                SettingsVariables.SliderMinValue = Convert.ToInt32(MinValTextBox.Text);
                SettingsVariables.SliderStepValue = Convert.ToInt32(StepValTextBox.Text);
                SettingsVariables.EMFDefaultValue = Convert.ToDouble(InitalEMFTextBox.Text);
                SettingsVariables.ResistanceDefaultValue = Convert.ToDouble(InitalResistanceVal.Text);
                SettingsVariables.ControlBackgroundColour = ColorTranslator.FromHtml(ColourTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Input was in incorrect format");
            }
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Hide();
            Form HomePage = new ContentsPage();
            HomePage.ShowDialog();
            Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void SaveStringToFile(string data)
        {
            SaveFileDialog SaveFilePopUp = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                DefaultExt = "elset",
                FileName = "*.elset",
                Filter = "elset files (*.elset)|*.elset"
            };
            if (SaveFilePopUp.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = SaveFilePopUp.OpenFile();
                StreamWriter FileWriting = new StreamWriter(fileStream);
                FileWriting.Write(data);
                FileWriting.Close();
                fileStream.Close();
            }
            else
            {
                MessageBox.Show("Failed to Save File");
            }
        }
        public List<string> OpenStringFromFile()
        {

            OpenFileDialog OpenFilePopUp = new OpenFileDialog 
            {
                InitialDirectory = @"C:\",
                DefaultExt = "elset",
                FileName = "*.elset",
                Filter = "elset files (*.elset)|*.elset"
            };
            if(OpenFilePopUp.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = OpenFilePopUp.OpenFile();
                StreamReader FileReading = new StreamReader(fileStream);
                string line;
                List<string> ToBeReturned = new List<string>();
                while((line = FileReading.ReadLine()) != null)
                {
                    ToBeReturned.Add(line);
                }
                FileReading.Close();
                fileStream.Close();
                return ToBeReturned;
            }
            else
            {
                return null;
            }
        }
        public string CreateStringToBeSaved()
        {
            string Line1 = SettingsVariables.SliderMaxValue.ToString();
            string Line2 = SettingsVariables.SliderMinValue.ToString();
            string Line3 = SettingsVariables.SliderStepValue.ToString();
            string Line4 = SettingsVariables.EMFDefaultValue.ToString();
            string Line5 = SettingsVariables.ResistanceDefaultValue.ToString();
            string Line6 = SettingsVariables.ControlBackgroundColour.ToString();
            return Line1 + "\n" + Line2 + "\n" + Line3 + "\n" + Line4 + "\n" + Line5 + "\n" + Line6;
        }
        public void LoadSettingsFromListT(List<string> ToBeLoaded)
        {
            SettingsVariables.SliderMaxValue = Convert.ToInt32(ToBeLoaded[0]);
            SettingsVariables.SliderMinValue = Convert.ToInt32(ToBeLoaded[1]);
            SettingsVariables.SliderStepValue = Convert.ToInt32(ToBeLoaded[2]);
            SettingsVariables.EMFDefaultValue = Convert.ToDouble(ToBeLoaded[3]);
            SettingsVariables.ResistanceDefaultValue = Convert.ToDouble(ToBeLoaded[4]);
            SettingsVariables.ControlBackgroundColour = ColorTranslator.FromHtml(ToBeLoaded[5]);
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            SaveStringToFile(CreateStringToBeSaved());
        }

        private void LoadSettingsFile_Click(object sender, EventArgs e)
        {
            LoadSettingsFromListT(OpenStringFromFile());
            UpdateTextBoxes();

        }

        private void SystemWideUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedItem = SystemWideUnits.SelectedItem.ToString();
            if (SelectedItem == "Imperial")
            {
                throw new BrainNotFoundException();
            }
        }
    }
    static class SettingsVariables
    {
        public static int SliderMaxValue;
        public static int SliderMinValue;
        public static int SliderStepValue;
        public static double EMFDefaultValue;
        public static double ResistanceDefaultValue;
        public static Color ControlBackgroundColour;
    }
    public class BrainNotFoundException : Exception
    {
        public BrainNotFoundException() { }
    }
}

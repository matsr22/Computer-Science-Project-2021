using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_for_Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SettingsVariables.SliderMaxValue = 100;
            SettingsVariables.SliderMinValue = 1;
            SettingsVariables.SliderStepValue = 1;
            SettingsVariables.EMFDefaultValue = 12;
            SettingsVariables.ResistanceDefaultValue = 10;
            SettingsVariables.ControlBackgroundColour = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            Application.Run(new ContentsPage());
        }

    }
}

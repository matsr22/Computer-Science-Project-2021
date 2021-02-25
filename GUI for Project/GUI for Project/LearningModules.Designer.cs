
namespace GUI_for_Project
{
    partial class LearningModules
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Exit = new System.Windows.Forms.Button();
            this.ReturnToPreviousScreen = new System.Windows.Forms.Button();
            this.ParraResistors = new System.Windows.Forms.Button();
            this.PowLaws = new System.Windows.Forms.Button();
            this.Ohms = new System.Windows.Forms.Button();
            this.SeriesResistors = new System.Windows.Forms.Button();
            this.PotentiometerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(86, 12);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(59, 51);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ReturnToPreviousScreen
            // 
            this.ReturnToPreviousScreen.Location = new System.Drawing.Point(12, 12);
            this.ReturnToPreviousScreen.Name = "ReturnToPreviousScreen";
            this.ReturnToPreviousScreen.Size = new System.Drawing.Size(58, 51);
            this.ReturnToPreviousScreen.TabIndex = 2;
            this.ReturnToPreviousScreen.Text = "Return";
            this.ReturnToPreviousScreen.UseVisualStyleBackColor = true;
            this.ReturnToPreviousScreen.Click += new System.EventHandler(this.ReturnToPreviousScreen_Click);
            // 
            // ParraResistors
            // 
            this.ParraResistors.Location = new System.Drawing.Point(13, 108);
            this.ParraResistors.Name = "ParraResistors";
            this.ParraResistors.Size = new System.Drawing.Size(146, 75);
            this.ParraResistors.TabIndex = 4;
            this.ParraResistors.Text = "Resisitors In  Parrallel";
            this.ParraResistors.UseVisualStyleBackColor = true;
            this.ParraResistors.Click += new System.EventHandler(this.ParraResistors_Click);
            // 
            // PowLaws
            // 
            this.PowLaws.Location = new System.Drawing.Point(184, 108);
            this.PowLaws.Name = "PowLaws";
            this.PowLaws.Size = new System.Drawing.Size(154, 75);
            this.PowLaws.TabIndex = 5;
            this.PowLaws.Text = "Power Laws";
            this.PowLaws.UseVisualStyleBackColor = true;
            this.PowLaws.Click += new System.EventHandler(this.PowLaws_Click);
            // 
            // Ohms
            // 
            this.Ohms.Location = new System.Drawing.Point(363, 108);
            this.Ohms.Name = "Ohms";
            this.Ohms.Size = new System.Drawing.Size(153, 75);
            this.Ohms.TabIndex = 6;
            this.Ohms.Text = "Ohms Law";
            this.Ohms.UseVisualStyleBackColor = true;
            this.Ohms.Click += new System.EventHandler(this.Ohms_Click);
            // 
            // SeriesResistors
            // 
            this.SeriesResistors.Location = new System.Drawing.Point(13, 203);
            this.SeriesResistors.Name = "SeriesResistors";
            this.SeriesResistors.Size = new System.Drawing.Size(146, 80);
            this.SeriesResistors.TabIndex = 7;
            this.SeriesResistors.Text = "Resistors In Series";
            this.SeriesResistors.UseVisualStyleBackColor = true;
            this.SeriesResistors.Click += new System.EventHandler(this.SeriesResistors_Click);
            // 
            // PotentiometerButton
            // 
            this.PotentiometerButton.Location = new System.Drawing.Point(184, 203);
            this.PotentiometerButton.Name = "PotentiometerButton";
            this.PotentiometerButton.Size = new System.Drawing.Size(154, 80);
            this.PotentiometerButton.TabIndex = 8;
            this.PotentiometerButton.Text = "Potential Dividers and Potentiometers";
            this.PotentiometerButton.UseVisualStyleBackColor = true;
            this.PotentiometerButton.Click += new System.EventHandler(this.PotentiometerButton_Click);
            // 
            // LearningModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 405);
            this.Controls.Add(this.PotentiometerButton);
            this.Controls.Add(this.SeriesResistors);
            this.Controls.Add(this.Ohms);
            this.Controls.Add(this.PowLaws);
            this.Controls.Add(this.ParraResistors);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.ReturnToPreviousScreen);
            this.Name = "LearningModules";
            this.Text = "LearningModules";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button ReturnToPreviousScreen;
        private System.Windows.Forms.Button ParraResistors;
        private System.Windows.Forms.Button PowLaws;
        private System.Windows.Forms.Button Ohms;
        private System.Windows.Forms.Button SeriesResistors;
        private System.Windows.Forms.Button PotentiometerButton;
    }
}

namespace GUI_for_Project
{
    partial class SettingsForm
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
            this.Title = new System.Windows.Forms.Label();
            this.MaxValinfo = new System.Windows.Forms.Label();
            this.MinValinfo = new System.Windows.Forms.Label();
            this.StepInfo = new System.Windows.Forms.Label();
            this.EMFInfo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MaxValTextBox = new System.Windows.Forms.TextBox();
            this.MinValTextBox = new System.Windows.Forms.TextBox();
            this.StepValTextBox = new System.Windows.Forms.TextBox();
            this.InitalEMFTextBox = new System.Windows.Forms.TextBox();
            this.InitResistanceValInfo = new System.Windows.Forms.Label();
            this.InitalResistanceVal = new System.Windows.Forms.TextBox();
            this.SystemWideUnits = new System.Windows.Forms.ComboBox();
            this.SystemInfo = new System.Windows.Forms.Label();
            this.ColourThemeInfo = new System.Windows.Forms.Label();
            this.ColourTextBox = new System.Windows.Forms.TextBox();
            this.ApplySettingsButton = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.LoadSettingsFile = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(275, 33);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(194, 24);
            this.Title.TabIndex = 0;
            this.Title.Text = "Application Defaults";
            // 
            // MaxValinfo
            // 
            this.MaxValinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxValinfo.Location = new System.Drawing.Point(46, 110);
            this.MaxValinfo.Name = "MaxValinfo";
            this.MaxValinfo.Size = new System.Drawing.Size(191, 24);
            this.MaxValinfo.TabIndex = 1;
            this.MaxValinfo.Text = "DataSliders Max Value:";
            this.MaxValinfo.Click += new System.EventHandler(this.MaxValinfo_Click);
            // 
            // MinValinfo
            // 
            this.MinValinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinValinfo.Location = new System.Drawing.Point(46, 143);
            this.MinValinfo.Name = "MinValinfo";
            this.MinValinfo.Size = new System.Drawing.Size(191, 24);
            this.MinValinfo.TabIndex = 2;
            this.MinValinfo.Text = "DataSliders Min Value:";
            this.MinValinfo.Click += new System.EventHandler(this.MinValinfo_Click);
            // 
            // StepInfo
            // 
            this.StepInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepInfo.Location = new System.Drawing.Point(46, 176);
            this.StepInfo.Name = "StepInfo";
            this.StepInfo.Size = new System.Drawing.Size(191, 24);
            this.StepInfo.TabIndex = 3;
            this.StepInfo.Text = "DataSliders Step:";
            this.StepInfo.Click += new System.EventHandler(this.StepInfo_Click);
            // 
            // EMFInfo
            // 
            this.EMFInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EMFInfo.Location = new System.Drawing.Point(46, 208);
            this.EMFInfo.Name = "EMFInfo";
            this.EMFInfo.Size = new System.Drawing.Size(191, 24);
            this.EMFInfo.TabIndex = 4;
            this.EMFInfo.Text = "Inital EMF Value";
            this.EMFInfo.Click += new System.EventHandler(this.EMFInfo_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(475, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(313, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "(This will probably break things so have fun)";
            // 
            // MaxValTextBox
            // 
            this.MaxValTextBox.Location = new System.Drawing.Point(244, 110);
            this.MaxValTextBox.Name = "MaxValTextBox";
            this.MaxValTextBox.Size = new System.Drawing.Size(100, 20);
            this.MaxValTextBox.TabIndex = 6;
            // 
            // MinValTextBox
            // 
            this.MinValTextBox.Location = new System.Drawing.Point(244, 143);
            this.MinValTextBox.Name = "MinValTextBox";
            this.MinValTextBox.Size = new System.Drawing.Size(100, 20);
            this.MinValTextBox.TabIndex = 7;
            // 
            // StepValTextBox
            // 
            this.StepValTextBox.Location = new System.Drawing.Point(244, 176);
            this.StepValTextBox.Name = "StepValTextBox";
            this.StepValTextBox.Size = new System.Drawing.Size(100, 20);
            this.StepValTextBox.TabIndex = 8;
            // 
            // InitalEMFTextBox
            // 
            this.InitalEMFTextBox.Location = new System.Drawing.Point(244, 208);
            this.InitalEMFTextBox.Name = "InitalEMFTextBox";
            this.InitalEMFTextBox.Size = new System.Drawing.Size(100, 20);
            this.InitalEMFTextBox.TabIndex = 9;
            // 
            // InitResistanceValInfo
            // 
            this.InitResistanceValInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InitResistanceValInfo.Location = new System.Drawing.Point(46, 240);
            this.InitResistanceValInfo.Name = "InitResistanceValInfo";
            this.InitResistanceValInfo.Size = new System.Drawing.Size(191, 24);
            this.InitResistanceValInfo.TabIndex = 10;
            this.InitResistanceValInfo.Text = "Inital Resistance Value";
            this.InitResistanceValInfo.Click += new System.EventHandler(this.InitResistanceValInfo_Click);
            // 
            // InitalResistanceVal
            // 
            this.InitalResistanceVal.Location = new System.Drawing.Point(244, 240);
            this.InitalResistanceVal.Name = "InitalResistanceVal";
            this.InitalResistanceVal.Size = new System.Drawing.Size(100, 20);
            this.InitalResistanceVal.TabIndex = 11;
            // 
            // SystemWideUnits
            // 
            this.SystemWideUnits.FormattingEnabled = true;
            this.SystemWideUnits.Items.AddRange(new object[] {
            "Metric",
            "Imperial"});
            this.SystemWideUnits.Location = new System.Drawing.Point(244, 268);
            this.SystemWideUnits.Name = "SystemWideUnits";
            this.SystemWideUnits.Size = new System.Drawing.Size(100, 21);
            this.SystemWideUnits.TabIndex = 12;
            this.SystemWideUnits.SelectedIndexChanged += new System.EventHandler(this.SystemWideUnits_SelectedIndexChanged);
            // 
            // SystemInfo
            // 
            this.SystemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystemInfo.Location = new System.Drawing.Point(47, 267);
            this.SystemInfo.Name = "SystemInfo";
            this.SystemInfo.Size = new System.Drawing.Size(191, 24);
            this.SystemInfo.TabIndex = 13;
            this.SystemInfo.Text = "Unit System";
            this.SystemInfo.Click += new System.EventHandler(this.SystemInfo_Click);
            // 
            // ColourThemeInfo
            // 
            this.ColourThemeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColourThemeInfo.Location = new System.Drawing.Point(47, 293);
            this.ColourThemeInfo.Name = "ColourThemeInfo";
            this.ColourThemeInfo.Size = new System.Drawing.Size(191, 24);
            this.ColourThemeInfo.TabIndex = 14;
            this.ColourThemeInfo.Text = "Colour Theme(HEX)";
            this.ColourThemeInfo.Click += new System.EventHandler(this.ColourThemeInfo_Click);
            // 
            // ColourTextBox
            // 
            this.ColourTextBox.Location = new System.Drawing.Point(244, 295);
            this.ColourTextBox.Name = "ColourTextBox";
            this.ColourTextBox.Size = new System.Drawing.Size(100, 20);
            this.ColourTextBox.TabIndex = 15;
            // 
            // ApplySettingsButton
            // 
            this.ApplySettingsButton.Location = new System.Drawing.Point(51, 333);
            this.ApplySettingsButton.Name = "ApplySettingsButton";
            this.ApplySettingsButton.Size = new System.Drawing.Size(293, 64);
            this.ApplySettingsButton.TabIndex = 16;
            this.ApplySettingsButton.Text = "Apply Settings";
            this.ApplySettingsButton.UseVisualStyleBackColor = true;
            this.ApplySettingsButton.Click += new System.EventHandler(this.ApplySettingsButton_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(380, 333);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(136, 64);
            this.SaveFileButton.TabIndex = 17;
            this.SaveFileButton.Text = "Save Settings To File";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // LoadSettingsFile
            // 
            this.LoadSettingsFile.Location = new System.Drawing.Point(542, 333);
            this.LoadSettingsFile.Name = "LoadSettingsFile";
            this.LoadSettingsFile.Size = new System.Drawing.Size(136, 64);
            this.LoadSettingsFile.TabIndex = 18;
            this.LoadSettingsFile.Text = "Load Settings From File";
            this.LoadSettingsFile.UseVisualStyleBackColor = true;
            this.LoadSettingsFile.Click += new System.EventHandler(this.LoadSettingsFile_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(78, 18);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(59, 55);
            this.Exit.TabIndex = 20;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(14, 18);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(58, 55);
            this.ReturnButton.TabIndex = 19;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "Press on Settings Lables for more info";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(361, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 24);
            this.label2.TabIndex = 22;
            this.label2.Text = "(int)";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(361, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 24);
            this.label3.TabIndex = 23;
            this.label3.Text = "(int)";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(361, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 24);
            this.label4.TabIndex = 24;
            this.label4.Text = "(int)";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(361, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 24);
            this.label6.TabIndex = 25;
            this.label6.Text = "(decimal)";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(361, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 24);
            this.label7.TabIndex = 26;
            this.label7.Text = "(decimal)";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(361, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 24);
            this.label8.TabIndex = 27;
            this.label8.Text = "Type:";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(361, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 24);
            this.label9.TabIndex = 28;
            this.label9.Text = "(RGB CODE)";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 411);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.LoadSettingsFile);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.ApplySettingsButton);
            this.Controls.Add(this.ColourTextBox);
            this.Controls.Add(this.ColourThemeInfo);
            this.Controls.Add(this.SystemInfo);
            this.Controls.Add(this.SystemWideUnits);
            this.Controls.Add(this.InitalResistanceVal);
            this.Controls.Add(this.InitResistanceValInfo);
            this.Controls.Add(this.InitalEMFTextBox);
            this.Controls.Add(this.StepValTextBox);
            this.Controls.Add(this.MinValTextBox);
            this.Controls.Add(this.MaxValTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EMFInfo);
            this.Controls.Add(this.StepInfo);
            this.Controls.Add(this.MinValinfo);
            this.Controls.Add(this.MaxValinfo);
            this.Controls.Add(this.Title);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label MaxValinfo;
        private System.Windows.Forms.Label MinValinfo;
        private System.Windows.Forms.Label StepInfo;
        private System.Windows.Forms.Label EMFInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MaxValTextBox;
        private System.Windows.Forms.TextBox MinValTextBox;
        private System.Windows.Forms.TextBox StepValTextBox;
        private System.Windows.Forms.TextBox InitalEMFTextBox;
        private System.Windows.Forms.Label InitResistanceValInfo;
        private System.Windows.Forms.TextBox InitalResistanceVal;
        private System.Windows.Forms.ComboBox SystemWideUnits;
        private System.Windows.Forms.Label SystemInfo;
        private System.Windows.Forms.Label ColourThemeInfo;
        private System.Windows.Forms.TextBox ColourTextBox;
        private System.Windows.Forms.Button ApplySettingsButton;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.Button LoadSettingsFile;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}
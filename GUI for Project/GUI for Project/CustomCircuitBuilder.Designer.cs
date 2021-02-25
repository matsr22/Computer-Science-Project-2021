
namespace GUI_for_Project
{
    partial class CustomCircuitBuilder
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ClickActions = new System.Windows.Forms.ComboBox();
            this.Reset = new System.Windows.Forms.Button();
            this.RecalculateValues = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VoltageDisplay = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CurrentVal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.ClickActions);
            this.panel1.Controls.Add(this.Reset);
            this.panel1.Controls.Add(this.RecalculateValues);
            this.panel1.Location = new System.Drawing.Point(44, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 12;
            // 
            // ClickActions
            // 
            this.ClickActions.FormattingEnabled = true;
            this.ClickActions.Items.AddRange(new object[] {
            "Edit Values",
            "Add Resistor In Parrallel",
            "Add Resistor In Series",
            "Remove Resistor",
            "Current Probe",
            "Voltage Probe"});
            this.ClickActions.Location = new System.Drawing.Point(8, 11);
            this.ClickActions.Name = "ClickActions";
            this.ClickActions.Size = new System.Drawing.Size(189, 21);
            this.ClickActions.TabIndex = 9;
            this.ClickActions.Text = "Action on Click";
            // 
            // Reset
            // 
            this.Reset.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Reset.Location = new System.Drawing.Point(8, 39);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(189, 23);
            this.Reset.TabIndex = 8;
            this.Reset.Text = "Reset Panel To Default";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // RecalculateValues
            // 
            this.RecalculateValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RecalculateValues.Location = new System.Drawing.Point(8, 69);
            this.RecalculateValues.Name = "RecalculateValues";
            this.RecalculateValues.Size = new System.Drawing.Size(189, 23);
            this.RecalculateValues.TabIndex = 7;
            this.RecalculateValues.Text = "Calculate Voltage/Current Values";
            this.RecalculateValues.UseVisualStyleBackColor = true;
            this.RecalculateValues.Click += new System.EventHandler(this.RecalculateValues_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox1.Controls.Add(this.VoltageDisplay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CurrentVal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(52, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 173);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // VoltageDisplay
            // 
            this.VoltageDisplay.Location = new System.Drawing.Point(20, 133);
            this.VoltageDisplay.Name = "VoltageDisplay";
            this.VoltageDisplay.Size = new System.Drawing.Size(132, 23);
            this.VoltageDisplay.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "Voltage On Component:";
            // 
            // CurrentVal
            // 
            this.CurrentVal.Location = new System.Drawing.Point(20, 49);
            this.CurrentVal.Name = "CurrentVal";
            this.CurrentVal.Size = new System.Drawing.Size(100, 23);
            this.CurrentVal.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Current Probe Value:";
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(61, 201);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(97, 42);
            this.ReturnButton.TabIndex = 16;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.Location = new System.Drawing.Point(61, 250);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(97, 42);
            this.HelpButton.TabIndex = 17;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // CustomCircuitBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1213, 514);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "CustomCircuitBuilder";
            this.Text = "Custom Circuit Builder";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.ReturnButton, 0);
            this.Controls.SetChildIndex(this.HelpButton, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox ClickActions;
        private System.Windows.Forms.Button Reset;
        protected internal System.Windows.Forms.Button RecalculateValues;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label VoltageDisplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label CurrentVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.Button HelpButton;
    }
}

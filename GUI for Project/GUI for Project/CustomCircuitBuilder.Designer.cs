
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
            this.button1 = new System.Windows.Forms.Button();
            this.CurrentVal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.ClickActions);
            this.panel1.Controls.Add(this.Reset);
            this.panel1.Controls.Add(this.button1);
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
            "Current Probe"});
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
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(8, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Calculate Voltage/Current Values";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CurrentVal
            // 
            this.CurrentVal.Location = new System.Drawing.Point(66, 54);
            this.CurrentVal.Name = "CurrentVal";
            this.CurrentVal.Size = new System.Drawing.Size(100, 23);
            this.CurrentVal.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(63, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Current Probe Value:";
            // 
            // CustomCircuitBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1213, 514);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CurrentVal);
            this.Controls.Add(this.label1);
            this.Name = "CustomCircuitBuilder";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.CurrentVal, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox ClickActions;
        private System.Windows.Forms.Button Reset;
        protected internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CurrentVal;
        private System.Windows.Forms.Label label1;
    }
}

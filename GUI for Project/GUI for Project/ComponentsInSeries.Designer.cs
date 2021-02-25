
namespace GUI_for_Project
{
    partial class ComponentsInSeries
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
            this.SubVoltageValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TotalCurrentLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResistanceTotalLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EditResistance = new System.Windows.Forms.Button();
            this.UserResistanceValue = new System.Windows.Forms.TextBox();
            this.RemoveC = new System.Windows.Forms.Button();
            this.AddC = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SubVoltageValue);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TotalCurrentLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ResistanceTotalLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(41, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 183);
            this.panel1.TabIndex = 8;
            // 
            // SubVoltageValue
            // 
            this.SubVoltageValue.Location = new System.Drawing.Point(23, 150);
            this.SubVoltageValue.Name = "SubVoltageValue";
            this.SubVoltageValue.Size = new System.Drawing.Size(100, 23);
            this.SubVoltageValue.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Voltage Per Resistor";
            // 
            // TotalCurrentLabel
            // 
            this.TotalCurrentLabel.Location = new System.Drawing.Point(20, 92);
            this.TotalCurrentLabel.Name = "TotalCurrentLabel";
            this.TotalCurrentLabel.Size = new System.Drawing.Size(179, 22);
            this.TotalCurrentLabel.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total Current:";
            // 
            // ResistanceTotalLabel
            // 
            this.ResistanceTotalLabel.Location = new System.Drawing.Point(20, 32);
            this.ResistanceTotalLabel.Name = "ResistanceTotalLabel";
            this.ResistanceTotalLabel.Size = new System.Drawing.Size(179, 23);
            this.ResistanceTotalLabel.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Total Resistance:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.EditResistance);
            this.panel2.Controls.Add(this.UserResistanceValue);
            this.panel2.Controls.Add(this.RemoveC);
            this.panel2.Controls.Add(this.AddC);
            this.panel2.Location = new System.Drawing.Point(41, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 121);
            this.panel2.TabIndex = 9;
            // 
            // EditResistance
            // 
            this.EditResistance.Location = new System.Drawing.Point(140, 14);
            this.EditResistance.Name = "EditResistance";
            this.EditResistance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EditResistance.Size = new System.Drawing.Size(97, 23);
            this.EditResistance.TabIndex = 13;
            this.EditResistance.Text = "Edit Resistance";
            this.EditResistance.UseVisualStyleBackColor = true;
            this.EditResistance.Click += new System.EventHandler(this.EditResistance_Click);
            // 
            // UserResistanceValue
            // 
            this.UserResistanceValue.Location = new System.Drawing.Point(17, 14);
            this.UserResistanceValue.Name = "UserResistanceValue";
            this.UserResistanceValue.Size = new System.Drawing.Size(107, 20);
            this.UserResistanceValue.TabIndex = 12;
            // 
            // RemoveC
            // 
            this.RemoveC.Location = new System.Drawing.Point(17, 84);
            this.RemoveC.Name = "RemoveC";
            this.RemoveC.Size = new System.Drawing.Size(220, 23);
            this.RemoveC.TabIndex = 11;
            this.RemoveC.Text = "Remove Component";
            this.RemoveC.UseVisualStyleBackColor = true;
            this.RemoveC.Click += new System.EventHandler(this.RemoveC_Click);
            // 
            // AddC
            // 
            this.AddC.Location = new System.Drawing.Point(17, 45);
            this.AddC.Name = "AddC";
            this.AddC.Size = new System.Drawing.Size(220, 23);
            this.AddC.TabIndex = 10;
            this.AddC.Text = "Add Component";
            this.AddC.UseVisualStyleBackColor = true;
            this.AddC.Click += new System.EventHandler(this.AddC_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(41, 236);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(99, 65);
            this.ReturnButton.TabIndex = 10;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // ComponentsInSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1213, 514);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ComponentsInSeries";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.ReturnButton, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SubVoltageValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TotalCurrentLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ResistanceTotalLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button EditResistance;
        private System.Windows.Forms.TextBox UserResistanceValue;
        private System.Windows.Forms.Button RemoveC;
        private System.Windows.Forms.Button AddC;
        private System.Windows.Forms.Button ReturnButton;
    }
}

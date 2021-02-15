namespace GUI_for_Project
{
    partial class InputForm
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
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.UnitListBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InstructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionLabel.Location = new System.Drawing.Point(30, 63);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(719, 50);
            this.InstructionLabel.TabIndex = 0;
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(30, 126);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(144, 20);
            this.InputBox.TabIndex = 1;
            this.InputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyDown);
            // 
            // UnitListBox
            // 
            this.UnitListBox.FormattingEnabled = true;
            this.UnitListBox.Location = new System.Drawing.Point(198, 126);
            this.UnitListBox.Name = "UnitListBox";
            this.UnitListBox.Size = new System.Drawing.Size(57, 21);
            this.UnitListBox.TabIndex = 2;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UnitListBox);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.InstructionLabel);
            this.Name = "InputForm";
            this.Text = "UserInputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.ComboBox UnitListBox;
    }
}
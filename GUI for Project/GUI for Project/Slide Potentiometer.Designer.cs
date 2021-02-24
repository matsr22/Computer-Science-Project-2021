
namespace GUI_for_Project
{
    partial class Slide_Potentiometer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Slide_Potentiometer));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PotentiometerArm = new System.Windows.Forms.PictureBox();
            this.PotenitometerSlide = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.R1Value = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.R2Value = new System.Windows.Forms.Label();
            this.VoutLabel = new System.Windows.Forms.Label();
            this.VoltageLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PotentiometerArm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PotenitometerSlide)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(191, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(844, 471);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PotentiometerArm
            // 
            this.PotentiometerArm.Image = ((System.Drawing.Image)(resources.GetObject("PotentiometerArm.Image")));
            this.PotentiometerArm.Location = new System.Drawing.Point(501, 367);
            this.PotentiometerArm.Name = "PotentiometerArm";
            this.PotentiometerArm.Size = new System.Drawing.Size(90, 112);
            this.PotentiometerArm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PotentiometerArm.TabIndex = 1;
            this.PotentiometerArm.TabStop = false;
            // 
            // PotenitometerSlide
            // 
            this.PotenitometerSlide.Cursor = System.Windows.Forms.Cursors.Default;
            this.PotenitometerSlide.Location = new System.Drawing.Point(498, 267);
            this.PotenitometerSlide.Maximum = 100;
            this.PotenitometerSlide.Name = "PotenitometerSlide";
            this.PotenitometerSlide.Size = new System.Drawing.Size(222, 45);
            this.PotenitometerSlide.TabIndex = 2;
            this.PotenitometerSlide.Value = 1;
            this.PotenitometerSlide.ValueChanged += new System.EventHandler(this.PotenitometerSlide_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "V OUT:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(498, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "R1:";
            // 
            // R1Value
            // 
            this.R1Value.AutoSize = true;
            this.R1Value.Location = new System.Drawing.Point(529, 219);
            this.R1Value.Name = "R1Value";
            this.R1Value.Size = new System.Drawing.Size(0, 13);
            this.R1Value.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(617, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "R2";
            // 
            // R2Value
            // 
            this.R2Value.AutoSize = true;
            this.R2Value.Location = new System.Drawing.Point(663, 219);
            this.R2Value.Name = "R2Value";
            this.R2Value.Size = new System.Drawing.Size(0, 13);
            this.R2Value.TabIndex = 8;
            // 
            // VoutLabel
            // 
            this.VoutLabel.Location = new System.Drawing.Point(404, 454);
            this.VoutLabel.Name = "VoutLabel";
            this.VoutLabel.Size = new System.Drawing.Size(88, 23);
            this.VoutLabel.TabIndex = 11;
            // 
            // VoltageLabel
            // 
            this.VoltageLabel.Location = new System.Drawing.Point(617, 86);
            this.VoltageLabel.Name = "VoltageLabel";
            this.VoltageLabel.Size = new System.Drawing.Size(33, 23);
            this.VoltageLabel.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(537, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Slide Potentiometer";
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(27, 47);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(106, 50);
            this.BackButton.TabIndex = 14;
            this.BackButton.Text = "Return";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(27, 104);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(106, 50);
            this.ExitButton.TabIndex = 15;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.Location = new System.Drawing.Point(27, 160);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(106, 54);
            this.HelpButton.TabIndex = 16;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // Slide_Potentiometer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 518);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.VoltageLabel);
            this.Controls.Add(this.VoutLabel);
            this.Controls.Add(this.R2Value);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.R1Value);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PotenitometerSlide);
            this.Controls.Add(this.PotentiometerArm);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Slide_Potentiometer";
            this.Text = "Resistivity_Demo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PotentiometerArm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PotenitometerSlide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox PotentiometerArm;
        private System.Windows.Forms.TrackBar PotenitometerSlide;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label R1Value;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label R2Value;
        private System.Windows.Forms.Label VoutLabel;
        private System.Windows.Forms.Label VoltageLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button HelpButton;
    }
}
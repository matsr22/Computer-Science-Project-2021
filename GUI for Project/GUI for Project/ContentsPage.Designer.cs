namespace GUI_for_Project
{
    partial class ContentsPage
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
            this.Settings = new System.Windows.Forms.Button();
            this.GoToStudent = new System.Windows.Forms.Button();
            this.CreditsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(80, 116);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(316, 212);
            this.Settings.TabIndex = 2;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // GoToStudent
            // 
            this.GoToStudent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GoToStudent.Location = new System.Drawing.Point(416, 116);
            this.GoToStudent.Name = "GoToStudent";
            this.GoToStudent.Size = new System.Drawing.Size(314, 212);
            this.GoToStudent.TabIndex = 0;
            this.GoToStudent.Text = "Student";
            this.GoToStudent.UseVisualStyleBackColor = true;
            this.GoToStudent.Click += new System.EventHandler(this.GoToStudent_Click);
            // 
            // CreditsButton
            // 
            this.CreditsButton.Location = new System.Drawing.Point(747, 116);
            this.CreditsButton.Name = "CreditsButton";
            this.CreditsButton.Size = new System.Drawing.Size(320, 212);
            this.CreditsButton.TabIndex = 3;
            this.CreditsButton.Text = "Credits";
            this.CreditsButton.UseVisualStyleBackColor = true;
            this.CreditsButton.Click += new System.EventHandler(this.CreditsButton_Click);
            // 
            // ContentsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 549);
            this.Controls.Add(this.CreditsButton);
            this.Controls.Add(this.GoToStudent);
            this.Controls.Add(this.Settings);
            this.Name = "ContentsPage";
            this.Text = "Contents Page";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button GoToStudent;
        private System.Windows.Forms.Button CreditsButton;
    }
}


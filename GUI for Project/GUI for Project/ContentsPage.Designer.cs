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
            this.Exit = new System.Windows.Forms.Button();
            this.GoToTeacher = new System.Windows.Forms.Button();
            this.GoToStudent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(13, 13);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(58, 54);
            this.Settings.TabIndex = 2;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(77, 13);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(59, 54);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // GoToTeacher
            // 
            this.GoToTeacher.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GoToTeacher.Location = new System.Drawing.Point(143, 124);
            this.GoToTeacher.Name = "GoToTeacher";
            this.GoToTeacher.Size = new System.Drawing.Size(317, 212);
            this.GoToTeacher.TabIndex = 1;
            this.GoToTeacher.Text = "Teacher";
            this.GoToTeacher.UseVisualStyleBackColor = true;
            this.GoToTeacher.Click += new System.EventHandler(this.GoToTeacher_Click);
            // 
            // GoToStudent
            // 
            this.GoToStudent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GoToStudent.Location = new System.Drawing.Point(553, 124);
            this.GoToStudent.Name = "GoToStudent";
            this.GoToStudent.Size = new System.Drawing.Size(345, 212);
            this.GoToStudent.TabIndex = 0;
            this.GoToStudent.Text = "Student";
            this.GoToStudent.UseVisualStyleBackColor = true;
            this.GoToStudent.Click += new System.EventHandler(this.GoToStudent_Click);
            // 
            // ContentsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 386);
            this.Controls.Add(this.GoToStudent);
            this.Controls.Add(this.GoToTeacher);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Settings);
            this.Name = "ContentsPage";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button GoToTeacher;
        private System.Windows.Forms.Button GoToStudent;
    }
}


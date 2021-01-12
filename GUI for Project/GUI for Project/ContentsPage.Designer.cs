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
            this.GoToStudent = new System.Windows.Forms.Button();
            this.GoToTeacher = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GoToStudent
            // 
            this.GoToStudent.Location = new System.Drawing.Point(473, 168);
            this.GoToStudent.Name = "GoToStudent";
            this.GoToStudent.Size = new System.Drawing.Size(209, 92);
            this.GoToStudent.TabIndex = 0;
            this.GoToStudent.Text = "Student";
            this.GoToStudent.UseVisualStyleBackColor = true;
            this.GoToStudent.Click += new System.EventHandler(this.GoToStudent_Click);
            // 
            // GoToTeacher
            // 
            this.GoToTeacher.Location = new System.Drawing.Point(170, 168);
            this.GoToTeacher.Name = "GoToTeacher";
            this.GoToTeacher.Size = new System.Drawing.Size(200, 90);
            this.GoToTeacher.TabIndex = 1;
            this.GoToTeacher.Text = "Teacher";
            this.GoToTeacher.UseVisualStyleBackColor = true;
            this.GoToTeacher.Click += new System.EventHandler(this.GoToTeacher_Click);
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
            // ContentsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.GoToTeacher);
            this.Controls.Add(this.GoToStudent);
            this.Name = "ContentsPage";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoToStudent;
        private System.Windows.Forms.Button GoToTeacher;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button Exit;
    }
}


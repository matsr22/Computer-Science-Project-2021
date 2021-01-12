namespace GUI_for_Project
{
    partial class StudentPage
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
            this.ReturnToPreviousScreen = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.CustomBuilder = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.Button();
            this.OpenLearningModule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReturnToPreviousScreen
            // 
            this.ReturnToPreviousScreen.Location = new System.Drawing.Point(12, 12);
            this.ReturnToPreviousScreen.Name = "ReturnToPreviousScreen";
            this.ReturnToPreviousScreen.Size = new System.Drawing.Size(58, 51);
            this.ReturnToPreviousScreen.TabIndex = 0;
            this.ReturnToPreviousScreen.Text = "Return";
            this.ReturnToPreviousScreen.UseVisualStyleBackColor = true;
            this.ReturnToPreviousScreen.Click += new System.EventHandler(this.Return);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(86, 12);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(59, 51);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // CustomBuilder
            // 
            this.CustomBuilder.Location = new System.Drawing.Point(505, 182);
            this.CustomBuilder.Name = "CustomBuilder";
            this.CustomBuilder.Size = new System.Drawing.Size(164, 62);
            this.CustomBuilder.TabIndex = 2;
            this.CustomBuilder.Text = "Custom Circuit Builder";
            this.CustomBuilder.UseVisualStyleBackColor = true;
            this.CustomBuilder.Click += new System.EventHandler(this.CustomBuilder_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(302, 182);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(146, 62);
            this.OpenFile.TabIndex = 3;
            this.OpenFile.Text = "OpenFile";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // OpenLearningModule
            // 
            this.OpenLearningModule.Location = new System.Drawing.Point(107, 182);
            this.OpenLearningModule.Name = "OpenLearningModule";
            this.OpenLearningModule.Size = new System.Drawing.Size(143, 62);
            this.OpenLearningModule.TabIndex = 4;
            this.OpenLearningModule.Text = "LearningModules";
            this.OpenLearningModule.UseVisualStyleBackColor = true;
            this.OpenLearningModule.Click += new System.EventHandler(this.OpenLearningModule_Click);
            // 
            // StudentPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OpenLearningModule);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.CustomBuilder);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.ReturnToPreviousScreen);
            this.Name = "StudentPage";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReturnToPreviousScreen;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button CustomBuilder;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button OpenLearningModule;
    }
}
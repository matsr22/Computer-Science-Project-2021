
namespace GUI_for_Project
{
    partial class Power
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PowerLawDigram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GraphTypeControl = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PlotGraphPoint = new System.Windows.Forms.Button();
            this.PowerToggle = new System.Windows.Forms.Button();
            this.PowerLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VariableEMF = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.VariableResistance = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.PowerLawDigram)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VariableEMF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VariableResistance)).BeginInit();
            this.SuspendLayout();
            // 
            // PowerLawDigram
            // 
            this.PowerLawDigram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            chartArea2.Name = "PowerChartArea";
            this.PowerLawDigram.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.PowerLawDigram.Legends.Add(legend2);
            this.PowerLawDigram.Location = new System.Drawing.Point(12, 279);
            this.PowerLawDigram.Name = "PowerLawDigram";
            series2.ChartArea = "PowerChartArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "PowerSeries";
            this.PowerLawDigram.Series.Add(series2);
            this.PowerLawDigram.Size = new System.Drawing.Size(300, 223);
            this.PowerLawDigram.TabIndex = 10;
            this.PowerLawDigram.Text = "Power Chart";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GraphTypeControl);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.PlotGraphPoint);
            this.panel1.Controls.Add(this.PowerToggle);
            this.panel1.Controls.Add(this.PowerLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.VariableEMF);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.VariableResistance);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 263);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // GraphTypeControl
            // 
            this.GraphTypeControl.FormattingEnabled = true;
            this.GraphTypeControl.Items.AddRange(new object[] {
            "Power - Y, EMFValue - X",
            "Power - Y, EMFValue^2 - X"});
            this.GraphTypeControl.Location = new System.Drawing.Point(132, 226);
            this.GraphTypeControl.Name = "GraphTypeControl";
            this.GraphTypeControl.Size = new System.Drawing.Size(158, 17);
            this.GraphTypeControl.TabIndex = 19;
            this.GraphTypeControl.SelectedIndexChanged += new System.EventHandler(this.GraphTypeControl_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 24);
            this.button1.TabIndex = 18;
            this.button1.Text = "Clear Graph";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // PlotGraphPoint
            // 
            this.PlotGraphPoint.Location = new System.Drawing.Point(165, 191);
            this.PlotGraphPoint.Name = "PlotGraphPoint";
            this.PlotGraphPoint.Size = new System.Drawing.Size(112, 31);
            this.PlotGraphPoint.TabIndex = 17;
            this.PlotGraphPoint.Text = "Plot Graph Point";
            this.PlotGraphPoint.UseVisualStyleBackColor = true;
            this.PlotGraphPoint.Click += new System.EventHandler(this.PlotGraphPoint_Click);
            // 
            // PowerToggle
            // 
            this.PowerToggle.Location = new System.Drawing.Point(4, 191);
            this.PowerToggle.Name = "PowerToggle";
            this.PowerToggle.Size = new System.Drawing.Size(122, 31);
            this.PowerToggle.TabIndex = 16;
            this.PowerToggle.Text = "Toggle Power Type";
            this.PowerToggle.UseVisualStyleBackColor = true;
            this.PowerToggle.Click += new System.EventHandler(this.PowerToggle_Click);
            // 
            // PowerLabel
            // 
            this.PowerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerLabel.Location = new System.Drawing.Point(133, 128);
            this.PowerLabel.Name = "PowerLabel";
            this.PowerLabel.Size = new System.Drawing.Size(144, 41);
            this.PowerLabel.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Power:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "EMF value (A/V)";
            // 
            // VariableEMF
            // 
            this.VariableEMF.Location = new System.Drawing.Point(63, 74);
            this.VariableEMF.Maximum = 100;
            this.VariableEMF.Minimum = 1;
            this.VariableEMF.Name = "VariableEMF";
            this.VariableEMF.Size = new System.Drawing.Size(238, 45);
            this.VariableEMF.TabIndex = 12;
            this.VariableEMF.Value = 1;
            this.VariableEMF.ValueChanged += new System.EventHandler(this.VariableEMF_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Resistance(Ω)";
            // 
            // VariableResistance
            // 
            this.VariableResistance.Location = new System.Drawing.Point(63, 23);
            this.VariableResistance.Maximum = 100;
            this.VariableResistance.Minimum = 1;
            this.VariableResistance.Name = "VariableResistance";
            this.VariableResistance.Size = new System.Drawing.Size(238, 45);
            this.VariableResistance.TabIndex = 10;
            this.VariableResistance.Value = 1;
            this.VariableResistance.ValueChanged += new System.EventHandler(this.VariableResistance_ValueChanged);
            // 
            // Power
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1213, 514);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PowerLawDigram);
            this.Name = "Power";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Power_FormClosed);
            this.Load += new System.EventHandler(this.Power_Load);
            this.Controls.SetChildIndex(this.PowerLawDigram, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.PowerLawDigram)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VariableEMF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VariableResistance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart PowerLawDigram;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button PlotGraphPoint;
        private System.Windows.Forms.Button PowerToggle;
        private System.Windows.Forms.Label PowerLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar VariableEMF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar VariableResistance;
        private System.Windows.Forms.ListBox GraphTypeControl;
        private System.Windows.Forms.Button button1;
    }
}

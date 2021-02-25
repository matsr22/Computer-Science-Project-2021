
namespace GUI_for_Project
{
    partial class OhmsLaw
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.OhmsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BackButton = new System.Windows.Forms.Button();
            this.ClearGraph = new System.Windows.Forms.Button();
            this.GraphPlot = new System.Windows.Forms.Button();
            this.CurrentLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResistanceLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VoltageLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ResistanceSlider = new System.Windows.Forms.TrackBar();
            this.VoltageSlider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.OhmsChart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResistanceSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VoltageSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // OhmsChart
            // 
            this.OhmsChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            chartArea1.Name = "PowerChartArea";
            this.OhmsChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.OhmsChart.Legends.Add(legend1);
            this.OhmsChart.Location = new System.Drawing.Point(22, 333);
            this.OhmsChart.Name = "OhmsChart";
            series1.ChartArea = "PowerChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "PowerSeries";
            this.OhmsChart.Series.Add(series1);
            this.OhmsChart.Size = new System.Drawing.Size(290, 169);
            this.OhmsChart.TabIndex = 11;
            this.OhmsChart.Text = "OhmsChart";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BackButton);
            this.panel1.Controls.Add(this.ClearGraph);
            this.panel1.Controls.Add(this.GraphPlot);
            this.panel1.Controls.Add(this.CurrentLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ResistanceLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.VoltageLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ResistanceSlider);
            this.panel1.Controls.Add(this.VoltageSlider);
            this.panel1.Location = new System.Drawing.Point(32, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 315);
            this.panel1.TabIndex = 12;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(188, 266);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(74, 33);
            this.BackButton.TabIndex = 20;
            this.BackButton.Text = "Return";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ClearGraph
            // 
            this.ClearGraph.Location = new System.Drawing.Point(98, 266);
            this.ClearGraph.Name = "ClearGraph";
            this.ClearGraph.Size = new System.Drawing.Size(83, 33);
            this.ClearGraph.TabIndex = 19;
            this.ClearGraph.Text = "Clear Graph";
            this.ClearGraph.UseVisualStyleBackColor = true;
            this.ClearGraph.Click += new System.EventHandler(this.ClearGraph_Click);
            // 
            // GraphPlot
            // 
            this.GraphPlot.Location = new System.Drawing.Point(11, 266);
            this.GraphPlot.Name = "GraphPlot";
            this.GraphPlot.Size = new System.Drawing.Size(81, 33);
            this.GraphPlot.TabIndex = 18;
            this.GraphPlot.Text = "Plot Point";
            this.GraphPlot.UseVisualStyleBackColor = true;
            this.GraphPlot.Click += new System.EventHandler(this.GraphPlot_Click);
            // 
            // CurrentLabel
            // 
            this.CurrentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentLabel.Location = new System.Drawing.Point(130, 231);
            this.CurrentLabel.Name = "CurrentLabel";
            this.CurrentLabel.Size = new System.Drawing.Size(100, 23);
            this.CurrentLabel.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 16;
            this.label3.Text = "Current:";
            // 
            // ResistanceLabel
            // 
            this.ResistanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResistanceLabel.Location = new System.Drawing.Point(130, 124);
            this.ResistanceLabel.Name = "ResistanceLabel";
            this.ResistanceLabel.Size = new System.Drawing.Size(100, 32);
            this.ResistanceLabel.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Resistance:";
            // 
            // VoltageLabel
            // 
            this.VoltageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoltageLabel.Location = new System.Drawing.Point(109, 14);
            this.VoltageLabel.Name = "VoltageLabel";
            this.VoltageLabel.Size = new System.Drawing.Size(111, 23);
            this.VoltageLabel.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Voltage:";
            // 
            // ResistanceSlider
            // 
            this.ResistanceSlider.Location = new System.Drawing.Point(3, 168);
            this.ResistanceSlider.Maximum = 100;
            this.ResistanceSlider.Minimum = 1;
            this.ResistanceSlider.Name = "ResistanceSlider";
            this.ResistanceSlider.Size = new System.Drawing.Size(237, 45);
            this.ResistanceSlider.TabIndex = 11;
            this.ResistanceSlider.Value = 1;
            this.ResistanceSlider.ValueChanged += new System.EventHandler(this.ResistanceSlider_ValueChanged);
            // 
            // VoltageSlider
            // 
            this.VoltageSlider.Location = new System.Drawing.Point(3, 60);
            this.VoltageSlider.Maximum = 100;
            this.VoltageSlider.Minimum = 1;
            this.VoltageSlider.Name = "VoltageSlider";
            this.VoltageSlider.Size = new System.Drawing.Size(237, 45);
            this.VoltageSlider.TabIndex = 10;
            this.VoltageSlider.Value = 1;
            this.VoltageSlider.ValueChanged += new System.EventHandler(this.VoltageSlider_ValueChanged);
            // 
            // OhmsLaw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1213, 514);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.OhmsChart);
            this.Name = "OhmsLaw";
            this.Load += new System.EventHandler(this.OhmsLaw_Load);
            this.Controls.SetChildIndex(this.OhmsChart, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.OhmsChart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResistanceSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VoltageSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart OhmsChart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ClearGraph;
        private System.Windows.Forms.Button GraphPlot;
        private System.Windows.Forms.Label CurrentLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ResistanceLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label VoltageLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar ResistanceSlider;
        private System.Windows.Forms.TrackBar VoltageSlider;
        private System.Windows.Forms.Button BackButton;
    }
}

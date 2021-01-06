using System.Drawing;

namespace Trending_Visualisation
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDiagramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSourceCSVFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTrendingVisualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.FileNameToolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.FileStatusToolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.LoadTImer = new System.Windows.Forms.Timer(this.components);
            this.buttonGenerateChart = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1254, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCSVFileToolStripMenuItem,
            this.saveDiagramToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openCSVFileToolStripMenuItem
            // 
            this.openCSVFileToolStripMenuItem.Name = "openCSVFileToolStripMenuItem";
            this.openCSVFileToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.openCSVFileToolStripMenuItem.Text = "Open CSV file...";
            this.openCSVFileToolStripMenuItem.Click += new System.EventHandler(this.openCSVFileToolStripMenuItem_Click);
            // 
            // saveDiagramToolStripMenuItem
            // 
            this.saveDiagramToolStripMenuItem.Name = "saveDiagramToolStripMenuItem";
            this.saveDiagramToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.saveDiagramToolStripMenuItem.Text = "Save Diagram to PNG...";
            this.saveDiagramToolStripMenuItem.Click += new System.EventHandler(this.saveDiagramToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutSourceCSVFilesToolStripMenuItem,
            this.aboutTrendingVisualToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutSourceCSVFilesToolStripMenuItem
            // 
            this.aboutSourceCSVFilesToolStripMenuItem.Name = "aboutSourceCSVFilesToolStripMenuItem";
            this.aboutSourceCSVFilesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aboutSourceCSVFilesToolStripMenuItem.Text = "View Help";
            this.aboutSourceCSVFilesToolStripMenuItem.Click += new System.EventHandler(this.aboutSourceCSVFilesToolStripMenuItem_Click);
            // 
            // aboutTrendingVisualToolStripMenuItem
            // 
            this.aboutTrendingVisualToolStripMenuItem.Name = "aboutTrendingVisualToolStripMenuItem";
            this.aboutTrendingVisualToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aboutTrendingVisualToolStripMenuItem.Text = "About Trending Visual...";
            this.aboutTrendingVisualToolStripMenuItem.Click += new System.EventHandler(this.aboutTrendingVisualToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(483, 477);
            this.dataGridView1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.FileNameToolStrip,
            this.FileStatusToolStrip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 567);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1254, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel1.Text = "File:";
            // 
            // FileNameToolStrip
            // 
            this.FileNameToolStrip.Name = "FileNameToolStrip";
            this.FileNameToolStrip.Size = new System.Drawing.Size(0, 17);
            // 
            // FileStatusToolStrip
            // 
            this.FileStatusToolStrip.Name = "FileStatusToolStrip";
            this.FileStatusToolStrip.Size = new System.Drawing.Size(0, 17);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(517, 28);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(725, 477);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // LoadTImer
            // 
            this.LoadTImer.Enabled = true;
            this.LoadTImer.Interval = 1000;
            this.LoadTImer.Tick += new System.EventHandler(this.LoadTImer_Tick);
            // 
            // buttonGenerateChart
            // 
            this.buttonGenerateChart.Location = new System.Drawing.Point(15, 513);
            this.buttonGenerateChart.Name = "buttonGenerateChart";
            this.buttonGenerateChart.Size = new System.Drawing.Size(98, 23);
            this.buttonGenerateChart.TabIndex = 5;
            this.buttonGenerateChart.Text = "Generate Chart";
            this.buttonGenerateChart.UseVisualStyleBackColor = true;
            this.buttonGenerateChart.Click += new System.EventHandler(this.buttonGenerateChart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 589);
            this.Controls.Add(this.buttonGenerateChart);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Trending Visualisation";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCSVFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDiagramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutTrendingVisualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSourceCSVFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel FileNameToolStrip;
        private System.Windows.Forms.ToolStripStatusLabel FileStatusToolStrip;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Timer LoadTImer;
        private System.Windows.Forms.Button buttonGenerateChart;
    }
}


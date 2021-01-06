using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Trending_Visualisation.Entities;

namespace Trending_Visualisation
{
    public partial class Form1 : Form
    {
        DataTable CSVTable = new DataTable();
        Settings Settings = new Settings();
        public Form1()
        {
            InitializeComponent();
			this.Icon = new Icon("Resources/Form.ico");
            chart1.Series.Clear();
        }

        public List<string> GetdtColumns()
        {
            List<string> ColumnList = new List<string>();
            foreach (DataColumn column in CSVTable.Columns)
            {
                string ColumnName = column.ColumnName.ToString();
                if (! ColumnName.Contains("point"))
                {
                    ColumnList.Add(ColumnName);

                }
            }
            return ColumnList;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openCSVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // textBox1.Text = openFileDialog1.FileName;
                FileNameToolStrip.Text = openFileDialog1.FileName;
                FileStatusToolStrip.Text = "LOADING";
            }
        }

        private void saveDiagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                chart1.SaveImage(saveFileDialog1.FileName, ImageFormat.Png);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm SettingsDialog = new SettingsForm(GetdtColumns(), CSVTable.Rows.Count, Settings);
            SettingsDialog.ShowDialog();
        }

        private void aboutTrendingVisualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm AboutDialog = new AboutForm();
            AboutDialog.ShowDialog();

        }

        private void aboutSourceCSVFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm HelpDialog = new HelpForm();
            HelpDialog.ShowDialog();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private DataTable GetDataToGridView(string csvpath)
        {
            var dTable = new DataTable();
            decimal index = 0;
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var lineList = new List<string>();
                    if (line.Contains(';')) {
                        lineList = line.Split(';').ToList();
                    }
                    else
                    {
                        lineList = line.Split(',').ToList();
                    }
                    if (index == 0)
                    {
                        lineList.Insert(0, "Item");
                        foreach (var key in lineList)
                        {
                            dTable.Columns.Add(key);
                        }
                    }
                    else
                    {
                        lineList.Insert(0, index.ToString());
                        dTable.Rows.Add(lineList.ToArray());
                    }
                    index++;
                }
            }
            return dTable;
        }

            private void LoadTImer_Tick(object sender, EventArgs e)
        {
            if (FileNameToolStrip.Text != "" && FileStatusToolStrip.Text == "LOADING") 
            {
                FileStatusToolStrip.Text = "PARSING";
                CSVTable = GetDataToGridView(FileNameToolStrip.Text);
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = CSVTable;
                FileStatusToolStrip.Text = "READY";
                dataGridView1.Refresh();
                chart1.Series.Clear();
            }
        }

        private void buttonGenerateChart_Click(object sender, EventArgs e)
        {
            if (Settings.GetEmpty())
            {
                SettingsForm SettingsDialog = new SettingsForm(GetdtColumns(), CSVTable.Rows.Count, Settings);
                SettingsDialog.ShowDialog();
            }
            if (! Settings.GetEmpty())
            {
                GenerateMovingAverages();
                FillChart(Settings);
            }
        }

        private void GenerateMovingAverages()
        {
            
        }

        private void FillChart(Settings settings)
        {
            chart1.DataSource = CSVTable;
            chart1.Series.Clear();
            var series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = settings.GetXColumn();
            var columns = settings.GetColumns();
            series.YValueMembers = columns["Base"].ColumName;
            series.BorderWidth = 2;
            series.Color = columns["Base"].Color;
            series.Name = settings.GetBaseLegend();
            chart1.Series.Add(series);
            columns.Remove("Base");

            chart1.ChartAreas[0].AxisX.Title = settings.GetXTitle();
            chart1.ChartAreas[0].AxisY.Title = columns["Base"].Legend;


            var legend = chart1.Legends[0];
            // legend.Enabled = false;

            var chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }
    }
}

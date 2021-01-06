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
                var DrawTable = GenerateMovingAverages();
                FillChart(Settings, DrawTable);
            }
        }

        private DataTable GenerateMovingAverages()
        {
            var MergedTable = CSVTable;
            var columns = Settings.GetColumns();
            if (columns.Count > 1)
            {
                var originlist = new List<int>();
                var col = columns["Base"].ColumName;
                DataView dv = new DataView(CSVTable);
                DataTable dt = dv.ToTable(true, col);
                foreach (DataRow row in dt.Rows)
                {
                    var cell = Int32.Parse(row.ItemArray[0].ToString());
                    originlist.Add(cell);
                }
                
                foreach (var item in columns)
                {
                    if (item.Key != "Base")
                    {
                        var resultlist = CalculateMovingAverage(Int32.Parse(item.Key), originlist);
                        var newcol = item.Value.Legend;
                        MergedTable.Columns.Add(newcol);
                        int i = 0;
                        foreach (DataRow row in MergedTable.Rows)
                        {
                            var rowArray = row.ItemArray;
                            rowArray[rowArray.Length - 1] = resultlist[i].ToString();
                            i++;
                        }
                    }

                }
            }
            return MergedTable;
        }

        private List<int> CalculateMovingAverage(int point, List<int> originlist)
        {
            var resultlist = new List<int>();
            var length = originlist.Count;
            for (int i=1;i<=length;i++)
            {
                if (i <= point / 2)
                {
                    resultlist.Add(0);
                }
                if (i > length - point / 2)
                {
                    resultlist.Add(0);
                }
                if (i > point / 2 && i <= length - point / 2)
                {
                    var range = new List<int>();
                    var m = point % 2;
                    if (m == 0)
                    {
                        range = originlist.GetRange(i - point / 2 - 1, point + 1);
                        range[0] = range[0] / 2;
                        range[point] = range[point] / 2;
                    } else
                    {
                        range = originlist.GetRange(i - point / 2 - 1, point);
                    
                    }
                    resultlist.Add(range.Sum() / point);
                }

            }
            return resultlist;
        }

        private void FillChart(Settings settings, DataTable filltable)
        {
            chart1.DataSource = filltable;
            chart1.Series.Clear();
            var series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = settings.GetXColumn();
            Dictionary<string, ColumnData> columns = settings.GetColumns();
            series.YValueMembers = columns["Base"].ColumName;
            series.BorderWidth = 2;
            series.Color = columns["Base"].Color;
            series.Name = settings.GetBaseLegend();
            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Title = settings.GetXTitle();
            chart1.ChartAreas[0].AxisY.Title = columns["Base"].Legend;
            foreach (var item in columns)
            {
                if (item.Key != "Base")
                {
                    var newseries = new Series();
                    newseries.ChartType = SeriesChartType.Line;
                    newseries.XValueMember = settings.GetXColumn();
                    newseries.YValueMembers = item.Value.ColumName;
                    newseries.BorderWidth = 2;
                    newseries.Color = item.Value.Color;
                    newseries.Name = item.Value.Legend;
                    chart1.Series.Add(newseries);
                }
            }

            var chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
            chartArea.BorderColor = Color.Black;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trending_Visualisation.Entities;

namespace Trending_Visualisation
{
    public partial class SettingsForm : Form

    {
        List<string> ColumnList = new List<string>();
        int RowNum = 0;
        Settings Settings;
        public SettingsForm(List<string> columnlist, int rownum, Settings settings)
        {
            InitializeComponent();
            ColumnList = columnlist;
            RowNum = rownum;
            Settings = settings;
            FillAxisLists();
            FillExistingSettings();
        }

        private void FillExistingSettings()
        {
            if (! Settings.GetEmpty())
            {
                XcomboBox.SelectedIndex = XcomboBox.FindString(Settings.GetXColumn(), 0);
                Xtitle.Text = Settings.GetXTitle();
                var columns = Settings.GetColumns();
                YcomboBox.SelectedIndex = YcomboBox.FindString(columns["Base"].ColumName, 0);
                Ytitle.Text = columns["Base"].Legend;
                BaseColorbutton.BackColor = columns["Base"].Color;
                int i = 0;
                foreach (var item in columns)
                {
                    if (item.Key != "Base")
                    {
                        var Point = (TextBox)this.Controls.Find("PointBox" + i.ToString(), true)[0];
                        var Legend = (TextBox)this.Controls.Find("LegendBox" + i.ToString(), true)[0];
                        var ColorButton = (Button)this.Controls.Find("Colorbutton" + i.ToString(), true)[0];
                        var checkBoxvar = (CheckBox)this.Controls.Find("checkBox" + i.ToString(), true)[0];
                        Point.Text = item.Key;
                        Legend.Text = item.Value.Legend;
                        ColorButton.BackColor = item.Value.Color;
                        checkBoxvar.Checked = true;
                    }
                    i++;
                }
            }
        }

        private void FillAxisLists()
        {
            XcomboBox.Items.AddRange(ColumnList.ToArray());
            YcomboBox.Items.AddRange(ColumnList.ToArray());
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            if (ColumnList.Count > 0)
            {
                var ColumnList = new Dictionary<string, ColumnData> { };
                var IsGood = true;
                if (CheckValues())
                {
                    var ytitle = Ytitle.Text != "" ? Ytitle.Text : YcomboBox.SelectedItem.ToString();
                    var xtitle = Xtitle.Text != "" ? Xtitle.Text : XcomboBox.SelectedItem.ToString();
                    var baselegend = BaseLegend.Text != "" ? BaseLegend.Text : xtitle;
                    ColumnList["Base"] = new ColumnData(YcomboBox.SelectedItem.ToString(), ytitle, BaseColorbutton.BackColor);
                    Settings.SetBaseLegend(baselegend);
                    Settings.SetXColumn(XcomboBox.SelectedItem.ToString());
                    Settings.SetXTitle(xtitle);
                } else
                {
                    IsGood = false;
                }
                for (int i = 1; i < 6; i++)
                {
                    var checkBoxvar = (CheckBox)this.Controls.Find("checkBox"+ i.ToString(), true)[0];
                    if (checkBoxvar.Checked)
                    {
                        var Point = (TextBox)this.Controls.Find("PointBox" + i.ToString(), true)[0];
                        var Legend = (TextBox)this.Controls.Find("LegendBox" + i.ToString(), true)[0];
                        var ColorButton = (Button)this.Controls.Find("Colorbutton" + i.ToString(), true)[0];
                        if (CheckPoint(Point.Text, RowNum))
                        {
                            var legend = Legend.Text != "" ? Legend.Text : Point.Text + "point";
                            ColumnList[Point.Text] = new ColumnData(Point.Text + "point", legend, ColorButton.BackColor);
                        } else
                        {
                            MessageBox.Show($"Please choose a number between 3 and {RowNum/2} instead of '{Point.Text}'", "Error", MessageBoxButtons.OK);
                            IsGood = false;
                        }

                    }
                }
                if (IsGood)
                {
                    Settings.SetColumns(ColumnList);
                    Settings.SetEmpty(false);
                    this.Close();
                }   
            }
        }

        public bool CheckPoint(string text, int rownum)
        {
            if (text.All(char.IsDigit))
            {
                var num = Int32.Parse(text);
                if (num > 2 && (num * 2) < rownum)
                {
                    return true;
                } else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }

        private bool CheckValues()
        {
            var Errors = true;
            if (XcomboBox.SelectedItem == null || YcomboBox.SelectedItem == null)
            {
                MessageBox.Show("Please choose Columns to X and Y Axis", "Error", MessageBoxButtons.OK);
                return false;
            }
            if (XcomboBox.SelectedItem.ToString() == YcomboBox.SelectedItem.ToString())
            {
                MessageBox.Show("Please choose different Columns to X and Y Axis", "Error", MessageBoxButtons.OK);
                Errors = false;
            }
            return Errors;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Colorbutton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorPicker = new ColorDialog();

            colorPicker.Color = button.BackColor;
            if (colorPicker.ShowDialog() != DialogResult.OK)
                return;
            button.BackColor = colorPicker.Color;
        }
    }
}

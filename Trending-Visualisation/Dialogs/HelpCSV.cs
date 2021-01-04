using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trending_Visualisation
{
    public partial class HelpCSV : Form
    {
        public HelpCSV()
        {
            InitializeComponent();
            richTextBox1.LoadFile("Resources/HelpCSV.rtf");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

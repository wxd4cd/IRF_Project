using System;
using System.Drawing;
using System.Windows.Forms;

namespace Trending_Visualisation
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            this.Icon = new Icon("Resources/Form.ico");
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

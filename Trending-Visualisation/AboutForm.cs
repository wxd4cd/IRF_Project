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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap("Resources/Logo_small.png");
            richTextBox1.LoadFile("Resources/About.rtf");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SOS_Organization_Manager
{
    public partial class CreditForm : Form
    {
        public CreditForm()
        {
            InitializeComponent();

            textBox1.ReadOnly = true;
            pictureBox2.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.uoguide.com/Message_in_a_Bottle") { UseShellExecute = true });
        }
    }
}

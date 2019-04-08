using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textClub_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "https://fb.com/uef.oic");
        }

        private void textName_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "https://fb.com/ithgnm");
        }
    }
}

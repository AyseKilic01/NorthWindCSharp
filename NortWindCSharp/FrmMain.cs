
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NortWindCSharp.NortWindBasic;

namespace NortWindCSharp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Product frm = new Product();
            frm.Show();
            this.Hide();
        }
    }
}

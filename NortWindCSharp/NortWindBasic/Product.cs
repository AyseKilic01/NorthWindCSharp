using NortWindCSharp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NortWindCSharp.NortWindBasic
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            using(NWContext context = new NWContext())
            {
                dgwProducts.DataSource = context.products.ToList();
            }
        }
    }
}

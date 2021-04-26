using NortWindCSharp.DAL;
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
        ProductDal dal = new ProductDal();
        public Product()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            dgwProducts.DataSource = dal.GetAll();
            dgwProducts.Columns[0].Visible = false;
            dgwProducts.Columns[1].HeaderText = "Name";
            dgwProducts.Columns[2].HeaderText = "Unit Price";
            dgwProducts.Columns[3].HeaderText = "Stock Amount";
        }
        void SearchData(string search)
        {
            dgwProducts.DataSource = dal.GetAll().Where(x=>x.Name.ToLower().Contains(search.ToLower())).ToList();
        }
        private void Product_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        bool AddControl()
        {
            if (txtName.Text.Trim() == "" || txtUnit.Text.Trim() == "" || txtStock.Text.Trim() == "") return false;
            return true;
        }
        bool UpdateControl()
        {
            if (txtUName.Text.Trim() == "" || txtUUnit.Text.Trim() == "" || txtUStock.Text.Trim() == "") return false;
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddControl())
            {
                dal.Add(new Products
                {
                    Name = txtName.Text,
                    UnitPrice = decimal.Parse(txtUnit.Text),
                    StockAmount = int.Parse(txtStock.Text)
                });
                LoadData();
                MessageBox.Show("Added");
            }
            else
            {
                MessageBox.Show("Alanları giriniz !");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUName.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            txtUUnit.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            txtUStock.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateControl())
            {
                dal.Update(new Products
                {
                    ID = int.Parse(dgwProducts.CurrentRow.Cells[0].Value.ToString()),
                    Name = txtUName.Text,
                    UnitPrice = decimal.Parse(txtUUnit.Text),
                    StockAmount = int.Parse(txtUStock.Text)
                });
                LoadData();
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Satır Seçiniz !");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgwProducts.SelectedRows.Count > 0)
            {
                dal.Delete(new Products
                {
                    ID = int.Parse(dgwProducts.CurrentRow.Cells[0].Value.ToString())

                });
                LoadData();
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Satır Seçiniz");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchData(txtSearch.Text);
        }

        private void btnGetBy_Click(object sender, EventArgs e)
        {
            dal.GetByID(1);
        }
    }
}

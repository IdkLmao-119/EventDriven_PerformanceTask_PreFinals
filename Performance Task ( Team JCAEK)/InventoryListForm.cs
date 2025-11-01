using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Performance_Task___Team_JCAEK_
{
    public partial class InventoryListForm : Form
    {
        public InventoryListForm()
        {
            InitializeComponent();
        }

        private void InventoryListForm_Load(object sender, EventArgs e)
        {
            // Automatically load products when form opens
            LoadProductsIntoGrid();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// NEW METHOD: Loads products from file into the DataGridView
        /// </summary>
        private void LoadProductsIntoGrid()
        {
            try
            {
                // Create ProductManager to access the data file
                ProductManager productManager = new ProductManager();

                // Load products into the DataGridView
                productManager.ShowAllProductsInGrid(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// NEW METHOD: Refresh button click to reload data
        /// </summary>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadProductsIntoGrid();
            MessageBox.Show("Inventory refreshed!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

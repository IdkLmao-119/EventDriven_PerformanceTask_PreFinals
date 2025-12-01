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
                // Ensure AutoGenerateColumns is enabled
                dataGridView1.AutoGenerateColumns = true;

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
    }
}
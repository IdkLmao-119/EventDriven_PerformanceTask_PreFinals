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
    public partial class EditItemForm : Form
    {
        public EditItemForm()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while closing the form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(txtItemName.Text))
                {
                    MessageBox.Show("Please enter an item name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Attempt to save the edited item
                string error;
                if (!TrySaveItem(out error))
                {
                    MessageBox.Show("Failed to save item: " + error, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Item saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// CHANGED METHOD: Now actually edits products using ProductManager
        /// </summary>
        private bool TrySaveItem(out string errorMessage)
        {
            errorMessage = null;
            try
            {
                // Get the product index (line number in file)
                if (!int.TryParse(txtProductIndex.Text, out int productIndex))
                {
                    errorMessage = "Invalid product index. Please enter a valid number.";
                    return false;
                }

                // Get the new product name
                if (string.IsNullOrWhiteSpace(txtItemName.Text))
                {
                    errorMessage = "Product name is required.";
                    return false;
                }
                string productName = txtItemName.Text;

                // Get the new product price
                if (!double.TryParse(txtPrice.Text, out double productPrice))
                {
                    errorMessage = "Invalid price format. Please enter a valid number.";
                    return false;
                }

                // Use ProductManager to edit the product in the file
                ProductManager productManager = new ProductManager();
                productManager.EditProduct(productIndex, productName, productPrice);

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
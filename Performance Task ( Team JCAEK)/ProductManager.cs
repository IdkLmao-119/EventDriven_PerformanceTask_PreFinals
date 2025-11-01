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
                // Prevent the app from crashing on an unexpected UI error
                MessageBox.Show("An error occurred while closing the form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Basic example validation: if a TextBox named "txtItemName" exists, require a value.
                if (this.Controls["txtItemName"] is TextBox nameTextBox)
                {
                    if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                    {
                        MessageBox.Show("Please enter an item name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Attempt to persist/save the edited item.
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
                // Top-level exception handler for the submit action
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// CHANGED METHOD: Now implements actual product editing logic using ProductManager
        /// Purpose: To retrieve the product index and update product data using the FileManager system
        /// </summary>
        private bool TrySaveItem(out string errorMessage)
        {
            errorMessage = null;
            try
            {
                // CHANGED: Product index retrieval instead of ID
                // Purpose: Get the line index from the form to identify which product to edit in the text file
                if (this.Controls["txtProductIndex"] is TextBox indexTextBox)
                {
                    // Parse product index from text input with error handling
                    if (!int.TryParse(indexTextBox.Text, out int productIndex))
                    {
                        errorMessage = "Invalid product index. Please enter a valid number.";
                        return false;
                    }

                    // CHANGED: Product name retrieval for editing
                    // Purpose: Get the new product name from the form
                    if (!(this.Controls["txtItemName"] is TextBox nameTextBox) || string.IsNullOrWhiteSpace(nameTextBox.Text))
                    {
                        errorMessage = "Product name is required.";
                        return false;
                    }
                    string productName = nameTextBox.Text;

                    // CHANGED: Product price retrieval with validation
                    // Purpose: Get the new product price from the form
                    if (!(this.Controls["txtPrice"] is TextBox priceTextBox) || !double.TryParse(priceTextBox.Text, out double productPrice))
                    {
                        errorMessage = "Invalid price format. Please enter a valid number.";
                        return false;
                    }

                    // CHANGED: Create ProductManager instance and call EditProduct method
                    // Purpose: Use the ProductManager to update the product in the text file
                    ProductManager productManager = new ProductManager();

                    // Note: Based on ProductManager.cs, the EditProduct method only takes index, name, and price
                    // Other fields (type, stock, description) are not updated in the current implementation
                    productManager.EditProduct(productIndex, productName, productPrice);

                    // CHANGED: Success - product has been updated in the file
                    return true;
                }
                else
                {
                    errorMessage = "Product index field not found. Cannot identify which product to edit.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
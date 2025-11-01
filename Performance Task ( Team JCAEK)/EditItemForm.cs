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
        /// CHANGED METHOD: Now implements actual product editing logic
        /// Purpose: To retrieve an existing product, update its properties from form controls,
        /// and persist the changes to the data store
        /// </summary>
        private bool TrySaveItem(out string errorMessage)
        {
            errorMessage = null;
            try
            {
                // CHANGED: Product ID retrieval and validation
                // Purpose: Get the product ID from the form to identify which product to edit
                if (this.Controls["txtProductID"] is TextBox idTextBox)
                {
                    // Parse product ID from text input with error handling
                    if (!int.TryParse(idTextBox.Text, out int productId))
                    {
                        errorMessage = "Invalid product ID. Please enter a valid number.";
                        return false;
                    }

                    // CHANGED: Product retrieval logic
                    // Purpose: Fetch the existing product from the data store using the ID
                    var product = ProductManager.GetProductById(productId);
                    if (product == null)
                    {
                        errorMessage = "Product not found. Please check the product ID.";
                        return false;
                    }

                    // CHANGED: Property update section
                    // Purpose: Update product properties with new values from form controls

                    // Update product name from txtItemName control
                    if (this.Controls["txtItemName"] is TextBox nameTextBox)
                        product.Name = nameTextBox.Text;

                    // Update product description from txtDescription control
                    if (this.Controls["txtDescription"] is TextBox descTextBox)
                        product.Description = descTextBox.Text;

                    // Update product price with validation for decimal format
                    if (this.Controls["txtPrice"] is TextBox priceTextBox)
                    {
                        if (decimal.TryParse(priceTextBox.Text, out decimal price))
                            product.Price = price;
                        else
                        {
                            errorMessage = "Invalid price format. Please enter a valid decimal number.";
                            return false;
                        }
                    }

                    // Update stock quantity with validation for integer format
                    if (this.Controls["txtStock"] is TextBox stockTextBox)
                    {
                        if (int.TryParse(stockTextBox.Text, out int stock))
                            product.StockQuantity = stock;
                        else
                        {
                            errorMessage = "Invalid stock quantity. Please enter a valid whole number.";
                            return false;
                        }
                    }

                    // CHANGED: Data persistence call
                    // Purpose: Save the updated product back to the data store
                    ProductManager.UpdateProduct(product);
                }
                else
                {
                    errorMessage = "Product ID field not found. Cannot identify which product to edit.";
                    return false;
                }

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
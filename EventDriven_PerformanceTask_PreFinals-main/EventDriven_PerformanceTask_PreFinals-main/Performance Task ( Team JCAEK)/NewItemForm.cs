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
    public partial class NewItemForm: Form
    {
        ProductManager pm = new ProductManager();
        public NewItemForm()
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
                // Example validation: require a value in a TextBox named "txtItemName" if present
                if (this.Controls["txtItemName"] is TextBox nameTextBox)
                {
                    if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                    {
                        MessageBox.Show("Please enter an item name.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Attempt to save the new item
                string error;
                if (!TrySaveItem(out error))
                {
                    MessageBox.Show("Failed to save item: " + error, "Save Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pm.AddProduct(NameTxtBox.Text, TypeTxtBox.Text, Convert.ToInt32(StockTxtBox.Text), Convert.ToDouble(PriceTxtBox.Text), DescriptionTxtBox.Text);
                MessageBox.Show("Item created successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Added missing TrySaveItem method
        private bool TrySaveItem(out string error)
        {
            // TODO: Implement actual save logic here
            error = string.Empty;
            // Simulate success for now
            return true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void StockTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TypeTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PriceTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

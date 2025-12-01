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
    public partial class EditItemForm: Form
    {
        ProductManager pm = new ProductManager();
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
                // Basic validation
                if (this.Controls["txtItemName"] is TextBox nameTextBox)
                {
                    if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                    {
                        MessageBox.Show("Please enter an item name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                int internalCode = Convert.ToInt32(InternalCodeTxt.Text);

                pm.EditProduct(internalCode, NameTxtBox.Text, TypeTxtBox.Text,
                               Convert.ToInt32(StockTxtBox.Text),
                               Convert.ToDouble(PriceTxtBox.Text),
                               DescriptionTxtBox.Text);

                MessageBox.Show("Item saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Internal code must be a valid number.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

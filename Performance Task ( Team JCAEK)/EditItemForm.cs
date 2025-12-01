using System;
using System.Windows.Forms;

namespace Performance_Task___Team_JCAEK_
{
    public partial class EditItemForm: Form
    {
        DatabaseManager dm = new DatabaseManager();
        // ProductManager pm = new ProductManager();
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
                // Erick's note: Weh di nga lolololololololol
                MessageBox.Show("An error occurred while closing the form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Basic validation
                // Erick's note: WAHAHAHAHAHA nuto
                if (this.Controls["txtItemName"] is TextBox nameTextBox)
                {
                    if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                    {
                        MessageBox.Show("Please enter an item name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                int internalCode = Convert.ToInt32(InternalCodeTxt.Text);
                dm.UpdateItem(internalCode, NameTxtBox.Text, TypeTxtBox.Text, Convert.ToInt32(StockTxtBox.Text), Convert.ToDouble(PriceTxtBox.Text), DescriptionTxtBox.Text);

                // Imma commit this so wag tatanggalin yung comments lmao
                /*
                pm.EditProduct(internalCode, NameTxtBox.Text, TypeTxtBox.Text,
                               Convert.ToInt32(StockTxtBox.Text),
                               Convert.ToDouble(PriceTxtBox.Text),
                               DescriptionTxtBox.Text);
                */
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

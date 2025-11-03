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
        /// Simple save helper that returns false with an error message on failure.
        /// Replace implementation with actual persistence logic as needed.
        /// </summary>
        private bool TrySaveItem(out string errorMessage)
        {
            errorMessage = null;
            try
            {
                // TODO: replace with actual save logic (file, DB, etc.)
                // For now simulate success.
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

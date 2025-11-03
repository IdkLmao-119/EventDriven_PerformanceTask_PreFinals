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
    public partial class DeleteItemForm: Form
    {
        ProductManager pm = new ProductManager();
        public DeleteItemForm()
        {
            InitializeComponent();
        }
        // Goes back to the Main form.
        private void MenuButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            //Generic exception error if something unexpected happened.
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
                // Simple null checks and validation for the input textbox.
                if (this.txtInternalCode == null)
                {
                    MessageBox.Show("Input control not found.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Checks if there is an input in the Internal Code text box.
                var idText = this.txtInternalCode.Text;
                if (string.IsNullOrWhiteSpace(idText))
                {
                    MessageBox.Show("Please enter an internal code to delete.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Shows an action confirmation window to confirm deletion.
                var confirm = MessageBox.Show($"Delete item with internal code '{idText}'?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                // Deletes a product and shows a task completion window.
                pm.DeleteProduct(Convert.ToInt32(txtInternalCode.Text));
                MessageBox.Show("Item deleted (placeholder).", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            //Generic Exception error if something unexpected happened.
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

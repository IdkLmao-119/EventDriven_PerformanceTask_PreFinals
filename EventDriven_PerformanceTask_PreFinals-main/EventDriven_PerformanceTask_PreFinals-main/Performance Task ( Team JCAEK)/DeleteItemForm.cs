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
            txtInternalCode.Text = "1000000";
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
                int internalCode = Convert.ToInt32(txtInternalCode.Text);
                pm.DeleteProduct(internalCode);

                MessageBox.Show("Product deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid numeric internal code.", "Invalid Input",
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

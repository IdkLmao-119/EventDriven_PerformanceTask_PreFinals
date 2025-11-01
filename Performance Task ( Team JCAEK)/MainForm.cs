using Performance_Task___Team_JCAEK_.Properties;
using System;
using System.Windows.Forms;

namespace Performance_Task___Team_JCAEK_
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // New Item Button --> NewItemForm

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewItemForm newItemForm = new NewItemForm();
            // When settings form closes, show the main form again
            newItemForm.FormClosed += (s, args) => this.Show();
            newItemForm.ShowDialog();
        }

        // Delete Item Button --> DeleteItemForm

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteItemForm deleteItemForm = new DeleteItemForm();
            deleteItemForm.FormClosed += (s, args) => this.Show();
            deleteItemForm.ShowDialog();
        }

        // Edit Item Button --> EditItemForm
        private void btnEditItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditItemForm editItemForm = new EditItemForm();
            editItemForm.FormClosed += (s, args) => this.Show();
            editItemForm.ShowDialog();
        }

        // View Inventory List Button --> InventoryListForm

        private void btnViewList_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryListForm inventoryListForm = new InventoryListForm();
            inventoryListForm.FormClosed += (s, args) => this.Show();
            inventoryListForm.ShowDialog();
        }
    }
}

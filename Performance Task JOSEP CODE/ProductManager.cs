using System;
using System.Data;
using System.Windows.Forms;

namespace Performance_Task___Team_JCAEK_
{
    public class ProductManager
    {
        private FileManager fileManager;

        public ProductManager()
        {
            // find it in Bin\Debug in the folder
            fileManager = new FileManager(Convert.ToString("InventoryData.txt"));
        }
        // add product data
        public void AddProduct(string name, string type, int stock, double price, string description)
        {
            string data = $"{name},{price},{type},{stock},{price},{description}";
            fileManager.AddLine(data);
        }
        // edit product data
        public void EditProduct(int index, string name, double price)
        {
            string newData = $"{name},{price}";
            fileManager.EditLine(index, newData);
        }
        // delete data
        public void DeleteProduct(int index)
        {
            fileManager.DeleteLine(index);
        }
        public void ShowAllProductsInGrid(DataGridView gridView)
        {
            var products = fileManager.LoadAll();
            DataTable table = new DataTable();

            // Define columns (depends on how you structure your data)
            table.Columns.Add("Name");
            table.Columns.Add("Price");
            table.Columns.Add("Quantity");

            // Fill rows
            foreach (var product in products)
            {
                if (string.IsNullOrWhiteSpace(product))
                    continue;

                var parts = product.Split(',');
                if (parts.Length >= 3)
                    table.Rows.Add(parts[0], parts[1], parts[2]);
            }

            // Display in DataGridView
            gridView.DataSource = table;
        }
        // ai this to display in DataGrid
        public void ShowAllProducts()
        {
            var products = fileManager.LoadAll();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Performance_Task___Team_JCAEK_
{
    public class ProductManager
    {
        private FileManager fileManager;

        public ProductManager()
        {
            // find it in Bin\Debug in the folder
            fileManager = new FileManager("InventoryData.txt");
        }

        public void AddProduct(string name, string type, int stock, double price, string description)
        {
            // Get the current count of lines in the file to determine the next internal code
            int index = fileManager.GetLineCount();
            string internalCode = (index).ToString();

            // Add the new product with its internal code
            string data = $"{internalCode},{name},{type},{stock},{price},{description}";
            fileManager.AddLine(data);
        }

        public void EditProduct(int internalCode, string name, string type, int stock, double price, string description)
        {
            var lines = fileManager.LoadAll().ToList();
            bool found = false;

            for (int i = 0; i < lines.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                string[] parts = lines[i].Split(',');

                if (parts.Length == 0)
                    continue;

                // Compare first column (internal code)
                if (parts[0] == internalCode.ToString())
                {
                    // Found the product; update it
                    string newData = $"{parts[0]},{name},{type},{stock},{price},{description}";
                    fileManager.EditLine(i, newData);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                throw new Exception($"No product with internal code {internalCode} exists.");
            }
        }


        // Delete data
        public void DeleteProduct(int internalCode)
        {
            var lines = fileManager.LoadAll().ToList();
            bool found = false;

            for (int i = 0; i < lines.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                string[] parts = lines[i].Split(',');

                if (parts.Length == 0)
                    continue;

                // Check if first column matches the internal code
                if (parts[0] == internalCode.ToString())
                {
                    fileManager.DeleteLine(i);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                throw new Exception($"No product with internal code {internalCode} exists.");
            }
        }

        // Search products by name
        public List<string> SearchProducts(string searchTerm)
        {
            return fileManager.FindLines(searchTerm);
        }

        // Get all products as list
        public List<string> GetAllProducts()
        {
            return fileManager.LoadAll();
        }

        public void ShowAllProductsInGrid(DataGridView gridView)
        {
            try
            {
                var products = fileManager.LoadAll();

                // Debug: Check what's loaded from file
                Console.WriteLine($"Products loaded: {products?.Count ?? 0}");
                if (products != null)
                {
                    foreach (var product in products)
                    {
                        Console.WriteLine($"Product: {product}");
                    }
                }

                DataTable table = new DataTable();

                // Define columns based on your AddProduct method parameters'
                table.Columns.Add("Internal Code");
                table.Columns.Add("Name");
                table.Columns.Add("Type");
                table.Columns.Add("Stock", typeof(int));
                table.Columns.Add("Price", typeof(double));
                table.Columns.Add("Description");

                int rowCount = 0;
                foreach (var product in products)
                {
                    if (string.IsNullOrWhiteSpace(product))
                        continue;

                    var parts = product.Split(',');
                    // Updated to match 5 fields from AddProduct method
                    if (parts.Length >= 5)
                    {
                        // Parse numeric values properly
                        int stock = 0;
                        double price = 0;

                        int.TryParse(parts[2], out stock);
                        double.TryParse(parts[3], out price);

                        table.Rows.Add(parts[0], parts[1], stock, price, parts[4]);
                        rowCount++;
                    }
                    else if (parts.Length >= 3)
                    {
                        // Fallback for older data format
                        int stock = 0;
                        double price = 0;

                        int.TryParse(parts[2], out stock);
                        if (parts.Length >= 4) double.TryParse(parts[3], out price);

                        table.Rows.Add(parts[0], parts[1], stock, price,
                                      parts.Length >= 5 ? parts[4] : "");
                        rowCount++;
                    }
                }

                // Debug: Check DataTable
                Console.WriteLine($"DataTable rows: {rowCount}");

                // Display in DataGridView
                gridView.DataSource = table;

                // Debug: Check grid after binding
                Console.WriteLine($"GridView rows after binding: {gridView.Rows.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error in ShowAllProductsInGrid: {ex.Message}");
            }
        }

        // Method to display in console
        public void ShowAllProducts()
        {
            var products = fileManager.LoadAll();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        // Helper method to get product by index
        public string GetProduct(int index)
        {
            var products = fileManager.LoadAll();
            if (index >= 0 && index < products.Count)
            {
                return products[index];
            }
            return null;
        }

        // Helper method to get product count
        public int GetProductCount()
        {
            return fileManager.LoadAll().Count;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Performance_Task___Team_JCAEK_
{
    /*
    C-AddItem()
    R-GetAllItems(), GetItemById(), FindItems()
    U-UpdateItem()
    D-DeleteItem()

    This version supports proper inventory columns: Name, Category, Price, Quantity, Description
    */
    public class DatabaseManager
    {
        private readonly string connectionString;
        private readonly string tableName;

        // Constructor - same as before but now creates proper inventory table
        public DatabaseManager(string tableName = "Inventory")
        {
            connectionString = "Server=localhost; Database=MyAppDB; Trusted_Connection=true;";
            this.tableName = tableName;
            string databaseName = GetDatabaseNameFromConnectionString();
            if (!string.IsNullOrEmpty(databaseName) && databaseName != "master")
            {
                CreateDatabaseIfNotExists(databaseName);
            }
            InitializeDatabase();
        }

        // Example Usage:
        /*
        DatabaseManager dm = new DatabaseManager("Server=localhost; Database=MyAppDB; Trusted_Connection=true;", "Inventory");
        
        // Add an item
        dm.AddItem("Laptop", "Electronics", 999.99m, 5, "Gaming laptop with RGB keyboard");
        
        // Get all items
        var allItems = dm.GetAllItems();
        */

        // Creates the inventory table with proper columns
        private void InitializeDatabase()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = $@"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='{tableName}' AND xtype='U')
                    CREATE TABLE {tableName} (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        Name NVARCHAR(100) NOT NULL,
                        Category NVARCHAR(50),
                        Price DECIMAL(10,2),
                        Quantity INT,
                        Description NVARCHAR(100),
                        CreatedDate DATETIME2 DEFAULT GETDATE(),
                        ModifiedDate DATETIME2 DEFAULT GETDATE()
                    )";

                using (var command = new SqlCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Represents an inventory item
        public class InventoryItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public string Description { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime ModifiedDate { get; set; }
        }

        // 🔹 C - CREATE: Add a new inventory item
        public void AddItem(string name, string category, decimal price, double quantity, string description = "")
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $@"
                    INSERT INTO {tableName} (Name, Category, Price, Quantity, Description) 
                    VALUES (@Name, @Category, @Price, @Quantity, @Description)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Category", category ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Description", description ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        // 🔹 R - READ: Get all inventory items
        public List<InventoryItem> GetAllItems()
        {
            var results = new List<InventoryItem>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName} ORDER BY Id";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new InventoryItem
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Category = reader["Category"]?.ToString() ?? "",
                            Price = Convert.ToDecimal(reader["Price"]),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            Description = reader["Description"]?.ToString() ?? "",
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                            ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"])
                        });
                    }
                }
            }

            return results;
        }

        // 🔹 R - READ: Get specific item by ID
        public InventoryItem GetItemById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName} WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new InventoryItem
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Category = reader["Category"]?.ToString() ?? "",
                                Price = Convert.ToDecimal(reader["Price"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                Description = reader["Description"]?.ToString() ?? "",
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"])
                            };
                        }
                    }
                }
            }
            return null; // Item not found
        }

        // 🔹 U - UPDATE: Update an existing item
        public void UpdateItem(int id, string name, string category, decimal price, double quantity, string description = "")
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $@"
                    UPDATE {tableName} 
                    SET Name = @Name, Category = @Category, Price = @Price, 
                        Quantity = @Quantity, Description = @Description, ModifiedDate = GETDATE()
                    WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Category", category ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Description", description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        throw new IndexOutOfRangeException("Invalid item ID.");
                }
            }
        }

        // 🔹 D - DELETE: Delete an item by ID
        public void DeleteItem(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"DELETE FROM {tableName} WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        throw new IndexOutOfRangeException("Invalid item ID.");
                }
            }
        }

        // 🔹 Search items by name or category
        public List<InventoryItem> FindItems(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return new List<InventoryItem>();

            var results = new List<InventoryItem>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $@"
                    SELECT * FROM {tableName} 
                    WHERE Name LIKE @Keyword OR Category LIKE @Keyword OR Description LIKE @Keyword 
                    ORDER BY Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new InventoryItem
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Category = reader["Category"]?.ToString() ?? "",
                                Price = Convert.ToDecimal(reader["Price"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                Description = reader["Description"]?.ToString() ?? "",
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"])
                            });
                        }
                    }
                }
            }
            return results;
        }

        // 🔹 Get items by category
        public List<InventoryItem> GetItemsByCategory(string category)
        {
            var results = new List<InventoryItem>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName} WHERE Category = @Category ORDER BY Name";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Category", category);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new InventoryItem
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Category = reader["Category"]?.ToString() ?? "",
                                Price = Convert.ToDecimal(reader["Price"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                Description = reader["Description"]?.ToString() ?? "",
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"])
                            });
                        }
                    }
                }
            }
            return results;
        }

        // 🔹 Count total items
        public int GetItemCount()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT COUNT(*) FROM {tableName}";

                using (var command = new SqlCommand(query, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        // 🔹 Get total inventory value (Price * Quantity)
        public decimal GetTotalInventoryValue()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT SUM(Price * Quantity) FROM {tableName}";

                using (var command = new SqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
                }
            }
        }

        // 🔹 Alternative version that matches your original column names exactly
        public void ShowAllProductsInGrid(DataGridView gridView)
        {
            try
            {
                var products = GetAllItems();

                Console.WriteLine($"Products loaded: {products?.Count ?? 0}");

                DataTable table = new DataTable();

                // Match your original column structure exactly
                table.Columns.Add("Internal Code");
                table.Columns.Add("Name");
                table.Columns.Add("Type"); // Using Category as Type
                table.Columns.Add("Stock", typeof(int));
                table.Columns.Add("Price", typeof(double));
                table.Columns.Add("Description");

                foreach (var product in products)
                {
                    // Convert decimal price to double for compatibility
                    double price = (double)product.Price;

                    table.Rows.Add(
                        product.Id.ToString("D4"), // Internal Code as formatted ID
                        product.Name,
                        product.Category, // Using Category as Type
                        product.Quantity,
                        price,
                        product.Description
                    );
                }

                gridView.DataSource = table;

                Console.WriteLine($"DataTable rows: {table.Rows.Count}");
                Console.WriteLine($"GridView rows after binding: {gridView.Rows.Count}");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error in ShowAllProductsInGrid: {ex.Message}");
            }
        }
        public void CreateDatabaseIfNotExists(string databaseName)
        {
            // Connect to master database
            string masterConnectionString = connectionString.Replace(
                GetDatabaseNameFromConnectionString(),
                "master"
            );

            using (var connection = new SqlConnection(masterConnectionString))
            {
                connection.Open();

                // Simple database creation
                string createDbQuery = $@"
            IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = '{databaseName}')
            BEGIN
                CREATE DATABASE [{databaseName}]
                PRINT 'Database {databaseName} created successfully.'
            END
            ELSE
                PRINT 'Database {databaseName} already exists.'";

                using (var command = new SqlCommand(createDbQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        private string GetDatabaseNameFromConnectionString()
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(connectionString);
                return builder.InitialCatalog;
            }
            catch
            {
                return "master";
            }
        }
    }
}
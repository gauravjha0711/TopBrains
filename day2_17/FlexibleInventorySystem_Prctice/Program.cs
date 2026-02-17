using System;
using FlexibleInventorySystem_Practice.Services;
using FlexibleInventorySystem_Practice.Models;


namespace FlexibleInventorySystem_Practice
{
    /// <summary>
    /// TODO: Implement console user interface
    /// </summary>
    class Program
    {
        private static InventoryManager _inventory = new InventoryManager();

        static void Main(string[] args)
        {
            // TODO: Display menu and handle user input
            // Options should include:
            // 1. Add Product
            // 2. Remove Product
            // 3. Update Quantity
            // 4. Find Product
            // 5. View All Products
            // 6. Generate Reports
            // 7. Check Low Stock
            // 8. Exit

            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProductMenu();
                        break;
                    case "2":
                        RemoveProductMenu();
                        break;
                    // TODO: Implement other cases
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            // TODO: Display formatted menu
                Console.WriteLine("=== Flexible Inventory System ===");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Remove Product");
                Console.WriteLine("3. Update Quantity");
                Console.WriteLine("4. Find Product");
                Console.WriteLine("5. View All Products");
                Console.WriteLine("6. Generate Reports");
                Console.WriteLine("7. Check Low Stock");
                Console.WriteLine("8. Exit");
                Console.Write("Select an option: ");
            // throw new NotImplementedException();
        }

        static void AddProductMenu()
        {
            // TODO: Implement menu to add different product types
            // Ask user for product type
            // Collect appropriate properties
            // Add to inventory
                Console.WriteLine("Select product type to add:");
                    Console.WriteLine("1. Clothing");
                    Console.WriteLine("2. Grocery");
                    Console.WriteLine("3. Electronic");
                    Console.Write("Enter choice: ");
                    string typeChoice = Console.ReadLine();
    
                    Product newProduct = null;
    
                    switch (typeChoice)
                    {
                        case "1":
                            newProduct = CreateClothingProduct();
                            break;
                        case "2":
                            newProduct = CreateGroceryProduct();
                            break;
                        case "3":
                            newProduct = CreateElectronicProduct();
                            break;
                        default:
                            Console.WriteLine("Invalid product type.");
                            return;
                    }
    
                    if (newProduct != null)
                    {
                        _inventory.AddProduct(newProduct);
                        Console.WriteLine("Product added successfully.");
                    }

            // throw new NotImplementedException();
        }

        static void RemoveProductMenu()
        {
            // TODO: Implement product removal
                Console.Write("Enter Product ID to remove: ");
                    string productId = Console.ReadLine();
    
                    if (_inventory.RemoveProduct(productId))
                    {
                        Console.WriteLine("Product removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
            // throw new NotImplementedException();
        }

        // TODO: Add other menu method
    }
}
using FlexibleInventorySystem_Practice.Interfaces;
using FlexibleInventorySystem_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Services
{  
    public class InventoryManager : IInventoryOperations, IReportGenerator
    {
        private readonly List<Product> _products;
        private readonly object _lockObject = new object();

        public InventoryManager()
        {
            _products = new List<Product>();
        }

        public bool AddProduct(Product product)
        {
            lock (_lockObject){
                if (_products.Any(p => p.Id == product.Id))
                {
                    return false; // Product with same ID already exists
                }
                _products.Add(product);
                return true;
            }
        }

        public Product FindProduct(string productId)
        {
            lock (_lockObject)
            {
                return _products.FirstOrDefault(p => p.Id == productId);
            }
        }

        public string GenerateCategorySummary()
        {
            lock (_lockObject)
            {
                var summary = _products.GroupBy(p => p.Category)
                                       .Select(g => $"{g.Key}: {g.Count()} items")
                                       .ToList();
                return string.Join("\n", summary);
            }
        }

        public string GenerateExpiryReport(int daysThreshold)
        {
                lock (_lockObject)
                {
                    var report = _products.OfType<GroceryProduct>()
                                        .Where(g => g.DaysUntilExpiry() <= daysThreshold)
                                        .Select(g => $"{g.Name} expires in {g.DaysUntilExpiry()} days")
                                        .ToList();
                    return string.Join("\n", report);
                }
        }

        public string GenerateInventoryReport()
        {
                lock (_lockObject)
                {
                    var report = _products.Select(p => $"{p.Name} - Quantity: {p.Quantity}, Value: ${p.CalculateValue()}")
                                        .ToList();
                    return string.Join("\n", report);
                }
        }

        public string GenerateValueReport()
        {
                lock (_lockObject)
                {
                    var report = _products.Select(p => $"{p.Name} - Total Value: ${p.CalculateValue()}")
                                            .ToList();
                    return string.Join("\n", report);
                }
        }

        public List<Product> GetLowStockProducts(int threshold)
        {
                lock (_lockObject)
                {
                    return _products.Where(p => p.Quantity < threshold).ToList();
                }
        }

        public List<Product> GetProductsByCategory(string category)
        {
            lock (_lockObject)
            {
                return _products.Where(p => p.Category == category).ToList();
            }
        }

        public decimal GetTotalInventoryValue()
        {
            lock (_lockObject)
            {
                return _products.Sum(p => p.CalculateValue());
            }
        }

        public bool RemoveProduct(string productId)
        {
            lock (_lockObject)
            {
                var product = FindProduct(productId);
                if (product != null)
                {
                    _products.Remove(product);
                    return true;
                }
                return false;
            }
        }

        // Implement all interface methods here

        // Additional methods for bonus features
        public IEnumerable<Product> SearchProducts(Func<Product, bool> predicate)
        {
            lock (_lockObject)
            {
                return _products.Where(predicate);
            }
        }

        public bool UpdateQuantity(string productId, int newQuantity)
        {
            lock (_lockObject)
            {
                var product = FindProduct(productId);
                if (product != null)
                {
                    product.Quantity = newQuantity;
                    return true;
                }
                return false;
            }
        }
    }    
}

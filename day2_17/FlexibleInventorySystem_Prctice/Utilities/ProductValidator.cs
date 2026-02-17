using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Utilities
{
    
        /// <summary>
        /// TODO: Implement validation helper class
        /// </summary>
        public static class ProductValidator
        {
            /// <summary>
            /// TODO: Validate product data
            /// Check:
            /// - ID not null/empty
            /// - Name not null/empty
            /// - Price > 0
            /// - Quantity >= 0
            /// </summary>
            

            public static bool ValidateProduct(Product product, out string errorMessage)
            {
                // TODO: Implement validation
                errorMessage = null;
                    if (string.IsNullOrEmpty(product.Id))
                    {
                        errorMessage = "Product ID cannot be null or empty.";
                        return false;
                    }
                    if (string.IsNullOrEmpty(product.Name))
                    {
                        errorMessage = "Product Name cannot be null or empty.";
                        return false;
                    }
                    if (product.Price <= 0)
                    {
                        errorMessage = "Product Price must be greater than zero.";
                        return false;
                    }
                    if (product.Quantity < 0)
                    {
                        errorMessage = "Product Quantity cannot be negative.";
                        return false;
                    }
                    return true;
                throw new InvalidOperationException("Unexpected error in product validation.");
            }

            /// <summary>
            /// TODO: Validate electronic product specific rules
            /// </summary>
            public static bool ValidateElectronicProduct(ElectronicProduct product, out string errorMessage)
            {
                // TODO: Implement electronic validation
                errorMessage = null;
                    if (string.IsNullOrEmpty(product.Brand))
                        {
                            errorMessage = "Electronic Product Brand cannot be null or empty.";
                            return false;
                        }
                        if (product.WarrantyMonths < 0)
                        {
                            errorMessage = "Electronic Product Warranty Months cannot be negative.";
                            return false;
                        }
                        if (string.IsNullOrEmpty(product.Voltage))
                        {
                            errorMessage = "Electronic Product Voltage cannot be null or empty.";
                            return false;
                        }
                        return true;
            }

            /// <summary>
            /// TODO: Validate grocery product specific rules
            /// </summary>
            public static bool ValidateGroceryProduct(GroceryProduct product, out string errorMessage)
            {
                // TODO: Implement grocery validation
                errorMessage = null;
                    if (product.ExpiryDate < DateTime.Now)
                    {
                        errorMessage = "Grocery Product cannot have an expiry date in the past.";
                        return false;
                    }
                    if (product.Weight <= 0)
                    {
                        errorMessage = "Grocery Product Weight must be greater than zero.";
                        return false;
                    }
                    if (string.IsNullOrEmpty(product.StorageTemperature))
                    {
                        errorMessage = "Grocery Product Storage Temperature cannot be null or empty.";
                        return false;
                    }
                    return true;
                throw new InvalidOperationException("Unexpected error in grocery product validation.");
            }

            /// <summary>
            /// TODO: Validate clothing product specific rules
            /// </summary>
            public static bool ValidateClothingProduct(ClothingProduct product, out string errorMessage)
            {
                // TODO: Implement clothing validation
                errorMessage = null;
                    if (string.IsNullOrEmpty(product.Size))
                    {
                        errorMessage = "Clothing Product Size cannot be null or empty.";
                        return false;
                    }
                    if (string.IsNullOrEmpty(product.Color))
                    {
                        errorMessage = "Clothing Product Color cannot be null or empty.";
                        return false;
                    }
                    if (string.IsNullOrEmpty(product.Material))
                    {
                        errorMessage = "Clothing Product Material cannot be null or empty.";
                        return false;
                    }
                    return true;
                throw new InvalidOperationException("Unexpected error in clothing product validation.");
            }
        }
}

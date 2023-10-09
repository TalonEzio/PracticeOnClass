using DataModels.EF;
using System;

namespace DataModels.Helpers
{
    public static class ProductHelper
    {
        public static void UpdateNew(this Product product, Product newProduct)
        {
            product.Name = newProduct.Name;
            product.ImageUrl = newProduct.ImageUrl;
            product.Price = newProduct.Price;
            product.Discount = newProduct.Discount;
            product.Quantity = newProduct.Quantity;
            product.Rate = newProduct.Rate;
            product.Updated = DateTime.Now;
        }
    }

}

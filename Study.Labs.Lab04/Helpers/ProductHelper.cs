using Study.Labs.Lab04.Entities;
using System;
using System.Collections.Generic;

namespace Study.Labs.Lab04.Helpers
{
    static class ProductHelper
    {
        public static List<Product> FindProducts(Product[] products, string component)
        {
            List<Product> result = new List<Product>();
            foreach (var product in products)
            {
                bool productHasIngredient = product.Ingredients.Contains(component);
                if (productHasIngredient)
                {
                    result.Add(product);
                }
            }
            return result;

        }
        public static void PrintProduct(Product product)
        {
            if (product == null)
            {
                Console.WriteLine("������ �������� �� ����������");
            }
            else
            {
                Console.WriteLine($"��� ������ {product.Name}\n��� ������ {product.Category}\n���� �������� {product.ShelfLife}");
            }
        }
    }
}

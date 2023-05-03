using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Setup
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            #endregion
            #region Products
            var productRepo = new DapperProductRepository(conn);
            //productRepo.CreateProduct("potato", 3.50, 10);
            //Product updateProduct = new Product();
            //updateProduct.price = 42.50;
            //updateProduct.name = "Fancy Potato";
            //updateProduct.onSale = false;
            //updateProduct.stockLevel = 999;
            //updateProduct.categoryId = 1;
            //updateProduct.productId = 946;
            //productRepo.UpdateProduct(updateProduct);
            productRepo.DeleteProduct(946);
            var productList = productRepo.GetAllProducts();
            foreach(var product in productList)
            {
                Console.WriteLine(product.name);
                Console.WriteLine(product.price);
                Console.WriteLine(product.productId);
                Console.WriteLine(product.categoryId);
                Console.WriteLine(product.onSale);
                Console.WriteLine(product.stockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }
            #endregion
        }
    }
}

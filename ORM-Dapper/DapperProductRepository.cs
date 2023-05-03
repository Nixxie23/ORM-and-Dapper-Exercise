using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public DapperProductRepository (IDbConnection conn)
        {
            _conn = conn;
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
                new { name = name, price = price, categoryID = categoryID });
        }

        public void DeleteProduct(int productID)
        {
            _conn.Execute("DELETE FROM products WHERE ProductID = @productID;", new {productID = productID});
            _conn.Execute("DELETE FROM sales WHERE ProductID = @productID;", new { productID = productID });
            _conn.Execute("DELETE FROM reviews WHERE ProductID = @productID;", new { productID = productID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("Select * FROM products");
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price, CategoryID = categoryID, OnSale = @onSale, StockLevel = @stockLevel WHERE ProductID = @productID;",
                new
                {
                    productID = product.productId,
                    name = product.name,
                    price = product.price,
                    categoryID = product.categoryId,
                    stockLevel = product.stockLevel,
                    onSale = product.onSale,
                });
        }
    }
}

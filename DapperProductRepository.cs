using Dapper;
using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSQL
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _conn.Execute($"INSERT INTO products (name, price, categoryID) VALUES (@prodName, @prodPrice, @catID);",
                new { prodName = name, prodPrice = price, catID = categoryID });

        }

        public void DeleteProduct(int productID, string name)
        {
            var killed = name;
            _conn.Execute($"DELETE FROM products WHERE ProductID = @productID;",
                new { productID = productID });
            _conn.Execute($"DELETE FROM sales WHERE ProductID = @productID;",
                new { productID = productID });
            _conn.Execute($"DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID = productID });
            Console.WriteLine($"{killed} Deleted");
            Thread.Sleep(3000);

        }
        public void DisplayAllProducts(IEnumerable<Product> products)
        {
            foreach (var prod in products)
            {
                var answer = (prod.OnSale) ? "Yes!" : "Nope";
                Console.WriteLine($"{prod.ProductID}: {prod.Name} -  ${prod.Price}. Is it on sale? {answer}");
            }
        }
        public Product GetProductById(int productID)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM products WHERE productID = @id;",
                new { id = productID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }

        public void UpdateProduct(int iD, double newPrice)
        {
            _conn.Execute($"UPDATE products SET Price = @newPrice, OnSale = true WHERE ProductID = @productID;",
                new { newPrice = newPrice, productID = iD });
                    Console.WriteLine($"Product #{iD} is now on sale for ${newPrice}");
        }



        
    }
}


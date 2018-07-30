using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;
using System.Data.SqlClient;

namespace SSGeek.DAL
{
    public class MockProductSqlDAL : IProductDAL
    {
        static private List<Product> _products = new List<Product>();


        public MockProductSqlDAL(string connectionString)
        {
            PopulateDatabase();
            //_connectionString = connectionString;
        }

        public void PopulateDatabase()
        {
            if (_products.Count <= 0)
            {
                Product product = new Product();
                product.ProductId = 1;
                product.Name = "PRODUCT";
                product.ImageName = "earth.jpg";
                product.Price = 9.99;
                product.Description = "Description Description Description Description" +
                    "Description Description Description Description Description Description " +
                    "Description Description Description Description Description Description";

                _products.Add(product);

                Product product2 = new Product();
                product2.ProductId = 2;
                product2.Name = "PRODUCT2";
                product2.ImageName = "mars.jpg";
                product2.Price = 4.99;
                product2.Description = "Description2 Description Description Description" +
                    "Description Description Description Description Description Description " +
                    "Description Description Description Description Description Description";

                _products.Add(product2);
            }
        }

        //returns list
        public List<Product> GetProducts()
        {
            return _products;
        }

        //return single product
        public Product GetProduct(int id)
        {
            Product result = new Product();
            foreach(Product item in _products)
            {
                if (item.ProductId == id)
                {
                    result = item;
                }
            }

            return result;
        }

    }
}
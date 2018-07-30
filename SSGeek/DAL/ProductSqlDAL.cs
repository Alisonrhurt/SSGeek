using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;
using System.Data.SqlClient;

namespace SSGeek.DAL
{
    public class ProductSqlDAL : IProductDAL
    {
        private string _connectionString = "";

        public ProductSqlDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Product GetProduct(int id)
        {
            Product result = new Product();

            //Connect to Database
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                //Create sql statement
                string sqlPost = $"SELECT product_id, name, description, price, image_name " +
                                 $"FROM products " +
                                 $"WHERE product_id = @product_id";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sqlPost;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@product_id", id);

                //Send command to database
                SqlDataReader reader = cmd.ExecuteReader();

                //Pull data off of result set
                while (reader.Read())
                {

                    result.ProductId = Convert.ToInt32(reader["product_id"]);
                    result.Name = Convert.ToString(reader["name"]);
                    result.Description = Convert.ToString(reader["description"]);
                    result.Price = Convert.ToDouble(reader["price"]);
                    result.ImageName = Convert.ToString(reader["image_name"]);
                    
                }
            }
            return result;
        }
       
        public List<Product> GetProducts()
        {
            List<Product> result = new List<Product>();

            //Connect to Database
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                //Create sql statement
                const string sqlPost = "SELECT product_id, name, description, price, image_name " +
                                       "FROM products ";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sqlPost;
                cmd.Connection = conn;

                //Send command to database
                SqlDataReader reader = cmd.ExecuteReader();

                //Pull data off of result set
                while (reader.Read())
                {
                    Product product = new Product();

                    product.ProductId = Convert.ToInt32(reader["product_id"]);
                    product.Name = Convert.ToString(reader["name"]);
                    product.Description = Convert.ToString(reader["description"]);
                    product.Price = Convert.ToDouble(reader["price"]);
                    product.ImageName = Convert.ToString(reader["image_name"]);

                    result.Add(product);
                }
            }
            return result;
        }

		
    }
}
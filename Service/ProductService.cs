using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using SPTest.Model;

namespace SPTest.Service
{
    class ProductService
    {
        private String connectionString;

        public ProductService()
        {
            this.connectionString = ConfigurationSettings.AppSettings["connectionString"];
        }

        public List<Product> getProductList()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {

                connection.Open();
                SqlCommand command = connection.CreateCommand();

                try
                {
                    command.CommandText = "SELECT * FROM PRODUCT";

                    
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Product product = new Product(int.Parse(dataReader.GetValue(0).ToString()),
                            dataReader.GetValue(1).ToString());
                        products.Add(product);
                    }

                    dataReader.Close();
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                }
            }

            return products;
        }

        public void AddProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "INSERT INTO PRODUCT (NAME) VALUES( '" + product.Name + "')";
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    connection.Close();
                    Console.WriteLine("Товар добавлен.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    transaction.Rollback();
                    connection.Close();
                    Console.WriteLine("Товар не добавлен.");
                }
            }
        }

        public void DeleteProduct(int idProduct)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    // Удаляю все партии во всех аптеках, связанные с этим товаром
                    command.CommandText = "DELETE FROM PART WHERE ID_PRODUCT = " + idProduct + "";
                    command.ExecuteNonQuery();
                    // Удаляю товар
                    command.CommandText = "DELETE FROM PRODUCT WHERE ID_PRODUCT = " + idProduct + "";
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();

                    Console.WriteLine("Товар удалён.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    transaction.Rollback();
                    connection.Close();

                    Console.WriteLine("Товар не удалён.");
                }
            }
        }
    }
}

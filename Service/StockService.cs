using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using SPTest.Model;

namespace SPTest.Service
{
    class StockService
    {
        private String connectionString;

        public StockService()
        {
            this.connectionString = ConfigurationSettings.AppSettings["connectionString"];
        }

        public List<Stock> getStockList()
        {
            List<Stock> stockList = new List<Stock>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                try
                {

                    command.CommandText = "SELECT * FROM STOCK";

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Stock stock = new Stock(int.Parse(dataReader.GetValue(0).ToString()),
                            int.Parse(dataReader.GetValue(1).ToString()),
                            dataReader.GetValue(2).ToString()
                        );
                        stockList.Add(stock);
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

            return stockList;
        }

        public void AddStock(Stock stock)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "INSERT INTO STOCK (ID_PHARMACY, NAME) VALUES( "
                                         + stock.IdPharmacy + ", '" + stock.Name + "')";

                    command.ExecuteNonQuery();
                    transaction.Commit();

                    connection.Close();

                    Console.WriteLine("Склад добавлен.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    transaction.Rollback();
                    connection.Close();

                    Console.WriteLine("Склад не добавлен.");
                }
            }
        }

        public void DeleteStock(int idStock)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    // Удаляю все партии, связанные со складом
                    command.CommandText = "DELETE FROM PART WHERE ID_STOCK = " + idStock + "";
                    command.ExecuteNonQuery();
                    // Удаляю склад
                    command.CommandText = "DELETE FROM STOCK WHERE ID_STOCK = " + idStock + "";
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();
                    Console.WriteLine("Склад удалён.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    transaction.Rollback();
                    connection.Close();
                    Console.WriteLine("Склад не удалён.");
                }
            }
        }
    }
}

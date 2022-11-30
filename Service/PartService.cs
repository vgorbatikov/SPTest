using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using SPTest.Model;

namespace SPTest.Service
{
    class PartService
    {
        private String connectionString;

        public PartService()
        {
            this.connectionString = ConfigurationSettings.AppSettings["connectionString"];
        }

        public List<Part> getPartList()
        {
            List<Part> partList = new List<Part>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {

                connection.Open();
                SqlCommand command = connection.CreateCommand();

                try
                {

                    command.CommandText = "SELECT * FROM PART";

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Part part = new Part(int.Parse(dataReader.GetValue(0).ToString()),
                            int.Parse(dataReader.GetValue(1).ToString()),
                            int.Parse(dataReader.GetValue(2).ToString()),
                            int.Parse(dataReader.GetValue(3).ToString())
                        );
                        partList.Add(part);
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

            return partList;
        }

        public void AddPart(Part part)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "INSERT INTO PART (ID_PRODUCT, ID_STOCK, QUANTITY) VALUES( "
                                         + part.IdProduct + ", " + part.IdStock + ", " + part.quantity + ")";

                    command.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();
                    Console.WriteLine("Партия добавлена.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    transaction.Rollback();
                    connection.Close();
                    Console.WriteLine("Партия не добавлена.");
                }
            }
        }

        public void DeletePart(int idPart)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    // Удаляю партию
                    command.CommandText = "DELETE FROM PART WHERE ID_PART = " + idPart + "";
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();
                    Console.WriteLine("Партия удалена.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    transaction.Rollback();
                    connection.Close();
                    Console.WriteLine("Партия не удалена.");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using SPTest.Model;

namespace SPTest.Service
{
    class PharmacyService
    {
        private String connectionString;

        public PharmacyService()
        {
            this.connectionString = ConfigurationSettings.AppSettings["connectionString"];
        }

        public List<Pharmacy> getPharmacyList()
        {
            List<Pharmacy> phList = new List<Pharmacy>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                try
                {

                    command.CommandText = "SELECT * FROM PHARMACY";

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Pharmacy pharmacy = new Pharmacy(int.Parse(dataReader.GetValue(0).ToString()),
                            dataReader.GetValue(1).ToString(),
                            dataReader.GetValue(2).ToString(),
                            dataReader.GetValue(3).ToString()
                        );
                        phList.Add(pharmacy);
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

            return phList;
        }

        public void AddPharmacy(Pharmacy pharmacy)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "INSERT INTO PHARMACY (NAME, ADDRESS, PHONE) VALUES( '"
                                         + pharmacy.Name + "', '" + pharmacy.Address + "', '" + pharmacy.Phone + "')";

                    command.ExecuteNonQuery();
                    transaction.Commit();

                    connection.Close();
                    Console.WriteLine("Аптека добавлена.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    transaction.Rollback();
                    connection.Close();
                    Console.WriteLine("Аптека не добавлена.");
                }
            }
        }

        public void DeletePharmacy(int idPharmacy)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;


                try
                {
                    // Удаляю все партии в складах, связанных с аптекой
                    command.CommandText = "DELETE FROM PART WHERE ID_STOCK IN ( SELECT ID_STOCK FROM STOCK WHERE ID_PHARMACY = " + idPharmacy + ")";
                    command.ExecuteNonQuery();
                    // Удаляю склады, связанные с аптекой
                    command.CommandText = "DELETE FROM STOCK WHERE ID_PHARMACY = " + idPharmacy + "";
                    command.ExecuteNonQuery();
                    // Удаляю аптеку
                    command.CommandText = "DELETE FROM PHARMACY WHERE ID_PHARMACY = " + idPharmacy + "";
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();
                    Console.WriteLine("Аптека удалена.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    transaction.Rollback();
                    connection.Close();
                    Console.WriteLine("Аптека не удалена.");
                }
            }
        }
    }
}

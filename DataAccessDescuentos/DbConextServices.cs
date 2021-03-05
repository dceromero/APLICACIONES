using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class DbConextServices
    {
        string cadena = ConfigurationManager.ConnectionStrings["ModelDescuentos"].ConnectionString;
        // "data source=172.30.5.2;initial catalog=APLICACIONES;persist security info=True;user id=USROFIMA;password=ofima2017.*;";

        public string guardar<T>(string tabla, IEnumerable<T> lista)
        {
            string result = "Registros Guardados";
            using (var connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                using (var bulkCopy = new SqlBulkCopy(cadena))
                {
                    try
                    {
                        bulkCopy.BatchSize = 10000;
                        bulkCopy.DestinationTableName = tabla;
                        bulkCopy.WriteToServer(lista.AsDataTable());
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message.ToString();
                        transaction.Rollback();
                        connection.Close();
                    }
                }
            }
            return result;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ActivitiesBL
{
    public class Batch
    {
        SqlConnection sqlConObj = null;
        SqlCommand sqlCmdObj = null;
        public void ConnectToDB()
        {
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Batch"].ToString());
                sqlConObj.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!Something went wrong!");
            }
            finally
            {
                sqlConObj.Close();
            }
        }

        public List<String> ReadfromDB()
        {
            List<String> lstBatch = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Batch"].ToString());
                sqlCmdObj = new SqlCommand(@"Select * from Batch", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drBatch = sqlCmdObj.ExecuteReader();
                while (drBatch.Read())
                {
                    lstBatch.Add(String.Concat(drBatch["BatchId"] + "  ", drBatch["BatchName"] + "  ", drBatch["StartDate"] + "  ", drBatch["StudentCount"] + "  ", drBatch["ModelId"]));
                }
                return lstBatch;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!Something went wrong!");
                return lstBatch;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}

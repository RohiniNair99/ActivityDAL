using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ActivitiesBL
{
    public class Model
    {
        SqlConnection sqlConObj = null;
        SqlCommand sqlCmdObj = null;
        public void ConnectToDB()
        {
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Model"].ToString());
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
            List<String> lstModel = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Model"].ToString());
                sqlCmdObj = new SqlCommand(@"Select * from DeliveryModel", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drModel = sqlCmdObj.ExecuteReader();
                while (drModel.Read())
                {
                    lstModel.Add(String.Concat(drModel["ModelId"] + "  ", drModel["ModelName"] ));
                }
                return lstModel;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!Something went wrong!");
                return lstModel;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}

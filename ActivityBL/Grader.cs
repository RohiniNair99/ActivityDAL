using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ActivitiesBL
{
    public class Grader
    {
        SqlConnection sqlConObj = null;
        SqlCommand sqlCmdObj = null;
        public void ConnectToDB()
        {
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Grader"].ToString());
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
            List<String> lstGrader = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["Grader"].ToString());
                sqlCmdObj = new SqlCommand(@"Select * from Grader", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drGrader = sqlCmdObj.ExecuteReader();
                while (drGrader.Read())
                {
                    lstGrader.Add(String.Concat(drGrader["GId"] + "  ", drGrader["BCFId"] + "  ", drGrader["PSNO"] + "  ", drGrader["Score"] + "  ", drGrader["AreaOfExcellence"] + "  ", drGrader["AreaOfImprovement"]));
                }
                return lstGrader;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!Something went wrong!");
                return lstGrader;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
